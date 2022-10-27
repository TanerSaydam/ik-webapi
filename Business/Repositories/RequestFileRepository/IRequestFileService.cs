using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.RequestFileRepository
{
    public interface IRequestFileService
    {
        Task<IResult> Add(RequestFile requestFile);
        Task<IResult> Update(RequestFile requestFile);
        Task<IResult> Delete(RequestFile requestFile);
        Task<IDataResult<List<RequestFile>>> GetList();
        Task<IDataResult<RequestFile>> GetById(int id);
    }
}
