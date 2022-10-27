using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.EmployeeRequestFileRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.EmployeeRequestFileRepository.Validation;
using Business.Repositories.EmployeeRequestFileRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.EmployeeRequestFileRepository;

namespace Business.Repositories.EmployeeRequestFileRepository
{
    public class EmployeeRequestFileManager : IEmployeeRequestFileService
    {
        private readonly IEmployeeRequestFileDal _employeeRequestFileDal;

        public EmployeeRequestFileManager(IEmployeeRequestFileDal employeeRequestFileDal)
        {
            _employeeRequestFileDal = employeeRequestFileDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(EmployeeRequestFileValidator))]
        [RemoveCacheAspect("IEmployeeRequestFileService.Get")]

        public async Task<IResult> Add(EmployeeRequestFile employeeRequestFile)
        {
            await _employeeRequestFileDal.Add(employeeRequestFile);
            return new SuccessResult(EmployeeRequestFileMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(EmployeeRequestFileValidator))]
        [RemoveCacheAspect("IEmployeeRequestFileService.Get")]

        public async Task<IResult> Update(EmployeeRequestFile employeeRequestFile)
        {
            await _employeeRequestFileDal.Update(employeeRequestFile);
            return new SuccessResult(EmployeeRequestFileMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IEmployeeRequestFileService.Get")]

        public async Task<IResult> Delete(EmployeeRequestFile employeeRequestFile)
        {
            await _employeeRequestFileDal.Delete(employeeRequestFile);
            return new SuccessResult(EmployeeRequestFileMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<EmployeeRequestFile>>> GetList()
        {
            return new SuccessDataResult<List<EmployeeRequestFile>>(await _employeeRequestFileDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<EmployeeRequestFile>> GetById(int employeeId, int fileId)
        {
            return new SuccessDataResult<EmployeeRequestFile>(await _employeeRequestFileDal.Get(p => p.EmployeeId == employeeId && p.RequestFileId == fileId));
        }

    }
}
