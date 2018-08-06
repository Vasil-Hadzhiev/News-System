namespace NewsSystem.Web.Areas.Admin.Controllers
{
    using Data;
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        public AdminController()
        {
            this.Context = new NewsSystemDbContext();
        }

        public NewsSystemDbContext Context { get; set; }

        public ActionResult RedirectToAllArticles() => this.RedirectToAction("All", "Articles");

        public ActionResult RedirectToAllCategories() => this.RedirectToAction("All", "Categories");
    }
}