using Microsoft.Extensions.DependencyInjection;
using Pms.Main.FrontEnd.Common;
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
            services.AddSingleton<NavigationStore>(); 

            return services;
        }
    }
}
