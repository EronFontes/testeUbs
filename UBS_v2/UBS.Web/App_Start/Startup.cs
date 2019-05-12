using Core.Interfaces;
using Infrastructure.Watcher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UBS.Web.App_Start
{
    public class Startup : IStartup
    {
        public IWatcher _wacher;
        public Startup(IWatcher wacher)
        {
            _wacher = wacher;
        }
        public void Init()
        {
            _wacher.CreateWacher("C:\\Mock", "MOCK_DATA_1.json");

            //File.Copy(Path.Combine("D:\\", "MOCK_DATA_1.json"), Path.Combine("D:\\Mock", "MOCK_DATA_1.json"), true);
        }
    }
}