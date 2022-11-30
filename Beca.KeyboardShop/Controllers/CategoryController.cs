using AutoMapper;
using Beca.KeyboardShop.Entities;
using Beca.KeyboardShop.Models;
using Beca.KeyboardShop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Beca.KeyboardShop.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly IKeyboardShopRepository _keyboardShopRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IKeyboardShopRepository keyboardShopRepository,
            IMapper mapper, ILogger<CategoryController> logger)
        {
            _keyboardShopRepository = keyboardShopRepository ??
                throw new ArgumentNullException(nameof(keyboardShopRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            return Ok(await _keyboardShopRepository.GetAllCategoriesAsync());
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryForCreationDto categoryForCreation)
        {
            if(await _keyboardShopRepository.CategoryExistAsync(categoryForCreation.Name))
            {
                _logger.LogInformation(
                    $"Category with name {categoryForCreation.Name} already exists. Please create one with different name");
                return BadRequest();
            }
            var final_category = _mapper.Map<Entities.Category>(categoryForCreation);

            await _keyboardShopRepository.AddCategoryAsync(final_category);
            await _keyboardShopRepository.SaveChangesAsync();

            //Category to return in the response
            var categoryToReturn = _mapper.Map<CategoryDto>(final_category);
            return Ok(categoryToReturn);

        }

        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            var category = await _keyboardShopRepository.GetCategoryAsync(categoryId, false);
            if (category == null)
            {
                _logger.LogInformation(
                    $"Category with id {categoryId} wasn't found when accessing keyboards.");
                return NotFound();
            }

            _keyboardShopRepository.DeleteCategory(category);
            await _keyboardShopRepository.SaveChangesAsync();

            return NoContent();
        }


        //[HttpGet("{categoryId}")]
        //public async Task<ActionResult<CategoryDto>> GetCategory(int categoryId)
        //{
        //    if (!await _keyboardShopRepository.CategoryExistAsync(categoryId))
        //    {
        //        _logger.LogInformation(
        //            $"Category with id {categoryId} wasn't found when accessing keyboards.");
        //        return NotFound();
        //    }

        //    return Ok()
        //}

    }
}
