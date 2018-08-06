namespace NewsSystem.Services.Interfaces
{
    using Models.BindingModels.Article;
    using Models.ViewModels.Articles;
    using System.Collections.Generic;

    public interface IArticleService
    {
        IEnumerable<ArticlesViewModel> All();

        CreateArticleBindingModel GetCreateModel();

        EditArticleBindingModel GetEditModel(int id);

        ArticleDetailsViewModel GetDisplayModel(int id);

        void Create(string title, string content, string category, string author);

        void Delete(int id);
       
        void Edit(int id, string title, string content, string category);      

        void Like(int id);
    }
}