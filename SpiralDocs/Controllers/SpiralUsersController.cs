using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpiralDocs.Models;

namespace SpiralDocs.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class SpiralUsersController : Controller
    {
        private readonly FileDbContext _context;

        public SpiralUsersController(FileDbContext context)
        {
            _context = context;
        }

        // GET: SpiralUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpiralUsers.ToListAsync());
        }

        // GET: SpiralUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spiralUser = await _context.SpiralUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spiralUser == null)
            {
                return NotFound();
            }

            return View(spiralUser);
        }

        // GET: SpiralUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpiralUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Pword,Email,Accesslevel,Id,JobTitle,PhoneNumber")] SpiralUser spiralUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spiralUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spiralUser);
        }

        // GET: SpiralUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spiralUser = await _context.SpiralUsers.FindAsync(id);
            if (spiralUser == null)
            {
                return NotFound();
            }
            return View(spiralUser);
        }

        // POST: SpiralUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Pword,Email,Accesslevel,Id,JobTitle,PhoneNumber")] SpiralUser spiralUser)
        {
            if (id != spiralUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spiralUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpiralUserExists(spiralUser.Id))
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
            return View(spiralUser);
        }

        // GET: SpiralUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spiralUser = await _context.SpiralUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spiralUser == null)
            {
                return NotFound();
            }

            return View(spiralUser);
        }

        // POST: SpiralUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spiralUser = await _context.SpiralUsers.FindAsync(id);
            _context.SpiralUsers.Remove(spiralUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpiralUserExists(int id)
        {
            return _context.SpiralUsers.Any(e => e.Id == id);
        }
    }
}
