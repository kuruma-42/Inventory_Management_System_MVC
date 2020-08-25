using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory_Core.Data;
using Inventory_Core.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ReflectionIT.Mvc.Paging;

namespace Inventory_Core.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, User")]
    public class SiteGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public SiteGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SiteGroups
        public async Task<IActionResult> Index(int page = 1)
        {
            //return View(await _context.T00_MEMCO.Where(u => !u.Del_yn.Equals("N")).OrderBy(u => u.Sort_no).ToListAsync());

            //return View(await _context.T00_MEMCO.ToListAsync());

            var db_data = from _data in _context.T00_MEMCO
                          //where !_data.Use_yn.Equals("N")
                          orderby _data.Sort_no, _data.Memco_nm
                          select _data;

           return View(await db_data.ToListAsync());
        }

        // GET: SiteGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteGroup = await _context.T00_MEMCO
                .FirstOrDefaultAsync(m => m.Memco_cd == id);
            if (siteGroup == null)
            {
                return NotFound();
            }

            return View(siteGroup);
        }

        // GET: SiteGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SiteGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Memco_cd,Memco_nm,Sort_no,Use_yn,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] SiteGroup siteGroup)
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userName = User.FindFirstValue(ClaimTypes.Name);
            //var userEmail = User.FindFirstValue(ClaimTypes.Email);

            siteGroup.Input_dt = DateTime.Now;
            siteGroup.Update_dt = DateTime.Now;
            siteGroup.Input_id = User.FindFirst(ClaimTypes.Name).Value;
            siteGroup.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (ModelState.IsValid)
            {
                _context.Add(siteGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteGroup);
        }

        // GET: SiteGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteGroup = await _context.T00_MEMCO.FindAsync(id);
            if (siteGroup == null)
            {
                return NotFound();
            }
            return View(siteGroup);
        }

        // POST: SiteGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Memco_cd,Memco_nm,Sort_no,Use_yn,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] SiteGroup siteGroup)
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userName = User.FindFirstValue(ClaimTypes.Name);
            //var userEmail = User.FindFirstValue(ClaimTypes.Email);

            siteGroup.Update_dt = DateTime.Now;
            siteGroup.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (id != siteGroup.Memco_cd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siteGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteGroupExists(siteGroup.Memco_cd))
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
            return View(siteGroup);
        }

        // GET: SiteGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteGroup = await _context.T00_MEMCO
                .FirstOrDefaultAsync(m => m.Memco_cd == id);
            if (siteGroup == null)
            {
                return NotFound();
            }

            return View(siteGroup);
        }

        // POST: SiteGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siteGroup = await _context.T00_MEMCO.FindAsync(id);
            _context.T00_MEMCO.Remove(siteGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteGroupExists(int id)
        {
            return _context.T00_MEMCO.Any(e => e.Memco_cd == id);
        }
    }
}
