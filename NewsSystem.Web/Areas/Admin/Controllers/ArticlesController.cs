namespace NewsSystem.Web.Areas.Admin.Controllers
{
    using Attributes;
    using Models.BindingModels.Article;
    using Models.ViewModels.Articles;
    using Services.Interfaces;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ArticlesController : AdminController
    {
        private readonly IArticleService articles;

        public ArticlesController(IArticleService articles)
        {
            this.articles = articles;
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult All()
        {
            IEnumerable<ArticlesViewModel> allArticles = this.articles.All();

            return this.View(allArticles);
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Create()
        {
            CreateArticleBindingModel model = this.articles.GetCreateModel();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Create(CreateArticleBindingModel model)
        {
            string author = this.User.Identity.Name;

            if (this.ModelState.IsValid)
            {
                this.articles.Create(model.Title, model.Content, model.Category, author);

                return this.RedirectToAllArticles();
            }

            return this.View(model);
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            this.articles.Delete(id);

            return this.RedirectToAllArticles();
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            EditArticleBindingModel model = this.articles.GetEditModel(id);

            if (model == null)
            {
                return this.RedirectToAllArticles();
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(EditArticleBindingModel model)
        {
            this.articles.Edit(model.Id, model.Title, model.Content, model.Category);

            return this.RedirectToAllArticles();
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            ArticleDetailsViewModel model = this.articles.GetDisplayModel(id);

            return this.View(model);
        }


        [Authorize]
        public ActionResult Like(int id)
        {
            this.articles.Like(id);
            return this.RedirectToAction("Details", new { id });
        }
    }
}