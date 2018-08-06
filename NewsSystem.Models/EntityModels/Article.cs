namespace NewsSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Article
    {
        private const string TitleMinLengthMsg = "Title length must be atleast 3 symbols.";
        private const string ContentMaxLengthMsg = "Content length can't be more than 50 symbols.";

        public Article()
        {
            this.Likes = new List<Like>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = TitleMinLengthMsg)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = ContentMaxLengthMsg)]
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Author { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}