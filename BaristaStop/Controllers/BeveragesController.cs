using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaristaStop.Data;
using BaristaStop.Data.Data;
using BaristaStop.Services.Services.Abstractions;
using BaristaStop.Services.DTOs;
using BaristaStop.Services.Services;

namespace BaristaStop.Web.Controllers
{
    public class BeveragesController : Controller
    {
        private readonly IBeverageService _beverageService;

        public BeveragesController(IBeverageService beverageService)
        {
            _beverageService = beverageService;
        }

        // GET: Beverages
        public async Task<IActionResult> Index()
        {
            return View(await _beverageService.GetAllBeveragesAsync());
        }

        // GET: Beverages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var beverage = await _beverageService.GetBeverageByIdAsync(id.Value);
            if (beverage == null)
            {
                return NotFound();
            }

            return View(beverage);
        }

        // GET: Beverages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beverages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Type,Ingredients,Caffeine,Size,ProductId,Id")] BeverageDTO beverage)
        {
            if (ModelState.IsValid)
            {
                await _beverageService.CreateBeverageAsync(beverage);
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        // GET: Beverages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beverage = await _beverageService.GetBeverageByIdAsync(id.Value);
            if (beverage == null)
            {
                return NotFound();
            }
            return View(beverage);
        }

        // POST: Beverages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Type,Ingredients,Caffeine,Size,ProductId,Id")] BeverageDTO beverage)
        {
            if (id != beverage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _beverageService.UpdateBeverageAsync(beverage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BeverageExists(beverage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        // GET: Beverages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beverage = await _beverageService.GetBeverageByIdAsync(id.Value);
            if (beverage == null)
            {
                return NotFound();
            }

            return View(beverage);
        }

        // POST: Beverages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _beverageService.DeleteBeverageAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BeverageExists(int id)
        {
            return (await _beverageService.GetBeverageByIdAsync(id)) != null;
        }
    }
}
