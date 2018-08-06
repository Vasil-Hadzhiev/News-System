namespace NewsSystem.Models.BindingModels.Category
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CreateCategoryBindingModel
    {
        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}