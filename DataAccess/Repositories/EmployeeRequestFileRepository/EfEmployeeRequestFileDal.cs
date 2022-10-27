using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.EmployeeRequestFileRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.EmployeeRequestFileRepository
{
    public class EfEmployeeRequestFileDal : EfEntityRepositoryBase<EmployeeRequestFile, SimpleContextDb>, IEmployeeRequestFileDal
    {
    }
}
