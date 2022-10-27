using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.ProfessionRepository;
using DataAccess.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.ProfessionRepository
{
    public class EfProfessionDal : EfEntityRepositoryBase<Profession, SimpleContextDb>, IProfessionDal
    {
        public async Task<bool> IfNameExist(string name)
        {
            using (var context = new SimpleContextDb())
            {
                var result = await context.Professions.Where(p => p.Name == name).ToListAsync();
                return result.Any();
            }
        }
    }
}
