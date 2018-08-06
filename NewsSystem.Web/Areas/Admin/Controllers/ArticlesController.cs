namespace NewsSystem.Web.Areas.Admin.Controllers
{
    using Models.BindingModels.Article;
    using Models.EntityModels;
    using Models.ViewModels.Articles;
    using NewsSystem.Web.Attributes;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class ArticlesController : AdminController
    {
        private readonly ArticleService articles;

        public ArticlesController()
        {
            this.articles = new ArticleService();
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
            ViewBag.Categories = this.Context
                .Categories
                .Select(c => c.Name)
                .ToList();

            return this.View();
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

                return RedirectToAction("All");
            }

            return this.View(model);
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            this.articles.Delete(id);

            return RedirectToAction("All");
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Article article = this.Context
                .Articles
                .FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return this.RedirectToAction("All");
            }

            string categoryName = this.Context
                .Categories
                .FirstOrDefault(c => c.Id == article.CategoryId)
                .Name;

            ViewBag.Categories = this.Context
                .Categories
                .Select(c => c.Name)
                .ToList();

            EditArticleBindingModel model = new EditArticleBindingModel
            {
                Title = article.Title,
                Category = categoryName,
                Content = article.Content
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(EditArticleBindingModel model)
        {
            this.articles.Edit(model.Id, model.Title, model.Content, model.Category);

            return this.RedirectToAction("All");
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            ArticleDetailsViewModel model = this.articles.DisplayModel(id);

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