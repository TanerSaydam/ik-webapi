using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.EmployeeRepository
{
    public interface IEmployeeService
    {
        Task<IResult> Add(Employee employee);
        Task<IResult> Update(Employee employee);
        Task<IResult> Delete(Employee employee);
        Task<IDataResult<List<Employee>>> GetList();
        Task<IDataResult<Employee>> GetById(int id);
    }
}
