namespace NewsSystem.Web.Controllers
{
    using Models.ViewModels.Articles;
    using PagedList;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly ArticleService articles;

        public HomeController()
        {
            this.articles = new ArticleService();
        }

        public ActionResult Index(int? page)
        {
            IEnumerable<ArticlesViewModel> allArticles = this.articles.All();
            IPagedList pagedArticles = allArticles.ToList().ToPagedList(page ?? 1, 5);

            return this.View(pagedArticles);
        }
    }
}