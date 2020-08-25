using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory_Core.Data;
using Inventory_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Inventory_Core.ViewModels;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Inventory_Core.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, User")]
    public class SitesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index(int? memco_cd)
        {
            var db_data = from _data in _context.T00_SITE
                              where _data.Memco_cd.Equals(memco_cd)
                          orderby _data.Sort_no, _data.Site_nm
                          select _data;

            var db_data2 = _context.T00_MEMCO.SingleOrDefault(u=>u.Memco_cd.Equals(memco_cd));

            ViewData["Memco_nm"] = db_data2.Memco_nm;
            ViewData["Memco_cd"] = memco_cd;

            return View(await db_data.ToListAsync());

            //return View(await _context.T00_SITE.ToListAsync());
        }

        // GET: Sites
        public async Task<IActionResult> Index1(int? id)
        {
            var db_data = from _data in _context.T00_MEMCO
                          join _data2 in _context.T00_SITE on _data.Memco_cd equals _data2.Memco_cd //into _joinData
                          where _data.Memco_cd.Equals(id)
                          //from _data2 in _joinData.DefaultIfEmpty()
                          orderby _data2.Sort_no, _data2.Site_nm
                          select new SiteViewModel
                          {
                              Memco_nm = _data.Memco_nm,
                              Site_cd = _data2.Site_cd,
                              Memco_cd = _data2.Memco_cd,
                              Site_nm = _data2.Site_nm,
                              Res_nm1 = _data2.Res_nm1,
                              Tel_no1 = _data2.Tel_no1,
                              Res_nm2 = _data2.Res_nm2,
                              Tel_no2 = _data2.Tel_no2,
                              Eldigm_res_nm = _data2.Eldigm_res_nm,
                              Address = _data2.Address,
                              Sort_no = _data2.Sort_no,
                              Use_yn = _data2.Use_yn,
                              Start_dt = _data2.Start_dt,
                              End_dt = _data2.End_dt,
                              Memo1 = _data2.Memo1,
                              Memo2 = _data2.Memo2,
                              Input_dt = _data2.Input_dt,
                              Update_dt = _data2.Update_dt,
                              Input_id = _data2.Input_id,
                              Update_id = _data2.Update_id
                          };


            return View(await db_data.ToListAsync());
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["CodeList"] = _context.T00_CODE
                .Where(n => n.Code_grp.Equals(1))
                .Select(n => new SelectListItem { Value = n.Code.ToString(), Text = n.Code_nm }).ToList();

            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.T00_SITE
                .FirstOrDefaultAsync(m => m.Site_cd == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create(int? memco_cd)
        {
            ViewData["Memco_cd"] = memco_cd;
            ViewData["CodeList"] = _context.T00_CODE
                .Where(n=>n.Code_grp.Equals(1) && n.Use_yn.Equals("Y"))
                .Select(n => new SelectListItem { Value = n.Code.ToString(), Text = n.Code_nm }).ToList();

            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            var site = new Site { Start_dt = dateTime, End_dt = dateTime.AddYears(10), Code1=0 };
            return View(site);
        }

        // POST: Sites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Site_cd,Memco_cd,Site_nm,Res_nm1,Tel_no1,Res_nm2,Tel_no2,Eldigm_res_nm,Address,Sort_no,Use_yn,Start_dt,End_dt,Code1,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] Site site)
        {
            site.Input_dt = DateTime.Now;
            site.Update_dt = DateTime.Now;
            site.Input_id = User.FindFirst(ClaimTypes.Name).Value;
            site.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { memco_cd = site.Memco_cd });
            }
            return View(site);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["CodeList"] = _context.T00_CODE
                .Where(n => n.Code_grp.Equals(1))
                .Select(n => new SelectListItem { Value = n.Code.ToString(), Text = n.Code_nm }).ToList();

            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.T00_SITE.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Site_cd,Memco_cd,Site_nm,Res_nm1,Tel_no1,Res_nm2,Tel_no2,Eldigm_res_nm,Address,Sort_no,Use_yn,Start_dt,End_dt,Code1,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] Site site)
        {
            site.Update_dt = DateTime.Now;
            site.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (id != site.Site_cd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.Site_cd))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { memco_cd = site.Memco_cd });
            }
            return View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["CodeList"] = _context.T00_CODE
                .Where(n => n.Code_grp.Equals(1))
                .Select(n => new SelectListItem { Value = n.Code.ToString(), Text = n.Code_nm }).ToList();

            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.T00_SITE
                .FirstOrDefaultAsync(m => m.Site_cd == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.T00_SITE.FindAsync(id);
            _context.T00_SITE.Remove(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { memco_cd = site.Memco_cd });
        }

        private bool SiteExists(int id)
        {
            return _context.T00_SITE.Any(e => e.Site_cd == id);
        }
    }
}
