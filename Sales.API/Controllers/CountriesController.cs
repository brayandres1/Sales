﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entites;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase  
    {
        private readonly DataContext _context;
        public CountriesController(DataContext contex)
        {
            _context = contex;
        }

        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

    }
}