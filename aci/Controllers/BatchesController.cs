using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aci.Models;
using tutorial.Data;

namespace aci.Controllers
{
    public class BatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BatchesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Batches.Include(b => b.Operator).Include(b => b.Order);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.Operator)
                .Include(b => b.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            ViewData["OperatorId"] = new SelectList(_context.Operators, "Id", "Name", batch.OperatorId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Amount", batch.OrderId);
            return View(batch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OperatorId,GoodItems,Expenses,Observations")] Batch batch)
        {
            var currentBatch = await _context.Batches.FindAsync(id);
            if (currentBatch == null)
            {
                return NotFound();
            }
            if (id != batch.Id)
            {
                return NotFound();
            }
            if (batch.OperatorId == null)
            {
                ModelState.AddModelError("Operator", "Operator can not be void");
            }
            if (batch.GoodItems == null || batch.GoodItems > currentBatch.Amount)
            {
                ModelState.AddModelError("GoodItems", "GoodItems can not be more than amount or void");
            }
            if (batch.Expenses == null)
            {
                ModelState.AddModelError("Expenses", "Expenses can not be void");
            }
            if (batch.Observations == null)
            {
                ModelState.AddModelError("Observations", "Observations can not be void");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (currentBatch.GoodItems > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    currentBatch.OperatorId = batch.OperatorId;
                    currentBatch.GoodItems = batch.GoodItems;
                    currentBatch.Expenses = batch.Expenses;
                    currentBatch.Observations = batch.Observations;
                    currentBatch.EndAt = DateTime.Now;
                    currentBatch.BadItems = currentBatch.Amount - batch.GoodItems;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.Id))
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
            ViewData["OperatorId"] = new SelectList(_context.Operators, "Id", "Name", batch.OperatorId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Amount", batch.OrderId);
            return View(batch);
        }
        private bool BatchExists(int id)
        {
            return _context.Batches.Any(e => e.Id == id);
        }
    }
}
