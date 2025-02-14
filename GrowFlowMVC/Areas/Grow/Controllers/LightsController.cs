using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrowFlowMVC;
using GrowFlowMVC.Controllers;
using GrowFlow.Models.Equipment;

namespace GrowFlowMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class LightsController : BaseController
    {
        public LightsController(GrowFlowContext context) : base(context){ }

        public async Task<IActionResult> Index()
        {
            var lights = await db.Lights.Include(l => l.Room).ToListAsync();
           
            return View(lights);
        }

        public async Task<IActionResult> Details(int? id)
        {
            return await GetLight(id, "_Details");
        }

        public IActionResult Create()
        {
            ViewData["RoomID"] = new SelectList(db.Rooms, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PPF,PPFD,BulbType,ColorSpectrum,CoverageAreaSF,LifespanHours,Manufacturer,Voltage,Price,RoomID,Active")] Light light)
        {
            if (ModelState.IsValid)
            {
                db.Add(light);
               
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["RoomID"] = new SelectList(db.Rooms, "ID", "Name", light.RoomID);
            return View(light);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            return await GetLight(id, "_Edit");
    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PPF,PPFD,BulbType,ColorSpectrum,CoverageAreaSF,LifespanHours,Manufacturer,Voltage,Price,RoomID,Active")] Light light)
        {
            if (id != light.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(light);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LightExists(light.ID))
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
            ViewData["RoomID"] = new SelectList(db.Rooms, "ID", "Name", light.RoomID);
            return View(light);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return await GetLight(id, "_Delete");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var light = await db.Lights.FindAsync(id);
            
            if (light != null)
            {
                db.Lights.Remove(light);
            }

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> GetLight(int? id, string view)
        {
            if (id == null)
            {
                return NotFound();
            }
            var light = await db.Lights.Include(l => l.Room).FirstOrDefaultAsync(m => m.ID == id);

            if (light == null)
            {
                return NotFound();
            }

            ViewData["RoomID"] = view == "_Edit" ? new SelectList(db.Rooms, "ID", "Name", light.RoomID) : null;

            return PartialView(view, light);
        }

        private bool LightExists(int id)
        {
            return db.Lights.Any(e => e.ID == id);
        }
    }
}
