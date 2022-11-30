using AutoMapper;
using Beca.KeyboardShop.Entities;
using Beca.KeyboardShop.Models;
using Beca.KeyboardShop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Beca.KeyboardShop.Controllers
{
    [Route("api/keyboards/")]
    [ApiController]
    public class KeyboardController: ControllerBase
    {
        private readonly IKeyboardShopRepository _keyboardShopRepository;
        private readonly ILogger<KeyboardController> _logger;
        private readonly IMapper _mapper;


        // Dependency Injection
        public KeyboardController(IKeyboardShopRepository repository, 
            ILogger<KeyboardController> logger, IMapper mapper)
        {
            _keyboardShopRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KeyboardDto>>> GetAllKeyboards()
        {
            var keyboards = await _keyboardShopRepository.GetAllKeyboardsAsync();
            return Ok(_mapper.Map<IEnumerable<KeyboardDto>>(keyboards));
        }

        /// <summary>
        /// Get All Keyboards from specific Category ID
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<IEnumerable<KeyboardDto>>> GetAllKeyboardsForCategory(int categoryId)
        {
            if(! await _keyboardShopRepository.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation(
                    $"Category with id {categoryId} wasn't found when accessing keyboards.");
                return NotFound();
            }
            var keyboards = await _keyboardShopRepository
                .GetAllKeyboardsForCategoryAsync(categoryId);

            //Transform keyboard type to KeyboardDto with Automapper
            return Ok(_mapper.Map<IEnumerable<KeyboardDto>>(keyboards));
        }

        /// <summary>
        /// Get Keyboard with specific ID
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="keyboardId"></param>
        /// <returns></returns>
        [HttpGet("{categoryId}/{keyboardId}", Name = "GetKeyboard")]
        public async Task<ActionResult<KeyboardDto>> GetKeyboard(int categoryId, int keyboardId)
        {
            if(! await _keyboardShopRepository.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation(
                    $"Category with id {categoryId} wasn't found when accessing keyboards.");
                return NotFound();
            }

            var keyboard = await _keyboardShopRepository
                .GetKeyboardForCategoryAsync(categoryId, keyboardId);

            if(keyboard == null)
            {
                _logger.LogInformation(
                    $"Keyboard with id {keyboardId} wasn't found.");
                return NotFound();
            }

            return Ok(_mapper.Map<KeyboardDto>(keyboard));
        }

        [HttpPost("{categoryId}")]
        public async Task<ActionResult<KeyboardDto>> CreateKeyboard(int categoryId, KeyboardForCreationDto keyboardForCreationDto)
        {
            if (!await _keyboardShopRepository.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation(
                    $"Category with id {categoryId} wasn't found when accessing keyboards.");
                return NotFound();
            }

            var final_keyboard = _mapper.Map<Entities.Keyboard>(keyboardForCreationDto);

            await _keyboardShopRepository.AddKeyboardForCategoryAsync(categoryId, final_keyboard);

            await _keyboardShopRepository.SaveChangesAsync();

            //Create new object to return
            var keyboardToReturn = _mapper.Map<Entities.Keyboard>(final_keyboard);
            return CreatedAtRoute("GetKeyboard",
                new
                {
                    categoryId = categoryId,
                    keyboardId = keyboardToReturn.Id
                },
                keyboardToReturn);
        }

        [HttpDelete("{categoryId}/{keyboardId}")]
        public async Task<ActionResult> DeleteKeyboard(int categoryId, int keyboardId)
        {
            if (!await _keyboardShopRepository.CategoryExistAsync(categoryId))
            {
                _logger.LogInformation(
                    $"Category with id {categoryId} wasn't found when accessing keyboards.");
                return NotFound();
            }

            var keyboard = await _keyboardShopRepository
                .GetKeyboardForCategoryAsync(categoryId, keyboardId);

            if (keyboard == null)
            {
                _logger.LogInformation(
                    $"Keyboard with id {keyboardId} wasn't found.");
                return NotFound();
            }

            _keyboardShopRepository.DeleteKeyboard(keyboard);
            await _keyboardShopRepository.SaveChangesAsync();

            return NoContent();

        }



    }
}
