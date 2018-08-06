﻿namespace NewsSystem.Web.Areas.Admin.Controllers
{
    using Attributes;
    using Models.BindingModels.Category;
    using Models.ViewModels.Category;
    using Services.Interfaces;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [CustomAuthorize(Roles = "admin")]
    public class CategoriesController : AdminController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public ActionResult All()
        {
            IEnumerable<CategoriesViewModel> allCategories = this.categories.All();

            return this.View(allCategories);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.categories.Create(model.Name);

                return this.RedirectToAllCategories();
            }

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            this.categories.Delete(id);

            return this.RedirectToAllCategories();
        }

        public ActionResult Edit(int id)
        {
            EditCategoryBindingModel model = this.categories.GetEditModel(id);

            if (model == null)
            {
                return this.RedirectToAllCategories();
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCategoryBindingModel model)
        {
            this.categories.Edit(model.Id, model.Name);

            return this.RedirectToAllCategories();
        }
    }
}