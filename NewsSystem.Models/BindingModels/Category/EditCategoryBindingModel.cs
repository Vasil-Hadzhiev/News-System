namespace NewsSystem.Models.BindingModels.Category
{
    using System.ComponentModel.DataAnnotations;

    public class EditCategoryBindingModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}