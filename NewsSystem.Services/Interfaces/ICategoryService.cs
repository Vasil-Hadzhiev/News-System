namespace NewsSystem.Services.Interfaces
{
    using Models.BindingModels.Category;
    using Models.ViewModels.Category;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<CategoriesViewModel> All();

        EditCategoryBindingModel GetEditModel(int id);

        void Create(string name);

        void Delete(int id);

        void Edit(int id, string name);
    }
}