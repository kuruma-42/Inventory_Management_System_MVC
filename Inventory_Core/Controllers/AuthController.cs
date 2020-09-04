using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Core.Data;
using Inventory_Core.Models;
using Inventory_Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory_Core.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;


        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            //SELECT TU.Id, TU.UserName, TU.Email,ISNULL(TR.Name, '') AS AuthName
            //FROM AspNetUsers TU
            //LEFT OUTER JOIN AspNetUserRoles TUR ON TU.Id = TUR.UserId
            //LEFT OUTER JOIN AspNetRoles TR ON TUR.RoleId = TR.Id


            var db_data = (from _data0 in _context.Users
                           join _data1 in _context.UserRoles on _data0.Id equals _data1.UserId into join_data1
                           from _data1 in join_data1.DefaultIfEmpty()
                           join _data2 in _context.Roles on _data1.RoleId equals _data2.Id into join_data2
                           from _data2 in join_data2.DefaultIfEmpty()
                           select new AuthViewModel
                           {
                               Id = _data0.Id,
                               UserName = _data0.UserName,
                               Email = _data0.Email,
                               Name = (_data2.Name == null) ? "" : _data2.Name,
                               RoleId = _data2.Id
                           }).ToList();

            ////ViewBag.userdata = db_data.ToList();
            //List<Codes> codes3 = new List<Codes>();
            //codes3 = (from _data_code3 in _context.T00_CODE
            //          where _data_code3.Code_grp.Equals(3)
            //          select _data_code3).ToList();
            //codes3.Insert(0, new Codes { Code = 0, Code_nm = "- Select -" });
            //ViewBag.ListOfCode3 = codes3;
            
            var roles = (from _data1 in _context.Roles
                         select _data1).ToList();

            roles.Insert(0, new IdentityRole { Id = "", Name = "- Select -" });           
            ViewBag.ListOfRoles = roles;


            return View(db_data.ToList());
        }

        public async Task<IActionResult> Auth_Edit()
        {
            //if (ModelState.IsValid)
            //{
                var id = HttpContext.Request.Form["Id"].ToString();
                var username = HttpContext.Request.Form["Username"].ToString();
                var email = HttpContext.Request.Form["Email"].ToString();
                var roleid = HttpContext.Request.Form["RoleId"].ToString();


            if(id == null)
            {
                return NotFound();
            }
            else
            {
                var rData2 = _context.UserRoles.Where(n => n.UserId.Equals(id)).ToList();
                if (rData2.Count > 0)
                {
                    //var ur = await _context.UserRoles.FindAsync(id);
                    //_context.UserRoles.Remove(ur);
                    //await _context.SaveChangesAsync();

                    rData2[0].UserId = id;
                    rData2[0].RoleId = roleid;

                    _context.Update(rData2[0]);
                    await _context.SaveChangesAsync();
                }


                UserRoles aUserRole = new UserRoles();
                aUserRole.UserId = id;
                aUserRole.RoleId = roleid;

                _context.Add(aUserRole);
                await _context.SaveChangesAsync();
            }






            //List<Roles> roles = new List<Roles>();

            //var roles = (from _data1 in _context.Roles
            //              select _data1).ToList();

            //roles.Insert(0, new Roles { Id = , Name = "- Select -" });

            //ViewBag.ListOfRoles = roles;


            //        if (id == "0" /*|| username == "0"*/)
            //        {
            //            ModelState.AddModelError("", "You should join first");
            //            return NotFound();
            //        }
            //        else
            //        {
            //            if (id != null)
            //            {
            //                User user = new User();
            //                devLog.Serial_id = serial_id;
            //                devLog.Site_cd = Convert.ToInt32(site_cd);
            //                devLog.Reg_dt = Convert.ToDateTime(reg_dt);
            //                devLog.Code3 = Convert.ToInt32(code3);
            //                devLog.Code4 = Convert.ToInt32(code4);
            //                devLog.Code5 = Convert.ToInt32(code5);
            //                devLog.Memo1 = memo1;
            //                devLog.Memo2 = memo2;
            //                devLog.Input_id = User.FindFirst(ClaimTypes.Name).Value;
            //                devLog.Update_id = User.FindFirst(ClaimTypes.Name).Value;
            //                devLog.Input_dt = DateTime.Now;
            //                devLog.Update_dt = DateTime.Now;

            //                // Device_Log 저장 한다
            //                _context.Add(devLog);
            //                await _context.SaveChangesAsync();

            //                // Device_Sts 저장 한다
            //                var rData1 = _context.T00_DEVICE_LOG.Where(n => n.Serial_id.Equals(serial_id)).OrderByDescending(n => n.Reg_dt).Take(1).ToList();
            //                var rData2 = _context.T00_DEVICE_STS.Where(n => n.Serial_id.Equals(serial_id)).ToList();

            //                if (rData1.Count > 0)
            //                {

            //                    if (rData2.Count > 0)
            //                    {
            //                        rData2[0].Serial_id = serial_id;
            //                        rData2[0].Site_cd = Convert.ToInt32(site_cd);
            //                        rData2[0].Log_id = rData1[0].Log_id;

            //                        _context.Update(rData2[0]);
            //                        await _context.SaveChangesAsync();
            //                    }
            //                    else
            //                    {
            //                        Device_Sts devSts = new Device_Sts();
            //                        devSts.Serial_id = serial_id;
            //                        devSts.Site_cd = Convert.ToInt32(site_cd);
            //                        devSts.Log_id = rData1[0].Log_id;

            //                        _context.Add(devSts);
            //                        await _context.SaveChangesAsync();
            //                    }
            //                }
            //            }

            //            return RedirectToAction(nameof(Index));
            //        }
            //    }

            //    return RedirectToAction(nameof(Index));
            //}
            return RedirectToAction(nameof(Index));
        }
        }
    }


