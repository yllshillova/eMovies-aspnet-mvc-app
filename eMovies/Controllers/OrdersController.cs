using eMovies.Data.Cart;
using eMovies.Data.Services;
using eMovies.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eMovies.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTtotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
    }
}
