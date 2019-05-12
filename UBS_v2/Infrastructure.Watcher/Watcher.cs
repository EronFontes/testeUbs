using Core.Entities;
using Core.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Caching;
using System.Threading;

namespace Infrastructure.Watcher
{
    public class Watcher : IWatcher
    {
        private IUpdateModel _updateModel;

        private MemoryCache _memCache;
        private CacheItemPolicy _cacheItemPolicy;
        private const int CacheTimeMilliseconds = 1000;
        string _path = String.Empty;
        string _fileName = String.Empty;

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);


        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern bool TerminateThread(IntPtr hThread, uint dwExitCode);

        public Watcher(IUpdateModel updateModel)
        {
            _updateModel = updateModel;
        }
        public void CreateWacher(string path, string fileName)
        {
            _memCache = MemoryCache.Default;

            _path = path;
            _fileName = fileName;

            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = path,
                Filter = fileName,
                NotifyFilter = NotifyFilters.LastWrite,
            };

            _cacheItemPolicy = new CacheItemPolicy()
            {
                RemovedCallback = OnRemovedFromCache
            };

            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Created;
            watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.ChangeType + e.Name);
            _updateModel.Start(_path + "\\" + _fileName);
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {

            ProcessThreadCollection processThreads = Process.GetCurrentProcess().Threads;

            foreach (ProcessThread thread in processThreads)
            {
                IntPtr ptrThread = OpenThread(1, false, (uint)thread.Id);

                if (PersonProvider.ThreadId == thread.Id)
                    TerminateThread(ptrThread, 1);
            }

            _cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddMilliseconds(CacheTimeMilliseconds);

            // Only add if it is not there already (swallow others)
            var obj = _memCache.AddOrGetExisting(e.Name, e, _cacheItemPolicy);

            if (obj == null)
            {
                Thread thread = new Thread(StartImport);
                PersonProvider.ThreadId = thread.ManagedThreadId;

                thread.Start();
            }
        }

        public void StartImport()
        {
            _updateModel.Start(_path + "\\" + _fileName);
        }

        // Handle cache item expiring
        private void OnRemovedFromCache(CacheEntryRemovedArguments args)
        {
            if (args.RemovedReason != CacheEntryRemovedReason.Expired) return;

            // Now actually handle file event
            var e = (FileSystemEventArgs)args.CacheItem.Value;
        }

    }
}
