using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventory_Core.Data;
using Inventory_Core.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Inventory_Core.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, User")]
    public class CodeGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CodeGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CodeGroups
        public async Task<IActionResult> Index()
        {
            var db_data = from _data in _context.T00_CODE_GRP
                              //where !_data.Use_yn.Equals("N")
                          orderby _data.Sort_no, _data.Code_grp
                          select _data;

            return View(await db_data.ToListAsync());

            //return View(await _context.CodeGroup.ToListAsync());
        }

        // GET: CodeGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeGroup = await _context.T00_CODE_GRP
                .FirstOrDefaultAsync(m => m.Code_grp == id);
            if (codeGroup == null)
            {
                return NotFound();
            }

            return View(codeGroup);
        }

        // GET: CodeGroups/Create
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CodeGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code_grp,Code_nm,Sort_no,Use_yn,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] CodeGroup codeGroup)
        {
            codeGroup.Input_dt = DateTime.Now;
            codeGroup.Update_dt = DateTime.Now;
            codeGroup.Input_id = User.FindFirst(ClaimTypes.Name).Value;
            codeGroup.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (ModelState.IsValid)
            {
                _context.Add(codeGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeGroup);
        }

        // GET: CodeGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeGroup = await _context.T00_CODE_GRP.FindAsync(id);
            if (codeGroup == null)
            {
                return NotFound();
            }
            return View(codeGroup);
        }

        // POST: CodeGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code_grp,Code_nm,Sort_no,Use_yn,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] CodeGroup codeGroup)
        {
            codeGroup.Update_dt = DateTime.Now;
            codeGroup.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (id != codeGroup.Code_grp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeGroupExists(codeGroup.Code_grp))
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
            return View(codeGroup);
        }

        // GET: CodeGroups/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeGroup = await _context.T00_CODE_GRP
                .FirstOrDefaultAsync(m => m.Code_grp == id);
            if (codeGroup == null)
            {
                return NotFound();
            }

            return View(codeGroup);
        }

        // POST: CodeGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codeGroup = await _context.T00_CODE_GRP.FindAsync(id);
            _context.T00_CODE_GRP.Remove(codeGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeGroupExists(int id)
        {
            return _context.T00_CODE_GRP.Any(e => e.Code_grp == id);
        }
    }
}
