using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_praktikum.Models;

namespace UCP1_praktikum.Controllers
{
    public class PenduduksController : Controller
    {
        private readonly KelurahanContext _context;

        public PenduduksController(KelurahanContext context)
        {
            _context = context;
        }

        // GET: Penduduks
        public async Task<IActionResult> Index()
        {
            var kelurahanContext = _context.Penduduk.Include(p => p.IdGenderNavigation).Include(p => p.IdStatusNavigation);
            return View(await kelurahanContext.ToListAsync());
        }

        // GET: Penduduks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penduduk = await _context.Penduduk
                .Include(p => p.IdGenderNavigation)
                .Include(p => p.IdStatusNavigation)
                .FirstOrDefaultAsync(m => m.IdData == id);
            if (penduduk == null)
            {
                return NotFound();
            }

            return View(penduduk);
        }

        // GET: Penduduks/Create
        public IActionResult Create()
        {
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender");
            ViewData["IdStatus"] = new SelectList(_context.Status, "IdStatus", "IdStatus");
            return View();
        }

        // POST: Penduduks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdData,Nama,NamaDusun,NoKk,Alamat,IdGender,IdStatus")] Penduduk penduduk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penduduk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", penduduk.IdGender);
            ViewData["IdStatus"] = new SelectList(_context.Status, "IdStatus", "IdStatus", penduduk.IdStatus);
            return View(penduduk);
        }

        // GET: Penduduks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penduduk = await _context.Penduduk.FindAsync(id);
            if (penduduk == null)
            {
                return NotFound();
            }
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", penduduk.IdGender);
            ViewData["IdStatus"] = new SelectList(_context.Status, "IdStatus", "IdStatus", penduduk.IdStatus);
            return View(penduduk);
        }

        // POST: Penduduks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdData,Nama,NamaDusun,NoKk,Alamat,IdGender,IdStatus")] Penduduk penduduk)
        {
            if (id != penduduk.IdData)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penduduk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PendudukExists(penduduk.IdData))
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
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", penduduk.IdGender);
            ViewData["IdStatus"] = new SelectList(_context.Status, "IdStatus", "IdStatus", penduduk.IdStatus);
            return View(penduduk);
        }

        // GET: Penduduks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penduduk = await _context.Penduduk
                .Include(p => p.IdGenderNavigation)
                .Include(p => p.IdStatusNavigation)
                .FirstOrDefaultAsync(m => m.IdData == id);
            if (penduduk == null)
            {
                return NotFound();
            }

            return View(penduduk);
        }

        // POST: Penduduks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penduduk = await _context.Penduduk.FindAsync(id);
            _context.Penduduk.Remove(penduduk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PendudukExists(int id)
        {
            return _context.Penduduk.Any(e => e.IdData == id);
        }
    }
}
