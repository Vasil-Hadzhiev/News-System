namespace NewsSystem.Models.BindingModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateArticleBindingModel
    {
        private const string TitleMinLengthMsg = "Title length must be atleast 3 symbols.";
        private const string ContentMaxLengthMsg = "Content length can't be more than 50 symbols.";

        public CreateArticleBindingModel()
        {
            this.Categories = new List<string>();
        }

        [Required]
        [MinLength(3, ErrorMessage = TitleMinLengthMsg)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        public ICollection<string> Categories { get; set; }
    }
}