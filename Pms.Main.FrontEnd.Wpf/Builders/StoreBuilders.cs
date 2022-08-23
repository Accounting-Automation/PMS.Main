﻿using Microsoft.Extensions.DependencyInjection;
using Pms.Main.FrontEnd.Wpf.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Main.FrontEnd.Wpf.Builders
{
    static class StoreBuilders
    {
        public static ServiceCollection AddStores(this ServiceCollection services)
        {
            services.AddSingleton<MainStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<TimesheetStore>();
            services.AddSingleton<EmployeeStore>();
            services.AddSingleton<BillingStore>();
            services.AddSingleton<PayrollStore>();

            return services;
        }
    }
}