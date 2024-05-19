using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resturant.Data;
using Resturant.Models;

namespace Resturant.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly ResturantContext _context;

        public MenuItemsController(ResturantContext context)
        {
            _context = context;
        }

        // GET: MenuItems
        public async Task<IActionResult> Index()
        {
            var resturantContext = _context.MenuItems.Include(m => m.Menus);
            return View(await resturantContext.ToListAsync());
        }

        // GET: MenuItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItems = await _context.MenuItems
                .Include(m => m.Menus)
                .FirstOrDefaultAsync(m => m.MenuItemsId == id);
            if (menuItems == null)
            {
                return NotFound();
            }

            return View(menuItems);
        }

        // GET: MenuItems/Create
        public IActionResult Create()
        { 
         
            ViewData["MenusId"] = new SelectList(_context.Menu, "MenusId", "MenuType");
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuItemsId,Name,Price,MenusId")] MenuItems menuItems)

        {
            if (!ModelState.IsValid)
            {

                foreach (var state in ModelState.Values)
                {
                    foreach (var error in state.Errors)
                    {
                        var errorMessage = error.ErrorMessage;
                        // Log or handle the error message
                        // For example, you can log it to the console
                        Debug.WriteLine($"Error: {errorMessage}");
                    }
                }
            }

                    if (ModelState.IsValid)
                {

                    _context.Add(menuItems);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
       
                ViewData["MenusId"] = new SelectList(_context.Menu, "MenusId", "MenusId", menuItems.MenusId);
                return View(menuItems);
        }

        // GET: MenuItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItems = await _context.MenuItems.FindAsync(id);
            if (menuItems == null)
            {
                return NotFound();
            }
            ViewData["MenusId"] = new SelectList(_context.Menu, "MenusId", "MenusId", menuItems.MenusId);
            return View(menuItems);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuItemsId,Name,Price,MenusId")] MenuItems menuItems)
        {
            if (id != menuItems.MenuItemsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemsExists(menuItems.MenuItemsId))
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
            ViewData["MenusId"] = new SelectList(_context.Menu, "MenusId", "MenusId", menuItems.MenusId);
            return View(menuItems);
        }

        // GET: MenuItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItems = await _context.MenuItems
                .Include(m => m.Menus)
                .FirstOrDefaultAsync(m => m.MenuItemsId == id);
            if (menuItems == null)
            {
                return NotFound();
            }

            return View(menuItems);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuItems = await _context.MenuItems.FindAsync(id);
            if (menuItems != null)
            {
                _context.MenuItems.Remove(menuItems);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuItemsExists(int id)
        {
            return _context.MenuItems.Any(e => e.MenuItemsId == id);
        }
    }
}
