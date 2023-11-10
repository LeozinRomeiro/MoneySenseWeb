using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneySenseWeb.Data;
using MoneySenseWeb.Models.Income;

namespace MoneySenseWeb.Controllers
{
    [Authorize]//Requisitar login para acessar essa controller
    public class IncomeUnexpectedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomeUnexpectedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IncomeUnexpected
        public async Task<IActionResult> Index()
        {
            return _context.IncomeUnexpecteds != null ?
                        View(await _context.IncomeUnexpecteds.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.IncomeUnexpecteds'  is null.");
        }

        // GET: IncomeUnexpected/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IncomeUnexpecteds == null)
            {
                return NotFound();
            }

            var unexpected = await _context.IncomeUnexpecteds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unexpected == null)
            {
                return NotFound();
            }

            return View(unexpected);
        }

        // GET: IncomeUnexpected/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeUnexpected/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Value,CreateAt,UpdateAt")] Unexpected unexpected)
        {
            if (ModelState.IsValid)
            {
                unexpected.UserName = User.Identity.Name;

                _context.Add(unexpected);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unexpected);
        }

        // GET: IncomeUnexpected/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IncomeUnexpecteds == null)
            {
                return NotFound();
            }

            var unexpected = await _context.IncomeUnexpecteds.FindAsync(id);
            if (unexpected == null)
            {
                return NotFound();
            }
            return View(unexpected);
        }

        // POST: IncomeUnexpected/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Value,CreateAt,UserName")] Unexpected unexpected)
        {
            if (id != unexpected.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unexpected.UserName = User.Identity.Name;
                    unexpected.UpdateAt = DateTime.Now;

                    _context.Update(unexpected);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnexpectedExists(unexpected.Id))
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
            return View(unexpected);
        }

        // GET: IncomeUnexpected/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IncomeUnexpecteds == null)
            {
                return NotFound();
            }

            var unexpected = await _context.IncomeUnexpecteds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unexpected == null)
            {
                return NotFound();
            }

            return View(unexpected);
        }

        // POST: IncomeUnexpected/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IncomeUnexpecteds == null)
            {
                return Problem("Entity set 'ApplicationDbContext.IncomeUnexpecteds'  is null.");
            }
            var unexpected = await _context.IncomeUnexpecteds.FindAsync(id);
            if (unexpected != null)
            {
                _context.IncomeUnexpecteds.Remove(unexpected);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnexpectedExists(int id)
        {
            return (_context.IncomeUnexpecteds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
