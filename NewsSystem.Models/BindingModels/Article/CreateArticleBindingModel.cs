namespace NewsSystem.Models.BindingModels.Article
{
    using System.ComponentModel.DataAnnotations;

    public class CreateArticleBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }
    }
}