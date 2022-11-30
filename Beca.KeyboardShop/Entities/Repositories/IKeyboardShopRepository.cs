using Beca.KeyboardShop.Entities;

namespace Beca.KeyboardShop.Models.Repositories
{
    public interface IKeyboardShopRepository
    {
        //Keyboard
        Task<IEnumerable<Keyboard>> GetAllKeyboardsAsync();
        Task<IEnumerable<Keyboard>> GetAllKeyboardsForCategoryAsync(int categoryId);
        Task<Keyboard?> GetKeyboardForCategoryAsync(int categoryId, int keyboardId);
        Task AddKeyboardForCategoryAsync(int categoryId, Keyboard keyboard);
        void DeleteKeyboard(Keyboard keyboard);

        //Category
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryAsync(int id, bool includeKeyboards);
        Task<bool> CategoryExistAsync(int id);
        Task<bool> CategoryExistAsync(string name);
        Task AddCategoryAsync(Category category);
        void DeleteCategory(Category category);


        //User
        Task<User?> GetUserAsync(int userId);

        //Save
        Task<bool> SaveChangesAsync();
    }
}
