using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PARCIAL2_RuaJhonattan.DAL;
using PARCIAL2_RuaJhonattan.DAL.Entities;

namespace PARCIAL2_RuaJhonattan.Controllers
{
    public class PersonaNaturalsController : Controller
    {
        private readonly DataBaseContext _context;

        public PersonaNaturalsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: PersonaNaturals
        public async Task<IActionResult> Index()
        {
              return _context.PersonaNaturals != null ? 
                          View(await _context.PersonaNaturals.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.PersonaNaturals'  is null.");
        }

        // GET: PersonaNaturals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PersonaNaturals == null)
            {
                return NotFound();
            }

            var personaNatural = await _context.PersonaNaturals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaNatural == null)
            {
                return NotFound();
            }

            return View(personaNatural);
        }

        // GET: PersonaNaturals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonaNaturals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Email,BirthYear,Age,Id,CreatedDate,ModiedDate")] PersonaNatural personaNatural)
        {
            if (ModelState.IsValid)
            {
                personaNatural.Id = Guid.NewGuid();
                _context.Add(personaNatural);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personaNatural);
        }

        // GET: PersonaNaturals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PersonaNaturals == null)
            {
                return NotFound();
            }

            var personaNatural = await _context.PersonaNaturals.FindAsync(id);
            if (personaNatural == null)
            {
                return NotFound();
            }
            return View(personaNatural);
        }

        // POST: PersonaNaturals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FullName,Email,BirthYear,Age,Id,CreatedDate,ModiedDate")] PersonaNatural personaNatural)
        {
            if (id != personaNatural.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    
                    _context.Update(personaNatural);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaNaturalExists(personaNatural.Id))
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
            return View(personaNatural);
        }

        // GET: PersonaNaturals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PersonaNaturals == null)
            {
                return NotFound();
            }

            var personaNatural = await _context.PersonaNaturals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaNatural == null)
            {
                return NotFound();
            }

            return View(personaNatural);
        }

        // POST: PersonaNaturals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PersonaNaturals == null)
            {
                return Problem("Entity set 'DataBaseContext.PersonaNaturals'  is null.");
            }
            var personaNatural = await _context.PersonaNaturals.FindAsync(id);
            if (personaNatural != null)
            {
                _context.PersonaNaturals.Remove(personaNatural);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaNaturalExists(Guid id)
        {
          return (_context.PersonaNaturals?.Any(e => e.Id == id)).GetValueOrDefault();
        }

       

    }
}
