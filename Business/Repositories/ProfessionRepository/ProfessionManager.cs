using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.ProfessionRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.ProfessionRepository.Validation;
using Business.Repositories.ProfessionRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.ProfessionRepository;
using Core.Utilities.Business;
using Entities.Dtos;

namespace Business.Repositories.ProfessionRepository
{
    public class ProfessionManager : IProfessionService
    {
        private readonly IProfessionDal _professionDal;

        public ProfessionManager(IProfessionDal professionDal)
        {
            _professionDal = professionDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(ProfessionValidator))]
        [RemoveCacheAspect("IProfessionService.Get")]

        public async Task<IResult> Add(Profession profession)
        {
            var result = BusinessRules.Run(await IsNameExist(profession.Name));

            if (result != null)
                return result;

            await _professionDal.Add(profession);
            return new SuccessResult(ProfessionMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(ProfessionValidator))]
        [RemoveCacheAspect("IProfessionService.Get")]

        public async Task<IResult> Update(Profession profession)
        {
            var oldProfession = await _professionDal.Get(p => p.Id == profession.Id);

            if(oldProfession.Name != profession.Name)
            {
                var result = BusinessRules.Run(await IsNameExist(profession.Name));

                if (result != null)
                    return result;
            }

            await _professionDal.Update(profession);
            return new SuccessResult(ProfessionMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IProfessionService.Get")]

        public async Task<IResult> Delete(int id)
        {
            var profession = await _professionDal.Get(p => p.Id == id);
            await _professionDal.Delete(profession);
            return new SuccessResult(ProfessionMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Profession>>> GetList()
        {
            return new SuccessDataResult<List<Profession>>(await _professionDal.GetAll());
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<GenericPaginationListDto<Profession>>> GetListWithPagination(int page, int size)
        {
            var result = await _professionDal.GetAllWithPagination(page, size);
            var count = _professionDal.PaginationCount(size);

            GenericPaginationListDto<Profession> pagination = new()
            {
                Datas = result,
                TotalPageNumber = count,
            };

            return new SuccessDataResult<GenericPaginationListDto<Profession>>(pagination);
        }

        [SecuredAspect()]
        public async Task<IDataResult<Profession>> GetById(int id)
        {
            return new SuccessDataResult<Profession>(await _professionDal.Get(p => p.Id == id));
        }


        public async Task<IResult> IsNameExist(string name)
        {
            var result = await _professionDal.IfNameExist(name);
            if (result)
                return new ErrorResult("Bu meslek adý daha önce kaydedilmiþ");

            return new SuccessResult();
        }
    }
}
