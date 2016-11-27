using SampleCode.Models;
using SampleCode.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleCode.IDomainServices.Core;
using SampleCode.ServiceResponse;

namespace SampleCode.Web.Controllers
{
    public abstract class  BaseAuditableController<T,VM> : Controller  where T:AuditableModel where VM:AuditableViewModel
    {
        private readonly IBaseService<T,VM> baseService;


        public BaseAuditableController(IBaseService<T, VM> baseService)
        {
            this.baseService = baseService;
        }

        // GET: /Base/
        public ActionResult Index()
        {
            var response = baseService.GetAll();
            var viewModels = new List<VM>();

            if (response.IsSucceed)
            {
                viewModels = response.ViewModels;
            }

            return View(viewModels);
        }

        //
        // GET: /Base/Details/5

        public ActionResult Details(int id)
        {

            var response = baseService.GetById(id);

            if (response.IsSucceed)
            {
                var viewModel = response.ViewModel;
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /Base/Create

        public ActionResult Create()
        {
            var viewModel = Activator.CreateInstance<VM>();
            return View(viewModel);
        }

        //
        // POST: /Base/Create

        [HttpPost]
        public ActionResult Create(VM viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.UpdatedBy = -1;
                    viewModel.UpdatedOn = DateTime.Now;
                    baseService.Save(viewModel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Base/Edit/5

        public ActionResult Edit(int id)
        {
            var viewModel = baseService.GetById(id);
            return View(viewModel);
        }

        //
        // POST: /Base/Edit/5

        [HttpPost]
        public ActionResult Edit(VM viewModel)
        {
            try
            {
                // TODO: Add update logic here
                baseService.Save(viewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Base/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Base/Delete/5

        [HttpPost]
        public ActionResult Delete(VM viewModel)
        {
            try
            {
                // TODO: Add delete logic here
              //  baseService.(viewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
