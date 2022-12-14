using Pms.Masterlists.Domain;
using Pms.Masterlists.ServiceLayer;
using Pms.Masterlists.ServiceLayer.EfCore;
using Pms.Masterlists.ServiceLayer.Files;
using Pms.Masterlists.ServiceLayer.HRMS;
using Pms.Masterlists.ServiceLayer.HRMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Main.FrontEnd.Government.Models
{
    public class EmployeeModel
    {
        PayrollCodeManager _payrollCodeManager;
        CompanyManager _companyManager;
        EmployeeProvider _employeeProvider;
        EmployeeManager _employeeManager;

        public EmployeeModel(EmployeeProvider employeeProvider, EmployeeManager employeeManager, PayrollCodeManager payrollCodeManager, CompanyManager companyManager)
        {
            _employeeProvider = employeeProvider;
            _employeeManager = employeeManager;
            _payrollCodeManager = payrollCodeManager;
            _companyManager = companyManager;
        }

        public bool Exists(string eeId) =>
           _employeeProvider.EmployeeExists(eeId);


        public void Save(IPersonalInformation employee) =>
           _employeeManager.Save(employee);

        public void Save(IBankInformation employee) =>
            _employeeManager.Save(employee);

        public void Save(IGovernmentInformation employee) =>
            _employeeManager.Save(employee);

        public void Save(IEEDataInformation employee) =>
            _employeeManager.Save(employee);
         
        public IEnumerable<Employee> GetEmployees() =>
            _employeeProvider.GetEmployees();


        public IEnumerable<Company> ListCompanies() =>
            _companyManager.GetAllCompanies().ToList();

        public IEnumerable<PayrollCode> ListPayrollCodes() =>
                    _payrollCodeManager.GetPayrollCodes().ToList();
         

        public IEnumerable<IEEDataInformation> ImportEEData(string eeDataPath)
        {
            EmployeeEEDataImporter importer = new();
            return importer.StartImport(eeDataPath);
        }
    }
}
