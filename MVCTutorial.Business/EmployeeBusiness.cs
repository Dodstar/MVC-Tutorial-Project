using MVCTutorial.Business.Interface;
using MVCTutorial.Domain;
using MVCTutorial.Repository;
using MVCTutorial.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTutorial.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmployeeRepository empRepository;
        private readonly AddressRepository deptRepository;

        public EmployeeBusiness(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;
            empRepository = new EmployeeRepository(unitOfWork);
            deptRepository = new AddressRepository(unitOfWork);
            
        }
      

        //----------------Used in Test controller--------------------------------

        #region

        public int TotalEmployeeRecord()
        {
            int count = empRepository.GetAll(x => x.IsDeleted == false).Count();

            return count;
        }
        public List<EmployeeDomainModel> GetEmployeeRecords(int pageNo, int pageSize)
        {
            List<EmployeeDomainModel> List = new List<EmployeeDomainModel>();

            List = empRepository.GetPagedRecords(y => y.IsDeleted == false, x => x.Forname, pageNo, pageSize)

                                .Select(x => new EmployeeDomainModel
                                {
                                    Forname = x.Forname,
                                    MiddleName = x.MiddleName,
                                    Surname = x.Surname,
                                    EmployeeId = x.EmployeeId,
                                    DepartmentName = x.Department.DepartmentName,
                                    HouseNumber = x.Address.HouseNumber,
                                    HouseIdentifier=x.Address.HouseIdentifier,
                                    HouseName=x.Address.HouseName,
                                    Street=x.Address.Street,
                                    City=x.Address.City,
                                    Region=x.Address.Region,
                                    Postcode=x.Address.Postcode
                                    
                                }).ToList();


            return List;
        }
        public EmployeeDomainModel GetEmployeeById(int Id)
        {
            EmployeeDomainModel empDomainModel = new EmployeeDomainModel();
            Employee emp = empRepository.SingleOrDefault(x => x.EmployeeId == Id && x.IsDeleted == false);

            if (emp != null)
            {
                empDomainModel.EmployeeId = emp.EmployeeId;
                empDomainModel.DepartmentId = emp.DepartmentId;
                empDomainModel.Forname = emp.Forname;
                empDomainModel.MiddleName = emp.MiddleName;
                empDomainModel.Surname = emp.Surname;
                
            }

            return empDomainModel;
        }
        public EmployeeDomainModel AddEditEmployee(EmployeeDomainModel domainModel)
        {

            if (domainModel.EmployeeId > 0)
            {
                //update
                Employee employee = empRepository.SingleOrDefault(x => x.EmployeeId == domainModel.EmployeeId && x.IsDeleted == false);

                employee.DepartmentId = domainModel.DepartmentId;
                employee.Forname = domainModel.Forname;
                employee.Surname = domainModel.Surname;
                employee.MiddleName = domainModel.MiddleName;
                empRepository.Update(employee);


            }
            else
            {
                //Insert
                Employee employee = new Employee();
                employee.MiddleName = domainModel.MiddleName;
                employee.Forname = domainModel.Forname;
                employee.Surname = domainModel.Surname;
                employee.DepartmentId = domainModel.DepartmentId;
                employee.IsDeleted = false;
                empRepository.Insert(employee);

                domainModel.EmployeeId = employee.EmployeeId;

            }

            return domainModel;
        }
        public bool DeleteEmployee(int employeeId)
        {
            bool result = false;
            Employee employee = empRepository.SingleOrDefault(x => x.EmployeeId == employeeId && x.IsDeleted == false);

            if (employee != null)
            {
                employee.IsDeleted = true;
                empRepository.Update(employee);
                result = true;

            }
            return result;
        }

        //datatable search
        public int TotalEmployeeCount(string searchText)
        {

            int count = empRepository.GetAll(x => x.IsDeleted == false && (x.Forname.Contains(searchText) || x.Surname.Contains(searchText) ||x.Department.DepartmentName.Contains(searchText) || x.MiddleName.Contains(searchText))).Count();

            return count;
        }
        public List<EmployeeDomainModel> SearchEmployee(string searchText, int pageNo, int pageSize)
        {
            List<EmployeeDomainModel> List = new List<EmployeeDomainModel>();

            List = empRepository.GetPagedRecords(x => x.IsDeleted == false && (x.Forname.Contains(searchText) || x.Surname.Contains(searchText) ||x.Department.DepartmentName.Contains(searchText) || x.MiddleName.Contains(searchText)), y => y.Forname, pageNo, pageSize)

                                .Select(x => new EmployeeDomainModel
                                {
                                    Forname = x.Forname,
                                    Surname=x.Surname,
                                    EmployeeId = x.EmployeeId,
                                    DepartmentName = x.Department.DepartmentName,
                                    MiddleName = x.MiddleName,
                                }).ToList();


            return List;
        }


        //datatable external search
        public int TotalEmployeeCountByEmployeeName(string searchText)
        {

            int count = empRepository.GetAll(x =>  x.IsDeleted == false && (x.Forname.Contains(searchText) || x.Surname.Contains(searchText) || x.Department.DepartmentName.Contains(searchText) || x.MiddleName.Contains(searchText))).Count();

            return count;
        }
        public List<EmployeeDomainModel> SearchEmployeeByEmployeeName(string searchText, int pageNo, int pageSize)
        {
            List<EmployeeDomainModel> List = new List<EmployeeDomainModel>();

            List = empRepository.GetPagedRecords(x => x.IsDeleted == false && (x.Forname.Contains(searchText) || x.Surname.Contains(searchText) || x.Department.DepartmentName.Contains(searchText) || x.MiddleName.Contains(searchText)), y => y.Forname, pageNo, pageSize)

                                .Select(x => new EmployeeDomainModel
                                {
                                    Forname = x.Forname,
                                    Surname=x.Surname,
                                    EmployeeId = x.EmployeeId,
                                    DepartmentName = x.Department.DepartmentName,
                                    MiddleName = x.MiddleName,
                                }).ToList();


            return List;
        }

        #endregion


        //---------------Used in Repo controller-----------------------

        #region

        public List<EmployeeDomainModel> GetAllEmployee()
        {
            List<EmployeeDomainModel> list = empRepository.GetAll().Select(m => new EmployeeDomainModel { Forname = m.Forname, Surname = m.Surname, DepartmentName = m.Department.DepartmentName, MiddleName = m.MiddleName }).ToList();

            return list;
        }
        public string AddUpdateEmployee(EmployeeDomainModel empModel)
        {

            string result = "";
            if (empModel.EmployeeId > 0)
            {

                Employee emp = empRepository.SingleOrDefault(x => x.EmployeeId == empModel.EmployeeId);

                if (emp != null)
                {
                    emp.Forname = empModel.Forname;
                    emp.Surname = empModel.Surname;
                    emp.DepartmentId = empModel.DepartmentId;
                    emp.MiddleName = empModel.MiddleName;

                    empRepository.Update(emp);

                    result = "updated";

                }
            }
            else
            {
                Employee emp = new Employee();

                emp.Forname = empModel.Forname;
                emp.Surname = empModel.Surname;
                emp.DepartmentId = empModel.DepartmentId;
                emp.MiddleName = empModel.MiddleName;
                emp.IsDeleted = false;

                var record = empRepository.Insert(emp);

                result = "Inserted";
            }

            return result;
        }

        #endregion

    }
}
