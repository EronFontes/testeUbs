using Core.Interfaces;
using Infrastructure.Watcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC
{
    public static class BootStrapper
    {
        public static void Configure(IContainer container)
        {
            container.Register<IWacher, Wacher>(LifeCycle.Singleton);
        }
    }
}
