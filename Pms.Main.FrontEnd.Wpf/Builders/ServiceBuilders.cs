﻿using Microsoft.Extensions.DependencyInjection;
using Pms.Adjustments.Domain.Services;
using Pms.Adjustments.ServiceLayer.EfCore;
using Pms.Adjustments.ServiceLayer.Files;
using Pms.Masterlists.ServiceLayer;
using Pms.Masterlists.ServiceLayer.EfCore;
using Pms.Masterlists.ServiceLayer.Files;
using Pms.Masterlists.ServiceLayer.HRMS.Service;
using Pms.Main.FrontEnd.Wpf.Stores;
using Pms.Payrolls.Domain.Services;
using Pms.Payrolls.ServiceLayer.EfCore;
using Pms.Payrolls.ServiceLayer.Files;
using Pms.Payrolls.ServiceLayer.Files.Exports;
using Pms.Timesheets.BizLogic;
using Pms.Timesheets.BizLogic.Concrete;
using Pms.Timesheets.ServiceLayer.EfCore;
using Pms.Timesheets.ServiceLayer.TimeSystem;
using Pms.Timesheets.ServiceLayer.TimeSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Main.FrontEnd.Wpf.Builders
{
    static class ServiceBuilders
    {
        public static ServiceCollection AddServices(this ServiceCollection services)
        {
            services.AddSingleton<CompanyManager>();
            services.AddSingleton<PayrollCodeManager>();
            
            services.AddSingleton<EmployeeProvider>();
            services.AddSingleton<EmployeeManager>();
            services.AddSingleton<FindEmployeeService>();
            services.AddSingleton<EmployeeBankInformationImporter>();

            services.AddSingleton<IProvideTimesheetService, TimesheetProvider>();
            services.AddSingleton<IDownloadContentProvider, DownloadContentProvider>();
            services.AddSingleton<TimesheetManager>();

            services.AddSingleton<IManageBillingService, BillingManager>();
            services.AddSingleton<IProvideBillingService, BillingProvider>();
            services.AddSingleton<IGenerateBillingService, BillingGenerator>();
            services.AddSingleton<BillingExporter>();

            services.AddSingleton<IManagePayrollService, PayrollManager>();
            services.AddSingleton<IProvidePayrollService, PayrollProvider>();
            //services.AddSingleton<IImportPayrollService, PayRegisterImportBase>();


            return services;
        }
    }
}
