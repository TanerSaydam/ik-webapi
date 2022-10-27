using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.ProfessionRepository
{
    public interface IProfessionService
    {
        Task<IResult> Add(Profession profession);
        Task<IResult> Update(Profession profession);
        Task<IResult> Delete(int id);
        Task<IDataResult<List<Profession>>> GetList();
        Task<IDataResult<Profession>> GetById(int id);
    }
}
