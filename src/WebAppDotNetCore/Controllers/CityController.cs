using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppDotNetCore.Data;
using Microsoft.EntityFrameworkCore;
using WebAppDotNetCore.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppDotNetCore.Controllers
{
    public class CityController : Controller
    {
        private readonly CityContext _context;

        public CityController(CityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cityInfo = await _context.City.ToListAsync();
            return View(cityInfo);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.SingleOrDefaultAsync(m => m.ID == id);

            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.SingleOrDefaultAsync(m => m.ID == id);

            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(CityInfo cityInfo)
        {
            if (cityInfo == null)
            {
                return NotFound();
            }            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    
                }
                return RedirectToAction("Index");
            }
            return View(cityInfo);
        }
    }
}
