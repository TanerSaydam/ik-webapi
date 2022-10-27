using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Repositories.ProfessionRepository
{
    public interface IProfessionDal : IEntityRepository<Profession>
    {
        public Task<bool> IfNameExist(string name);
    }
}
