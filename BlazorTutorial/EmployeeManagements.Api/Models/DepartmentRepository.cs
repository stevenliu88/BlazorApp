using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagements.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private AppDbContext appDbContext;
        public DepartmentRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public Department GetDepartment(int departmentId)
        {
            return appDbContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return appDbContext.Departments;

        }
    }
}
