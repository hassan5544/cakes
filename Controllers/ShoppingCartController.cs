using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cakes.Models;
using cakes.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cakes.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pirRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository , ShoppingCart shoppingCart)
        {
            _pirRepository = pieRepository;
            _shoppingCart = shoppingCart;
        } 
        // GET: /<controller>/
        public ViewResult index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var ShoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };
            

            return View(ShoppingCartViewModel);
        }
        public RedirectToActionResult AddShoppingCart(int pieId)
        {
            var SelectedPie = _pirRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (SelectedPie !=null)
            {
                _shoppingCart.AddToCart(SelectedPie, 1);
            }
            return RedirectToAction("index");
        }

        public RedirectToActionResult RemoveFromShoppingCart (int pieId)
        {
            var SelectedPie = _pirRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (SelectedPie != null)
            {
                _shoppingCart.RemoveFromCart(SelectedPie);
            }
            return RedirectToAction("index");
        }

    }
}
