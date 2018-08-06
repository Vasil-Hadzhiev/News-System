namespace NewsSystem.Web.Controllers
{
    using Models.ViewModels.Articles;
    using PagedList;
    using Services.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly IArticleService articles;

        public HomeController(IArticleService articles)
        {
            this.articles = articles;
        }

        public ActionResult Index(int? page)
        {
            IEnumerable<ArticlesViewModel> allArticles = this.articles.All();
            IPagedList pagedArticles = allArticles.ToList().ToPagedList(page ?? 1, 5);

            return this.View(pagedArticles);
        }
    }
}