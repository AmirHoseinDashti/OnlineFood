using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Online_food.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Online_food.Data;
using Online_food.Data.Repositories;
using ZarinpalSandbox;

namespace Online_food.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private OnlineFoodContext _context;

        public HomeController(ILogger<HomeController> logger, OnlineFoodContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products
                .Include(p => p.Item)
                .ToList();

            var category = _context.Categories
                .Include(p => p.CategoryToProducts)
                .ToList();

            var model = new ProductandCategory()
            {
                Products = products,
                Categories = category
            };

            return View(model);
        }

        public IActionResult Details(int Id)
        {
            var product = _context.Products
                .Include(p => p.Item)
                .SingleOrDefault(p => p.Id == Id);

            if (product == null)
            {
                return NotFound();
            }

            var categories = _context.Products
                .Where(p => p.Id == Id)
                .SelectMany(c => c.CategoryToProducts)
                .Select(ca => ca.Category)
                .ToList();

            var group = new GroupViewModel()
            {
                Product = product,
                Categories = categories
            };
            return PartialView(group);
        }

        [Route("Menu")]
        public IActionResult Menu()
        {
            var products = _context.Products
                .Include(p => p.Item)
                .ToList();

            var category = _context.Categories
                .Include(p => p.CategoryToProducts)
                .ToList();

            var model = new ProductandCategory()
            {
                Products = products,
                Categories = category
            };

            return View(model);
        }

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemId);
            if (product != null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
                if (order != null)
                {
                    var orderDetail =
                        _context.OrderDetails.FirstOrDefault(d =>
                            d.OrderId == order.OrderId && d.ProductId == product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.OrderDetails.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Item.Price,
                            Count = 1
                        });
                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinaly = false,
                        CreateDate = DateTime.Now,
                        UserId = userId
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    _context.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }

                _context.SaveChanges();
            }

            return RedirectToAction("ShowCart");
        }

        [Authorize]
        [Route("ShowCart")]
        public IActionResult ShowCart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.Where(o => o.UserId == userId && !o.IsFinaly)
                .Include(o => o.OrderDetails)
                .ThenInclude(c => c.Product).FirstOrDefault();
            return View(order);
        }

        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {
            var orderDetalis = _context.OrderDetails.Find(detailId);
            _context.Remove(orderDetalis);
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public IActionResult addNewItem(int detailId)
        {
            var orderDetalis = _context.OrderDetails.Find(detailId);
            orderDetalis.Count += 1;
            _context.Update(orderDetalis);
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }


        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [Route("About")]
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Payment()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
            if (order == null)
                return NotFound();

            var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
            var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order.OrderId}",
                "https://localhost:44343/Home/OnlinePayment/" + order.OrderId);
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _context.Orders.Include(o => o.OrderDetails)
                    .FirstOrDefault(o => o.OrderId == id);
                var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsFinaly = true;
                    _context.Orders.Update(order);
                    _context.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }
            }

            return NotFound();
        }
    }
}
