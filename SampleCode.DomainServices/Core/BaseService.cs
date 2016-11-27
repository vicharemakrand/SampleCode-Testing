using SampleCode.IDomainServices;
using SampleCode.IDomainServices.Core;
using SampleCode.IRepositories.Core;
using SampleCode.Models;
using SampleCode.ServiceResponse;
using SampleCode.Utilities;
using SampleCode.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using SampleCode.DomainServices.AutoMapper;
using StructureMap;
using StructureMap.Attributes;

namespace SampleCode.DomainServices.Core
{
    public abstract class BaseService<T,VM> : IBaseService<T,VM> where T:BaseModel where VM:BaseViewModel
    {
        private  IBaseRepository<T> baseRepository;
        private  IUnitOfWork unitOfWork;

       // [SetterProperty]
        public IBaseRepository<T> BaseRepository {
            get
            {
                return baseRepository;
            }
            set
            {
                baseRepository = value;
            }
        }

       // [SetterProperty]
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
            set
            {
                unitOfWork = value;
            }
        }

        public BaseService()
        {
            //baseRepository = BaseRepository;
            //unitOfWork = UnitOfWork;
        }

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<T> baseRepository)
        {
            this.unitOfWork = unitOfWork;
            this.baseRepository = baseRepository;
        }

        public virtual ResponseResults<VM> GetAll()
        {
            var response = new ResponseResults<VM>() { IsSucceed  =true, Message = AppMessages.Retrieved_Details_Successfully};
            try
            {
                var models = baseRepository.GetAll();
                response.ViewModels = models.ToViewModel<T, VM>().ToList();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public virtual ResponseResult<VM> GetById(long id)
        {
            var response = new ResponseResult<VM>() { IsSucceed = true, Message = AppMessages.Retrieved_Details_Successfully };
            try
            {
                var model = baseRepository.GetById(id);
                response.ViewModel = model.ToViewModel<T, VM>();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public virtual ResponseResult<VM> Save(VM viewModel)
        {
            var response = new ResponseResult<VM>() { IsSucceed = true, Message = AppMessages.Saved_Details_Successfully };
            try
            {
                T model = viewModel.ToEntityModel<T,VM>();
            
                if (viewModel.Id == 0)
                {
                    model = baseRepository.Add(model);
                }
                else
                {
                    model = baseRepository.Update(model);
                }
            
                unitOfWork.Commit();
                response.ViewModel = model.ToViewModel<T, VM>();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
