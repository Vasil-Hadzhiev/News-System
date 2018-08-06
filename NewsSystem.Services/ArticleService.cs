namespace NewsSystem.Services
{
    using Interfaces;
    using NewsSystem.Models.BindingModels.Article;
    using NewsSystem.Models.EntityModels;
    using NewsSystem.Models.ViewModels.Articles;
    using System.Collections.Generic;
    using System.Linq;

    public class ArticleService : Service, IArticleService
    {
        public IEnumerable<ArticlesViewModel> All()
        {
            IEnumerable<ArticlesViewModel> categories = this.Context
                .Articles
                .OrderBy(a => a.Category.Name)
                .ThenByDescending(a => a.Likes.Select(l => l.Value).FirstOrDefault())
                .Select(a => new ArticlesViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Author = a.Author
                });

            return categories;
        }

        public CreateArticleBindingModel GetCreateModel()
        {
            CreateArticleBindingModel model = new CreateArticleBindingModel
            {
                Categories = this.Context
                    .Categories
                    .Select(c => c.Name)
                    .ToList()
            };

            return model;
        }

        public void Create(string title, string content, string category, string author)
        {
            int categoryId = this.Context.Categories
                .FirstOrDefault(c => c.Name == category)
                .Id;

            Article article = new Article
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                Author = author
            };

            this.Context.Articles.Add(article);
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Article article = this.Context.Articles.Find(id);

            this.Context.Articles.Remove(article);
            this.Context.SaveChanges();
        }

        public EditArticleBindingModel GetEditModel(int id)
        {
            Article article = this.Context
                .Articles
                .FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return null;
            }

            string categoryName = this.Context
                .Categories
                .FirstOrDefault(c => c.Id == article.CategoryId)
                .Name;

            List<string> categories = this.Context
                .Categories
                .Select(c => c.Name)
                .ToList();

            EditArticleBindingModel model = new EditArticleBindingModel
            {
                Title = article.Title,
                Category = categoryName,
                Content = article.Content,
                Categories = categories
            };

            return model;
        }

        public void Edit(int id, string title, string content, string category)
        {
            Article article = this.Context.Articles.Find(id);
            int categoryId = this.Context.Categories
                .FirstOrDefault(c => c.Name == category)
                .Id;

            article.Title = title;
            article.Content = content;
            article.CategoryId = categoryId;

            this.Context.SaveChanges();
        }

        public ArticleDetailsViewModel GetDisplayModel(int id)
        {
            Article article = this.Context
                .Articles
                .FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return null;
            }

            string categoryName = this.Context
                .Categories
                .FirstOrDefault(c => c.Id == article.CategoryId)
                .Name;

            Like like = this.Context
                .Likes
                .FirstOrDefault(l => l.ArticleId == article.Id);

            int likes = 0;

            if (like != null)
            {
                likes = like.Value;
            }

            ArticleDetailsViewModel model = new ArticleDetailsViewModel
            {
                Id = article.Id,
                Title = article.Title,
                Category = categoryName,
                Content = article.Content,
                Author = article.Author,
                Likes = likes
            };

            return model;
        }

        public void Like(int id)
        {
            Article article = this.Context
                .Articles
                .Find(id);

            Like like = this.Context
                .Likes
                .FirstOrDefault(l => l.ArticleId == id);

            if (like == null)
            {
                like = new Like
                {
                    Value = 1,
                    ArticleId = id,
                };

                this.Context.Likes.Add(like);
            }
            else
            {
                like.Value++;
            }
      
            this.Context.SaveChanges();
        }
    }
}