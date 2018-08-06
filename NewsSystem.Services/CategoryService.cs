namespace NewsSystem.Services
{
    using Interfaces;
    using Models.BindingModels.Category;
    using Models.EntityModels;
    using Models.ViewModels.Category;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : Service, ICategoryService
    {
        public IEnumerable<CategoriesViewModel> All()
        {
            IEnumerable<CategoriesViewModel> categories = this.Context
                .Categories
                .Select(c => new CategoriesViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return categories;
        }

        public void Create(string name)
        {
            bool exists = this.Context
                .Categories
                .Any(c => c.Name == name);

            if (!exists)
            {
                Category category = new Category
                {
                    Name = name
                };

                this.Context.Categories.Add(category);
                this.Context.SaveChanges();
            }         
        }

        public void Delete(int id)
        {
            Category category = this.Context.Categories.Find(id);

            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
        }

        public EditCategoryBindingModel GetEditModel(int id)
        {
            Category category = this.Context
                .Categories
                .FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return null;
            }

            EditCategoryBindingModel model = new EditCategoryBindingModel
            {
                Name = category.Name
            };

            return model;
        }

        public void Edit(int id, string name)
        {
            Category category = this.Context.Categories.Find(id);

            category.Name = name;

            this.Context.SaveChanges();
        }
    }
}