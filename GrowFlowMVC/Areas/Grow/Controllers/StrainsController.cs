using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrowFlow.Models.Grow;
using GrowFlowMVC;
using GrowFlowMVC.Controllers;
using AspNetCoreGeneratedDocument;

namespace GrowFlowMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class StrainsController : BaseController
    {
        public StrainsController(GrowFlowContext context) : base(context) { }

        public async Task<IActionResult> Index()
        {
            return View(await db.Strains.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            return await GetStrain(id, "_Details");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,StrainType")] Strain strain)
        {
            if (ModelState.IsValid)
            {
                db.Add(strain);

                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(strain);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return await GetStrain(id, "_Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,StrainType")] Strain strain)
        {
            if (id != strain.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(strain);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StrainExists(strain.ID))
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
            return View(strain);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return await GetStrain(id, "_Delete");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var strain = await db.Strains.FindAsync(id);
            if (strain != null)
            {
                db.Strains.Remove(strain);
            }

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> GetStrain(int? id, string view)
        {
            if (id == null)
            {
                return NotFound();
            }
            var strain = await db.Strains.FirstOrDefaultAsync(m => m.ID == id);

            if (strain == null)
            {
                return NotFound();
            }

            return PartialView(view, strain);
        }

        private bool StrainExists(int id)
        {
            return db.Strains.Any(e => e.ID == id);
        }
    }
}
