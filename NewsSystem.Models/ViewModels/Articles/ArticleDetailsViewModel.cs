﻿namespace NewsSystem.Models.ViewModels.Articles
{
    public class ArticleDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public int Likes { get; set; }
    }
}