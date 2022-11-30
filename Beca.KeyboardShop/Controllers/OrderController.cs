using AutoMapper;
using Beca.KeyboardShop.Models;
using Beca.KeyboardShop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace Beca.KeyboardShop.Controllers
{
    [Route("api/orders/")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        private readonly IKeyboardShopRepository _keyboardShopRepository;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;


        // Dependency Injection
        public OrderController(IKeyboardShopRepository repository,
            ILogger<OrderController> logger, IMapper mapper)
        {
            _keyboardShopRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var cartKeyboard = await _keyboardShopRepository.GetOrderAsync(id);
            //pueden existir varias lineas del mismo order
            return Ok(_mapper.Map<CartKeyboardDto>(cartKeyboard));
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> AddOrder(OrderForCreationDto order, ICollection<CartKeyboardForCreationDto> cartKeyboardDtos)
        {
            Console.WriteLine("Almacenando el nuevo order");
            var final_order = _mapper.Map<Entities.Order>(order);
            await _keyboardShopRepository.AddOrderAsync(final_order);

            foreach(var cartKeyboardDto in cartKeyboardDtos)
            {
                //cartKeyboardDto no tiene asignado el orderID
                cartKeyboardDto.OrderId = final_order.Id;
                var final_cart_keyboard = _mapper.Map<Entities.Cart_Keyboards>(cartKeyboardDto);
                await _keyboardShopRepository.AddCartKeyboardAsync(final_cart_keyboard);
            }


            await _keyboardShopRepository.SaveChangesAsync();

            return CreatedAtRoute("GetOrder",
                new
                {
                    id = final_order.Id
                });
        }


    }
}
