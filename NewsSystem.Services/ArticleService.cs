﻿namespace NewsSystem.Services
{
    using NewsSystem.Models.EntityModels;
    using NewsSystem.Models.ViewModels.Articles;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArticleService : Service
    {
        public IEnumerable<ArticlesViewModel> All()
        {
            IEnumerable<ArticlesViewModel> categories = this.Context
                .Articles
                .OrderBy(a => a.Category.Name)
                .Select(a => new ArticlesViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Author = a.Author
                });

            return categories;
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

        public ArticleDetailsViewModel DisplayModel(int id)
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