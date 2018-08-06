namespace NewsSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Article
    {
        public Article()
        {
            this.Likes = new List<Like>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Author { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}