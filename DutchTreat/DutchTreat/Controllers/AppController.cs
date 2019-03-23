﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Models;
using DutchTreat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
       // public readonly IMailService _mailService;
        private readonly IDutchRepository _repository;
       

        public AppController( IDutchRepository repository)
        {
          //  _mailService = mailService;
            _repository = repository;
            
        }

        public IActionResult Index()
        {
           
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
           
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // send message
                //_mailService.SendMessage("EmailAddress", model.Subject, $"From:{model.Name} - {model.Email}, Message: {model.Message}");

                //ViewBag.UserMessage = "mail sent";

                //ModelState.Clear();
            }
          

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        [Authorize]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();

            return View(results);
        }
    }
}