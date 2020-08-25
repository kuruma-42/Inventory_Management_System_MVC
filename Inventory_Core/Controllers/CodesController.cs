using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventory_Core.Data;
using Inventory_Core.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Inventory_Core.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CodesController : Controller
    {
        private readonly ApplicationDbContext _context;


        public CodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Codes
        public async Task<IActionResult> Index(int? code_grp)
        {
            var db_data = from _data in _context.T00_CODE
                          where _data.Code_grp.Equals(code_grp)
                          orderby _data.Sort_no, _data.Code_nm
                          select _data;

            var db_data2 = _context.T00_CODE_GRP.SingleOrDefault(u => u.Code_grp.Equals(code_grp));

            ViewData["Code_nm_grp"] = db_data2.Code_nm;
            ViewData["Code_grp"] = code_grp;

            return View(await db_data.ToListAsync());

            //return View(await _context.T00_CODE.ToListAsync());
        }

        // GET: Codes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codes = await _context.T00_CODE
                .FirstOrDefaultAsync(m => m.Code == id);
            if (codes == null)
            {
                return NotFound();
            }

            return View(codes);
        }

        // GET: Codes/Create
        public IActionResult Create(int? code_grp)
        {
            ViewData["Code_grp"] = code_grp;

            return View();
        }

        // POST: Codes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Code_grp,Code_nm,Sort_no,Use_yn,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] Codes codes)
        {
            codes.Input_dt = DateTime.Now;
            codes.Update_dt = DateTime.Now;
            codes.Input_id = User.FindFirst(ClaimTypes.Name).Value;
            codes.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (ModelState.IsValid)
            {
                _context.Add(codes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { code_grp = codes.Code_grp });
            }
            return View(codes);
        }

        // GET: Codes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codes = await _context.T00_CODE.FindAsync(id);
            if (codes == null)
            {
                return NotFound();
            }
            return View(codes);
        }

        // POST: Codes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Code_grp,Code_nm,Sort_no,Use_yn,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] Codes codes)
        {
            codes.Update_dt = DateTime.Now;
            codes.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (id != codes.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodesExists(codes.Code))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { code_grp = codes.Code_grp });
            }
            return View(codes);
        }

        // GET: Codes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codes = await _context.T00_CODE
                .FirstOrDefaultAsync(m => m.Code == id);
            if (codes == null)
            {
                return NotFound();
            }

            return View(codes);
        }

        // POST: Codes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codes = await _context.T00_CODE.FindAsync(id);
            _context.T00_CODE.Remove(codes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { code_grp = codes.Code_grp });
        }

        private bool CodesExists(int id)
        {
            return _context.T00_CODE.Any(e => e.Code == id);
        }
    }
}
