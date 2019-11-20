using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{

    public class ShopController : Controller
    {
        
        
        MovieStoreContext db = new MovieStoreContext();
        public List<Products> products = new List<Products>();

        public List<Cart> cart = new List<Cart>();

       

        decimal SubTotal = 0;
        decimal SalesTax = 0;
        decimal Total = 0;

        public IActionResult Index()
        {
            List<Products> products = db.Products.ToList();

            return View(products.ToList());

        }

   

        public IActionResult Buy(int id)
        {
           
            Products p = db.Products.Find(id);

            if (p != null)
            {
           // AddtoCart(id);

                return View(p);
            }

            else
            {

                RedirectToAction("ConfirmBuy", "Shop");
            }
            return View();
        }


     
 
        public List<Cart> AddtoCart(int id)
        {

            Products p = db.Products.Find(id);

            cart.Add(new Cart { Item =p.Name, Cost =p.Price });
       

            return cart; 
        }

        public IActionResult ConfirmBuy(int id, string UserName)
        {
            Products p = db.Products.Find(id);
            Users u = db.Users.Find(UserName);
            if (40>= p.Price)
            {
                ViewBag.Receipt = "You have Enough Balance to buy. Proceed to pay";
                return RedirectToAction(nameof(Receipt));
            }

            else
            {
                ViewBag.Receipt = "You DO NOT have Enough Balance to buy.";
                return RedirectToAction(nameof(Receipt));

            }

        }
        public IActionResult Receipt()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Receipt(int id, string UserName)
        {

            return View();
        

        }

        //[HttpGet]
        //public IActionResult Receipt()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Receipt(Cart newTask)
        //{

        //    string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    newTask.Item = id;
        //    _context.Add(newTask);
        //    _context.SaveChanges();
        //    return RedirectToAction("Receipt");
        //}

        //  [HttpPost]
        //public List<Cart> AddtoCart(int id)
        //{
        //    // List<Cart> cart = new List<Cart>();
        //    Products p = db.Products.Find(id);


        //    string item = p.Name;
        //    decimal price = Convert.ToDecimal(p.Price);
           
        //    //_context.Add(item, price);
        //    //_context.SaveChanges();
        //  cart.Add(new Cart { Item = item, Cost = price });

        //    SubTotal = cart.Sum(cart => cart.Cost);
        //    //ViewBag["SubTotal"] = SubTotal;

        //    return cart;


       // }

        public decimal GetSubtotal()
        {
         
             SubTotal = cart.Sum(cart => cart.Cost);
            //ViewBag["SubTotal"] = SubTotal;
            ViewBag["SubTotal"] = SubTotal;
            return SubTotal;

        }

        public decimal GetTaxes()
        {
            decimal Sales =Convert.ToDecimal( 0.07);
           // SubTotal = GetSubtotal();
             SalesTax = SubTotal * Sales;


            return SalesTax;

        }
        public decimal GetTotal()
        {
             SubTotal = GetSubtotal();
             SalesTax = GetTaxes();
             Total = SubTotal + SalesTax;
            ViewBag["SubTotal"] = SubTotal;
            ViewBag.Total = Total;
            return Total;

        }

   
        //public IActionResult Receipt()
        //{
        
        //return View(cart.ToList());


        //}






    }
}