namespace NewsSystem.Models.BindingModels.Article
{
    using System.ComponentModel.DataAnnotations;

    public class EditArticleBindingModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Category { get; set; }
    }
}