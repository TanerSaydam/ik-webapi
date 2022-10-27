using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.EmployeeRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.EmployeeRepository
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, SimpleContextDb>, IEmployeeDal
    {
    }
}
