using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.EmployeeRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.EmployeeRepository.Validation;
using Business.Repositories.EmployeeRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.EmployeeRepository;

namespace Business.Repositories.EmployeeRepository
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(EmployeeValidator))]
        [RemoveCacheAspect("IEmployeeService.Get")]

        public async Task<IResult> Add(Employee employee)
        {
            await _employeeDal.Add(employee);
            return new SuccessResult(EmployeeMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(EmployeeValidator))]
        [RemoveCacheAspect("IEmployeeService.Get")]

        public async Task<IResult> Update(Employee employee)
        {
            await _employeeDal.Update(employee);
            return new SuccessResult(EmployeeMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IEmployeeService.Get")]

        public async Task<IResult> Delete(Employee employee)
        {
            await _employeeDal.Delete(employee);
            return new SuccessResult(EmployeeMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Employee>>> GetList()
        {
            return new SuccessDataResult<List<Employee>>(await _employeeDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Employee>> GetById(int id)
        {
            return new SuccessDataResult<Employee>(await _employeeDal.Get(p => p.Id == id));
        }

    }
}
