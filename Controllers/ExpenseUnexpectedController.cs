using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneySenseWeb.Data;
using MoneySenseWeb.Models.Expense;

namespace MoneySenseWeb.Controllers
{
    public class ExpenseUnexpectedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseUnexpectedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExpenseUnexpected
        public async Task<IActionResult> Index()
        {
            return _context.ExpenseUnexpecteds != null ?
                        View(await _context.ExpenseUnexpecteds.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.ExpenseUnexpecteds'  is null.");
        }

        // GET: ExpenseUnexpected/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExpenseUnexpecteds == null)
            {
                return NotFound();
            }

            var unexpected = await _context.ExpenseUnexpecteds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unexpected == null)
            {
                return NotFound();
            }

            return View(unexpected);
        }

        // GET: ExpenseUnexpected/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseUnexpected/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Value,CreateAt,UpdateAt,UserName")] Unexpected unexpected)
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

        // GET: ExpenseUnexpected/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExpenseUnexpecteds == null)
            {
                return NotFound();
            }

            var unexpected = await _context.ExpenseUnexpecteds.FindAsync(id);
            if (unexpected == null)
            {
                return NotFound();
            }
            return View(unexpected);
        }

        // POST: ExpenseUnexpected/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Value,CreateAt,UpdateAt,UserName")] Unexpected unexpected)
        {
            if (id != unexpected.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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

        // GET: ExpenseUnexpected/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExpenseUnexpecteds == null)
            {
                return NotFound();
            }

            var unexpected = await _context.ExpenseUnexpecteds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unexpected == null)
            {
                return NotFound();
            }

            return View(unexpected);
        }

        // POST: ExpenseUnexpected/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExpenseUnexpecteds == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExpenseUnexpecteds'  is null.");
            }
            var unexpected = await _context.ExpenseUnexpecteds.FindAsync(id);
            if (unexpected != null)
            {
                _context.ExpenseUnexpecteds.Remove(unexpected);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnexpectedExists(int id)
        {
            return (_context.ExpenseUnexpecteds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
