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
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class WorkDiaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkDiaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> WorkDiary()
        {
            var sum1 = DateTime.Now.ToString("yyyyMM") + "01";
            var sum2 = DateTime.Now.AddMonths(1).ToString("yyyyMM") + "01";

            List<WorkDiary> db_data = new List<WorkDiary>();
            db_data = (from _data0 in _context.T01_WORKDIARY
                       where _data0.Reg_date >= (int.Parse(sum1)) && _data0.Reg_date < (int.Parse(sum2)) && _data0.Del_flag != 1
                       orderby _data0.Reg_date descending, _data0.Input_dt descending
                       select new WorkDiary
                       {
                           Wd_id = _data0.Wd_id,
                           Reg_date = _data0.Reg_date,
                           User_id = _data0.User_id,
                           Title = _data0.Title,
                           Contents = _data0.Contents,
                           Input_dt = _data0.Input_dt,
                           Update_dt = _data0.Update_dt
                       }).ToList();

            var reg_dt = await _context.T01_WORKDIARY
               .FirstOrDefaultAsync(m => m.Reg_date >= Convert.ToInt32(sum1) && m.Reg_date < Convert.ToInt32(sum2));
            if (reg_dt is null)
            {
                return View(db_data);
            }
            var reg_dt2 = Convert.ToString(reg_dt.Reg_date);
            var reg_dt_month = reg_dt2.Substring(4, 2);
            ViewData["reg_dt"] = reg_dt_month;
            return View(db_data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WorkDiary(int x)
        {
            var year = HttpContext.Request.Form["year"];
            var month = HttpContext.Request.Form["month"].ToString();

            if (month.Length == 1)
            {
                month = "0" + month;
            }
            string sum1 = year.ToString() + month.ToString() + "01";
            var month1 = (Convert.ToInt16(month) + 1).ToString();
            if (month1.Length == 1)
            {
                month1 = "0" + month1;
            }
            string sum2 = year.ToString() + month1.ToString() + "01";
            List<WorkDiary> db_data = new List<WorkDiary>();
            db_data = (from _data in _context.T01_WORKDIARY
                       where _data.Reg_date >= (int.Parse(sum1)) && _data.Reg_date < (int.Parse(sum2)) && _data.Del_flag != 1
                       orderby _data.Reg_date descending, _data.Input_dt descending
                       select _data).ToList();

            var reg_dt = await _context.T01_WORKDIARY
                .FirstOrDefaultAsync(m => m.Reg_date >= Convert.ToInt32(sum1) && m.Reg_date < Convert.ToInt32(sum2));
            if(reg_dt is null)
            {
                return View(db_data);
            }
                var reg_dt2 = Convert.ToString(reg_dt.Reg_date);
                var reg_dt_month = reg_dt2.Substring(4, 2);
                ViewData["reg_dt"] = reg_dt_month;
           
            return View(db_data);
        }

        public async Task<IActionResult> WorkDiary_Write()
        {
            //DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            //var site = new WorkDiary { Reg_date = dateTime };
            //return View(site);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> WorkDiary_Write([Bind("Reg_date,User_id,Title,Contents,Del_flag,Input_dt,Update_dt")] WorkDiary workDiary)
        public async Task<IActionResult> WorkDiary_Write(int i)
        {
            if (ModelState.IsValid)
            {
                WorkDiary workDiary = new WorkDiary();
                workDiary.User_id = User.FindFirst(ClaimTypes.Name).Value;
                workDiary.Reg_date = int.Parse(HttpContext.Request.Form["Reg_date"].ToString().Replace("-", ""));
                workDiary.Title = HttpContext.Request.Form["Title"];
                workDiary.Contents = HttpContext.Request.Form["Contents"];
                workDiary.Del_flag = byte.Parse("0");
                workDiary.Input_dt = DateTime.Now;
                workDiary.Update_dt = DateTime.Now;

                // Device_Log 저장 한다
                _context.Update(workDiary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(WorkDiary));
            }
            return View();
        }

        public async Task<IActionResult> WorkDiary_Content(int? Wd_id)
        {
            List<WorkDiary> db_data = new List<WorkDiary>();
            db_data = (from _data in _context.T01_WORKDIARY
                       where _data.Wd_id.Equals(Wd_id)
                       select _data).ToList();
            ViewBag.WorkDiary = db_data;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> WorkDiary_Content(int? Wd_id,int i)
        public async Task<IActionResult> WorkDiary_Content(int i)
        {
            if (HttpContext.Request.Form["action"] == "수정")
            {
                if (ModelState.IsValid)
                {
                    var wd_id = HttpContext.Request.Form["Wd_id"].ToString();
                    var input_dt = HttpContext.Request.Form["Input_dt"].ToString();
                    //var update_dt = HttpContext.Request.Form["Update_dt"].ToString();
                    WorkDiary workDiary = new WorkDiary();
                    workDiary.Wd_id = Convert.ToInt32(wd_id);
                    workDiary.User_id = User.FindFirst(ClaimTypes.Name).Value;
                    workDiary.Reg_date = int.Parse(HttpContext.Request.Form["Reg_date"].ToString().Replace("-", ""));
                    workDiary.Title = HttpContext.Request.Form["Title"];
                    workDiary.Contents = HttpContext.Request.Form["Contents"];
                    workDiary.Del_flag = byte.Parse("0");
                    workDiary.Input_dt = Convert.ToDateTime(input_dt);
                    workDiary.Update_dt = DateTime.Now;

                    // Device_Log 저장 한다
                    _context.Update(workDiary);
                    await _context.SaveChangesAsync();

                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var wd_id = HttpContext.Request.Form["Wd_id"].ToString();
                    WorkDiary workDiary = new WorkDiary();
                    workDiary.Wd_id = Convert.ToInt32(wd_id);
                    workDiary.User_id = User.FindFirst(ClaimTypes.Name).Value;
                    workDiary.Reg_date = int.Parse(HttpContext.Request.Form["Reg_date"].ToString().Replace("-", ""));
                    workDiary.Title = HttpContext.Request.Form["Title"];
                    workDiary.Contents = HttpContext.Request.Form["Contents"];
                    workDiary.Del_flag = byte.Parse("1");
                    workDiary.Input_dt = DateTime.Now;
                    workDiary.Update_dt = DateTime.Now;

                    _context.Update(workDiary);
                    await _context.SaveChangesAsync();

                }
            }
            return RedirectToAction(nameof(WorkDiary));
        }


    }
}