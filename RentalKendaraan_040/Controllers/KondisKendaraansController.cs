using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan_040.Models;

namespace RentalKendaraan_040.Controllers
{
    public class KondisKendaraansController : Controller
    {
        private readonly RentKendaraanContext _context;

        public KondisKendaraansController(RentKendaraanContext context)
        {
            _context = context;
        }

        // GET: KondisKendaraans
        public async Task<IActionResult> Index()
        {
            return View(await _context.KondisKendaraan.ToListAsync());
        }

        // GET: KondisKendaraans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisKendaraan = await _context.KondisKendaraan
                .FirstOrDefaultAsync(m => m.IdKondisi == id);
            if (kondisKendaraan == null)
            {
                return NotFound();
            }

            return View(kondisKendaraan);
        }

        // GET: KondisKendaraans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KondisKendaraans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKondisi,NamaKondisi")] KondisKendaraan kondisKendaraan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kondisKendaraan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kondisKendaraan);
        }

        // GET: KondisKendaraans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisKendaraan = await _context.KondisKendaraan.FindAsync(id);
            if (kondisKendaraan == null)
            {
                return NotFound();
            }
            return View(kondisKendaraan);
        }

        // POST: KondisKendaraans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKondisi,NamaKondisi")] KondisKendaraan kondisKendaraan)
        {
            if (id != kondisKendaraan.IdKondisi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kondisKendaraan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KondisKendaraanExists(kondisKendaraan.IdKondisi))
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
            return View(kondisKendaraan);
        }

        // GET: KondisKendaraans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisKendaraan = await _context.KondisKendaraan
                .FirstOrDefaultAsync(m => m.IdKondisi == id);
            if (kondisKendaraan == null)
            {
                return NotFound();
            }

            return View(kondisKendaraan);
        }

        // POST: KondisKendaraans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kondisKendaraan = await _context.KondisKendaraan.FindAsync(id);
            _context.KondisKendaraan.Remove(kondisKendaraan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KondisKendaraanExists(int id)
        {
            return _context.KondisKendaraan.Any(e => e.IdKondisi == id);
        }
    }
}
