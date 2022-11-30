using Beca.KeyboardShop.DbContexts;
using Beca.KeyboardShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beca.KeyboardShop.Models.Repositories
{
    public class KeyboardShopRepository : IKeyboardShopRepository
    {
        private readonly KeyboardShopDbContext _context;

        //Dependency Injection
        public KeyboardShopRepository(KeyboardShopDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //Category
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int id, bool includeKeyboards = false)
        {
            if (includeKeyboards)
            {
                return await _context.Categories.Include(c => c.Keyboards)
                    .Where(c => c.Id == id).FirstOrDefaultAsync();
            }
            return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> CategoryExistAsync(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
        public async Task<bool> CategoryExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name);
        }


        public async Task AddCategoryAsync(Category category)
        {
            if (!CategoryExistAsync(category.Name).Result && category != null)
            {
                await _context.Categories.AddAsync(category);
            }
        }

        public void DeleteCategory(Category category)
        {
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }



        //Keyboard
        public async Task<IEnumerable<Keyboard>> GetAllKeyboardsAsync()
        {
            return await _context.Keyboards.OrderBy(c => c.Name).ToListAsync();
        }
        public async Task<IEnumerable<Keyboard>> GetAllKeyboardsForCategoryAsync(int categoryId)
        {
            return await _context.Keyboards.Where(c => c.CategoryId == categoryId).ToListAsync();
        }
        public async Task<Keyboard?> GetKeyboardForCategoryAsync(int categoryId, int keyboardId)
        {
            return await _context.Keyboards.Where(c => c.CategoryId == categoryId)
                .Where(c => c.Id == keyboardId).FirstOrDefaultAsync();
        }
        public async Task AddKeyboardForCategoryAsync(int categoryId, Keyboard keyboard)
        {
            var category = await GetCategoryAsync(categoryId, false);
            if(category != null && keyboard != null)
            {
                category.Keyboards.Add(keyboard);
            }
        }
        public void DeleteKeyboard(Keyboard keyboard)
        {
            if(keyboard != null)
            {
                _context.Keyboards.Remove(keyboard);
            }
        }


        //User
        public async Task<User?> GetUserAsync(int id)
        {
            return await _context.Users.Where(c => c.Id == id).FirstOrDefaultAsync();
        }



        //Save Changes
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }


    }
}
