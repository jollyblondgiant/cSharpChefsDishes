using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChefsDishes.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefDishContext dbContext;
        public HomeController(ChefDishContext context)
        {
            dbContext = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> ChefList = dbContext.Chefs
            .Include(c=>c.ChefsDishes)
            .ToList();
            
            
            return View(ChefList);
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> DishList = dbContext.Dishes
            .Include(dish => dish.Creator)
            .ToList();
            return View(DishList);
        }

        [HttpGet("new")]
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpPost("new")]
        public IActionResult NewChef(Chef newChef)
        {
            
            if(DateTime.Today.Year-newChef.DOB.Year < 18)
            {
                ModelState.AddModelError("DOB", "Must be 18!");
            }
            if(ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddChef");
        }
        
        [HttpGet("dishes/new")]
        public IActionResult AddDish()
        {
            List<Chef> ChefList = dbContext.Chefs.ToList();
            ViewBag.ChefList = ChefList;

            return View();
        }

        [HttpPost("dishes/new")]
        public IActionResult NewDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                
                System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                System.Console.WriteLine(newDish.CreatorID);
                
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            List<Chef> ChefList = dbContext.Chefs.ToList();
            ViewBag.ChefList = ChefList;
            return View("AddDish");
        }
    }
}
