using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.EmployeeRequestFileRepository
{
    public interface IEmployeeRequestFileService
    {
        Task<IResult> Add(EmployeeRequestFile employeeRequestFile);
        Task<IResult> Update(EmployeeRequestFile employeeRequestFile);
        Task<IResult> Delete(EmployeeRequestFile employeeRequestFile);
        Task<IDataResult<List<EmployeeRequestFile>>> GetList();
        Task<IDataResult<EmployeeRequestFile>> GetById(int employeeId, int fileId);
    }
}
