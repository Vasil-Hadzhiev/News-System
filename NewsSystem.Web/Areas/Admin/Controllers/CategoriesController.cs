namespace NewsSystem.Web.Areas.Admin.Controllers
{
    using Models.BindingModels.Category;
    using Models.EntityModels;
    using Models.ViewModels.Category;
    using Web.Attributes;
    using Services;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [CustomAuthorize(Roles = "admin")]
    public class CategoriesController : AdminController
    {
        private readonly CategoryService categories;

        public CategoriesController()
        {
            this.categories = new CategoryService();
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

                return RedirectToAction("All");
            }

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            this.categories.Delete(id);

            return RedirectToAction("All");
        }

        public ActionResult Edit(int id)
        {
            Category category = this.Context.Categories.Find(id);
            if (category == null)
            {
                return this.RedirectToAction("All");
            }

            EditCategoryBindingModel model = new EditCategoryBindingModel
            {
                Name = category.Name
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCategoryBindingModel model)
        {
            this.categories.Edit(model.Id, model.Name);

            return this.RedirectToAction("All");
        }
    }
}