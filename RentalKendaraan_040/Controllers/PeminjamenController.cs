﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan_040.Models;

namespace RentalKendaraan_040.Controllers
{
    public class PeminjamenController : Controller
    {
        private readonly RentKendaraanContext _context;

        public PeminjamenController(RentKendaraanContext context)
        {
            _context = context;
        }

        // GET: Peminjamen
        public async Task<IActionResult> Index()
        {
            var rentKendaraanContext = _context.Peminjaman.Include(p => p.IdCustomerNavigation).Include(p => p.IdPeminjamam1).Include(p => p.IdPeminjamamNavigation);
            return View(await rentKendaraanContext.ToListAsync());
        }

        // GET: Peminjamen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjaman
                .Include(p => p.IdCustomerNavigation)
                .Include(p => p.IdPeminjamam1)
                .Include(p => p.IdPeminjamamNavigation)
                .FirstOrDefaultAsync(m => m.IdPeminjamam == id);
            if (peminjaman == null)
            {
                return NotFound();
            }

            return View(peminjaman);
        }

        // GET: Peminjamen/Create
        public IActionResult Create()
        {
            ViewData["IdCustomer"] = new SelectList(_context.Jaminan, "IdJaminan", "IdJaminan");
            ViewData["IdPeminjamam"] = new SelectList(_context.Kendaraan, "IdKendaraan", "IdKendaraan");
            ViewData["IdPeminjamam"] = new SelectList(_context.Customer, "IdCustomer", "IdCustomer");
            return View();
        }

        // POST: Peminjamen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeminjamam,TglPeminjaman,IdKendaraan,IdCustomer,IdJaminan,Biaya")] Peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peminjaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCustomer"] = new SelectList(_context.Jaminan, "IdJaminan", "IdJaminan", peminjaman.IdCustomer);
            ViewData["IdPeminjamam"] = new SelectList(_context.Kendaraan, "IdKendaraan", "IdKendaraan", peminjaman.IdPeminjamam);
            ViewData["IdPeminjamam"] = new SelectList(_context.Customer, "IdCustomer", "IdCustomer", peminjaman.IdPeminjamam);
            return View(peminjaman);
        }

        // GET: Peminjamen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null)
            {
                return NotFound();
            }
            ViewData["IdCustomer"] = new SelectList(_context.Jaminan, "IdJaminan", "IdJaminan", peminjaman.IdCustomer);
            ViewData["IdPeminjamam"] = new SelectList(_context.Kendaraan, "IdKendaraan", "IdKendaraan", peminjaman.IdPeminjamam);
            ViewData["IdPeminjamam"] = new SelectList(_context.Customer, "IdCustomer", "IdCustomer", peminjaman.IdPeminjamam);
            return View(peminjaman);
        }

        // POST: Peminjamen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeminjamam,TglPeminjaman,IdKendaraan,IdCustomer,IdJaminan,Biaya")] Peminjaman peminjaman)
        {
            if (id != peminjaman.IdPeminjamam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peminjaman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeminjamanExists(peminjaman.IdPeminjamam))
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
            ViewData["IdCustomer"] = new SelectList(_context.Jaminan, "IdJaminan", "IdJaminan", peminjaman.IdCustomer);
            ViewData["IdPeminjamam"] = new SelectList(_context.Kendaraan, "IdKendaraan", "IdKendaraan", peminjaman.IdPeminjamam);
            ViewData["IdPeminjamam"] = new SelectList(_context.Customer, "IdCustomer", "IdCustomer", peminjaman.IdPeminjamam);
            return View(peminjaman);
        }

        // GET: Peminjamen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjaman
                .Include(p => p.IdCustomerNavigation)
                .Include(p => p.IdPeminjamam1)
                .Include(p => p.IdPeminjamamNavigation)
                .FirstOrDefaultAsync(m => m.IdPeminjamam == id);
            if (peminjaman == null)
            {
                return NotFound();
            }

            return View(peminjaman);
        }

        // POST: Peminjamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            _context.Peminjaman.Remove(peminjaman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeminjamanExists(int id)
        {
            return _context.Peminjaman.Any(e => e.IdPeminjamam == id);
        }
    }
}
