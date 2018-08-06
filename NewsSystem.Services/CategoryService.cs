namespace NewsSystem.Services
{
    using Models.EntityModels;
    using NewsSystem.Models.ViewModels.Category;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : Service  
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
            Category category = new Category
            {
                Name = name
            };

            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = this.Context.Categories.Find(id);

            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
        }

        public void Edit(int id, string name)
        {
            Category category = this.Context.Categories.Find(id);

            category.Name = name;

            this.Context.SaveChanges();
        }
    }
}