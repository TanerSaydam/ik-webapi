using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.RequestFileRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.RequestFileRepository.Validation;
using Business.Repositories.RequestFileRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.RequestFileRepository;

namespace Business.Repositories.RequestFileRepository
{
    public class RequestFileManager : IRequestFileService
    {
        private readonly IRequestFileDal _requestFileDal;

        public RequestFileManager(IRequestFileDal requestFileDal)
        {
            _requestFileDal = requestFileDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(RequestFileValidator))]
        [RemoveCacheAspect("IRequestFileService.Get")]

        public async Task<IResult> Add(RequestFile requestFile)
        {
            await _requestFileDal.Add(requestFile);
            return new SuccessResult(RequestFileMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(RequestFileValidator))]
        [RemoveCacheAspect("IRequestFileService.Get")]

        public async Task<IResult> Update(RequestFile requestFile)
        {
            await _requestFileDal.Update(requestFile);
            return new SuccessResult(RequestFileMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IRequestFileService.Get")]

        public async Task<IResult> Delete(RequestFile requestFile)
        {
            await _requestFileDal.Delete(requestFile);
            return new SuccessResult(RequestFileMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<RequestFile>>> GetList()
        {
            return new SuccessDataResult<List<RequestFile>>(await _requestFileDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<RequestFile>> GetById(int id)
        {
            return new SuccessDataResult<RequestFile>(await _requestFileDal.Get(p => p.Id == id));
        }

    }
}
