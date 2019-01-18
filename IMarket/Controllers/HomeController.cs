﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMarket.BusinessLogic.Services.Abstracts;
using IMarket.Models;

namespace IMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStockService _stockService;

        public HomeController(IStockService stockService)
        {
            _stockService = stockService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStock()
        {
            var model = new StockViewModel
            {
                Items = _stockService.GetProducts(),
                ItemsCount = _stockService.GetCountOfItemsInStock()
            };
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}