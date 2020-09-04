using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Core.Data;
using Inventory_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory_Core.Controllers
{
    public class WorkStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ws_Search()
        {

            var reg_date1 = HttpContext.Request.Form["Reg_dt1"].ToString();
            var reg_date2 = HttpContext.Request.Form["Reg_dt2"].ToString();
            var regdate1 = reg_date1.Replace("-", "");
            var regdate2 = reg_date2.Replace("-", "");
            //SELECT USER_ID, TITLE, CONTENTS, DEL_FLAG, INPUT_DT, REG_DATE
            //FROM T01_WORKDIARY
            //WHERE DEL_FLAG = 0;&& REG_DATE >= (Parameter) && REG_DATE >= (Parameter)
            //ORDER BY REG_DATE DESCENDING , INPUT_DT

            if (reg_date1 != "" && reg_date2 != "")
            {
                List<WorkDiary> db_data = new List<WorkDiary>();
                db_data = (from _data0 in _context.T01_WORKDIARY
                           where _data0.Reg_date >= Convert.ToInt32(regdate1) && _data0.Reg_date <= Convert.ToInt32(regdate2) && _data0.Del_flag != 1
                           select new WorkDiary
                           {
                               User_id = _data0.User_id,
                               Title = _data0.Title,
                               Del_flag = _data0.Del_flag,
                               Input_dt = _data0.Input_dt,
                               Reg_date = _data0.Reg_date,
                               Contents = _data0.Contents
                           }).ToList();

                ViewBag.WsSearch = db_data;

                return View(db_data);
            }

            else
            {
                return RedirectToAction(nameof(Error));
            }

            //return View(db_data);

            //ViewBag.WsSearch = db_data;


        }

        public IActionResult Error()
        {

            return View();
        }


    }
}

   