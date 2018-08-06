namespace NewsSystem.Models.BindingModels.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}