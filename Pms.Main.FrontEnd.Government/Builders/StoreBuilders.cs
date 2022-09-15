﻿using Microsoft.Extensions.DependencyInjection;
using Pms.Main.FrontEnd.Common.Stores;
using Pms.Main.FrontEnd.Government.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Main.FrontEnd.Government.Builders
{
    static class StoreBuilders
    {
        public static ServiceCollection AddStores(this ServiceCollection services)
        {
            services.AddSingleton<MainStore>(); 
            services.AddSingleton<NavigationStore>(); 

            return services;
        }
    }
}