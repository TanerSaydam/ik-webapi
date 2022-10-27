using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.RequestFileRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.RequestFileRepository
{
    public class EfRequestFileDal : EfEntityRepositoryBase<RequestFile, SimpleContextDb>, IRequestFileDal
    {
    }
}
