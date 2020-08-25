using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory_Core.Data;
using Inventory_Core.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inventory_Core.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Inventory_Core.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, User")]
    public class DevicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Devices
        public IActionResult Index()
        {
            // 현장 그룹
            List<SiteGroup> siteGroups = new List<SiteGroup>();
            siteGroups = (from _data1 in _context.T00_MEMCO
                          select _data1).ToList();
            siteGroups.Insert(0, new SiteGroup { Memco_cd = 0, Memco_nm = "- Select -" });
            ViewBag.ListOfSiteGroup = siteGroups;

            // 코드3
            List<Codes> codes2 = new List<Codes>();
            codes2 = (from _data_code2 in _context.T00_CODE
                      where _data_code2.Code_grp.Equals(2)
                      orderby _data_code2.Sort_no
                      select _data_code2).ToList();
            codes2.Insert(0, new Codes { Code = 0, Code_nm = "- Select -" });
            ViewBag.ListOfCode2 = codes2;

            return View();
        }

        // GET: Devices
        public async Task<IActionResult> Index_search()
        {
            //var db_data = from _data in _context.T00_DEVICE
            //                  //where !_data.Use_yn.Equals("N")
            //              orderby _data.Input_dt descending
            //              select _data;


            // 현장 그룹
            List<SiteGroup> siteGroups = new List<SiteGroup>();
            siteGroups = (from _data1 in _context.T00_MEMCO
                          select _data1).ToList();
            siteGroups.Insert(0, new SiteGroup { Memco_cd = 0, Memco_nm = "- Select -" });
            ViewBag.ListOfSiteGroup = siteGroups;

            // 기준일자
            string dateTime = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            ViewBag.DataOfReg_dt = dateTime;

            // 코드3
            List<Codes> codes3 = new List<Codes>();
            codes3 = (from _data_code3 in _context.T00_CODE
                      where _data_code3.Code_grp.Equals(3)
                      orderby _data_code3.Sort_no
                      select _data_code3).ToList();
            codes3.Insert(0, new Codes { Code = 0, Code_nm = "- Select -" });
            ViewBag.ListOfCode3 = codes3;

            // 코드4
            List<Codes> codes4 = new List<Codes>();
            codes4 = (from _data_code4 in _context.T00_CODE
                      where _data_code4.Code_grp.Equals(4)
                      orderby _data_code4.Sort_no
                      select _data_code4).ToList();
            codes4.Insert(0, new Codes { Code = 0, Code_nm = "- Select -" });
            ViewBag.ListOfCode4 = codes4;

            // 코드5
            List<Codes> codes5 = new List<Codes>();
            codes5 = (from _data_code5 in _context.T00_CODE
                      where _data_code5.Code_grp.Equals(5)
                      orderby _data_code5.Sort_no
                      select _data_code5).ToList();
            codes5.Insert(0, new Codes { Code = 0, Code_nm = "- Select -" });
            ViewBag.ListOfCode5 = codes5;



            // 검색 조건 넘어온것
            var f_code2 = HttpContext.Request.Form["F_Code2"].ToString();
            var f_serial_id = HttpContext.Request.Form["F_Serial_id"].ToString();
            var f_sub_id = HttpContext.Request.Form["F_Sub_id"].ToString();
            var f_memco_cd = HttpContext.Request.Form["F_Memco_cd"].ToString();
            var f_site_cd = HttpContext.Request.Form["F_Site_cd"].ToString();



            var db_data = from _data in _context.T00_DEVICE
                          join _data2 in _context.T00_CODE on _data.Code2 equals _data2.Code into _joinData
                          from _data2 in _joinData.DefaultIfEmpty()
                          join _data_devSts in _context.T00_DEVICE_STS on _data.Serial_id equals _data_devSts.Serial_id into _joinData_devSts
                          from _data_devSts in _joinData_devSts.DefaultIfEmpty()
                          join _data_Site in _context.T00_SITE on _data_devSts.Site_cd equals _data_Site.Site_cd into _joinData_site
                          from _data_Site in _joinData_site.DefaultIfEmpty()
                          join _data_Memco in _context.T00_MEMCO on _data_Site.Memco_cd equals _data_Memco.Memco_cd into _joinData_memco
                          from _data_Memco in _joinData_memco.DefaultIfEmpty()
                          orderby _data.Input_dt descending, _data.Serial_id descending
                          select new DeviceViewModel
                          {
                              Chk_val = false,
                              Serial_id = _data.Serial_id,
                              Code2 = _data.Code2,
                              Code2_nm = _data2.Code_nm,
                              Sub_id = _data.Sub_id,
                              Use_yn = _data.Use_yn,
                              Memo1 = _data.Memo1,
                              Memo2 = _data.Memo2,
                              Input_dt = _data.Input_dt,
                              Update_dt = _data.Update_dt,
                              Input_id = _data.Input_id,
                              Update_id = _data.Update_id,
                              Site_cd = _data_Site.Site_cd.ToString() == null ? 0 : (Int32)_data_Site.Site_cd,
                              Site_nm = _data_Site.Site_nm,
                              Memco_cd = _data_Memco.Memco_cd.ToString() == null ? 0 : (Int32)_data_Memco.Memco_cd,
                              Memco_nm = _data_Memco.Memco_nm
                          };
            // 검색 조건
            if (f_code2 != "0")
            {
                db_data = db_data.Where(e => e.Code2.Equals(Convert.ToInt32(f_code2)));
            }
            if (f_serial_id != "")
            {
                db_data = db_data.Where(e => e.Serial_id.IndexOf(f_serial_id) >= 0);
            }
            if (f_sub_id != "")
            {
                db_data = db_data.Where(e => e.Sub_id.IndexOf(f_sub_id) >= 0);
            }
            if (f_memco_cd != "0")
            {
                db_data = db_data.Where(e => e.Memco_cd.Equals(Convert.ToInt32(f_memco_cd)));
            }
            if (f_site_cd != "0")
            {
                db_data = db_data.Where(e => e.Site_cd.Equals(Convert.ToInt32(f_site_cd)));
            }

            return View(await db_data.ToListAsync());


            //return View(await _context.T00_DEVICE.ToListAsync());
        }

        // GET: Devices
        public async Task<IActionResult> Index1()
        {
            //var db_data = from _data in _context.T00_DEVICE
            //                  //where !_data.Use_yn.Equals("N")
            //              orderby _data.Input_dt descending
            //              select _data;
            var db_data = from _data in _context.T00_DEVICE
                          join _data2 in _context.T00_CODE on _data.Code2 equals _data2.Code into _joinData
                          from _data3 in _joinData.DefaultIfEmpty()
                          join _data_devSts in _context.T00_DEVICE_STS on _data.Serial_id equals _data_devSts.Serial_id into _joinData_devSts
                          from _data4 in _joinData_devSts.DefaultIfEmpty()
                          join _data_Site in _context.T00_SITE on _data4.Site_cd equals _data_Site.Site_cd into _joinData_site
                          from _data5 in _joinData_site.DefaultIfEmpty()
                          join _data_Memco in _context.T00_MEMCO on _data5.Memco_cd equals _data_Memco.Memco_cd into _joinData_memco
                          from _data6 in _joinData_memco.DefaultIfEmpty()
                          orderby _data.Input_dt descending
                          select new DeviceViewModel
                          {
                              Chk_val = true,
                              Serial_id = _data.Serial_id,
                              Code2 = _data.Code2,
                              Code2_nm = _data3.Code_nm,
                              Sub_id = _data.Sub_id,
                              Use_yn = _data.Use_yn,
                              Memo1 = _data.Memo1,
                              Memo2 = _data.Memo2,
                              Input_dt = _data.Input_dt,
                              Update_dt = _data.Update_dt,
                              Input_id = _data.Input_id,
                              Update_id = _data.Update_id,
                              Site_cd = _data4.Site_cd,
                              Site_nm = _data5.Site_nm,
                              Memco_cd = _data6.Memco_cd,
                              Memco_nm = _data6.Memco_nm
                          };

            return View(await db_data.ToListAsync());
            //return View(await _context.T00_DEVICE.ToListAsync());
        }

        // GET: Devices
        public async Task<IActionResult> Index11()
        {
            List<SiteGroup> siteGroups = new List<SiteGroup>();
            siteGroups = (from _data1 in _context.T00_MEMCO
                          select _data1).ToList();

            siteGroups.Insert(0, new SiteGroup { Memco_cd = 0, Memco_nm = "- Select -" });

            ViewBag.ListofSiteGroup = siteGroups;

            //var db_data = new DeviceViewModel_List()
            //{
            //    Result = new List<DeviceViewModel>()
            //    {
            //        new DeviceViewModel{
            //                  Chk_val = true,
            //                  Serial_id = "1",
            //                  Code2 = 1,
            //                  Code2_nm = "11",
            //                  Sub_id = "a1",
            //                  Use_yn = "Y",
            //                  Memo1 = "",
            //                  Memo2 = "",
            //                  Input_dt = DateTime.Now,
            //                  Update_dt = DateTime.Now,
            //                  Input_id = "111",
            //                  Update_id = "111" },
            //        new DeviceViewModel{
            //                  Chk_val = true,
            //                  Serial_id = "2",
            //                  Code2 = 2,
            //                  Code2_nm = "22",
            //                  Sub_id = "b2",
            //                  Use_yn = "Y",
            //                  Memo1 = "",
            //                  Memo2 = "",
            //                  Input_dt = DateTime.Now,
            //                  Update_dt = DateTime.Now,
            //                  Input_id = "222",
            //                  Update_id = "222" }
            //    }
            //};

            //return View(db_data);

            var db_data = from _data in _context.T00_DEVICE
                          join _data2 in _context.T00_CODE on _data.Code2 equals _data2.Code into _joinData
                          from _data3 in _joinData.DefaultIfEmpty()
                          orderby _data.Input_dt descending
                          select new DeviceViewModel
                          {
                              Chk_val = true,
                              Serial_id = _data.Serial_id,
                              Code2 = _data.Code2,
                              Code2_nm = _data3.Code_nm,
                              Sub_id = _data.Sub_id,
                              Use_yn = _data.Use_yn,
                              Memo1 = _data.Memo1,
                              Memo2 = _data.Memo2,
                              Input_dt = _data.Input_dt,
                              Update_dt = _data.Update_dt,
                              Input_id = _data.Input_id,
                              Update_id = _data.Update_id,
                              Memco_cd = 0,
                              Memco_nm = "",
                              Site_cd = 0,
                              Site_nm = ""
                          };

            DeviceViewModel_List dev = new DeviceViewModel_List();
            dev.Result = db_data.ToList();

            return View(dev);
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            ViewData["CodeList"] = _context.T00_CODE
                .Where(n => n.Code_grp.Equals(2))
                .Select(n => new SelectListItem { Value = n.Code.ToString(), Text = n.Code_nm }).ToList();

            if (id == null)
            {
                return NotFound();
            }

            var devices = await _context.T00_DEVICE
                .FirstOrDefaultAsync(m => m.Serial_id == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["CodeList"] = _context.T00_CODE
                .Where(n => n.Code_grp.Equals(2) && n.Use_yn.Equals("Y"))
                .Select(n => new SelectListItem { Value = n.Code.ToString(), Text = n.Code_nm }).ToList();

            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Serial_id,Code2,Sub_id,Use_yn,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] Devices devices)
        {
            devices.Input_dt = DateTime.Now;
            devices.Update_dt = DateTime.Now;
            devices.Input_id = User.FindFirst(ClaimTypes.Name).Value;
            devices.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (ModelState.IsValid)
            {
                _context.Add(devices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(devices);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["CodeList"] = _context.T00_CODE
                .Where(n => n.Code_grp.Equals(2))
                .Select(n => new SelectListItem { Value = n.Code.ToString(), Text = n.Code_nm }).ToList();

            if (id == null)
            {
                return NotFound();
            }

            var devices = await _context.T00_DEVICE.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }
            return View(devices);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Serial_id,Code2,Sub_id,Use_yn,Memo1,Memo2,Input_dt,Update_dt,Input_id,Update_id")] Devices devices)
        {
            devices.Update_dt = DateTime.Now;
            devices.Update_id = User.FindFirst(ClaimTypes.Name).Value;

            if (id != devices.Serial_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevicesExists(devices.Serial_id))
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
            return View(devices);
        }

        public async Task<IActionResult> History(string id)
        {
            List<Details_logViewModel> device_data = new List<Details_logViewModel>();
            device_data = (from _data in _context.T00_DEVICE
                           join _data2 in _context.T00_CODE on _data.Code2 equals _data2.Code
                           where _data.Serial_id.Equals(id)
                           select new Details_logViewModel
                           {
                               Serial_id = _data.Serial_id,
                               Sub_id = _data.Sub_id,
                               Code_nm = _data2.Code_nm
                           }).ToList();

            ViewBag.devicedata = device_data;

            if (id == null)
            {
                NotFound();
            }

            var db_data = from _data in _context.T00_DEVICE_LOG
                          join _data2 in _context.T00_SITE on _data.Site_cd equals _data2.Site_cd
                          where _data.Serial_id.Equals(id)
                          orderby _data.Reg_dt descending
                          select new HistoryViewModel
                          {
                              Serial_id = _data.Serial_id,
                              Code2 = _data.Site_cd,
                              Sub_id = _data.Log_id,
                              Reg_dt = _data.Reg_dt,
                              Site_nm = _data2.Site_nm,
                              Input_id = _data.Input_id
                          };

            return View(await db_data.ToListAsync());
        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            ViewData["CodeList"] = _context.T00_CODE
                .Where(n => n.Code_grp.Equals(2))
                .Select(n => new SelectListItem { Value = n.Code.ToString(), Text = n.Code_nm }).ToList();

            if (id == null)
            {
                return NotFound();
            }

            var devices = await _context.T00_DEVICE
                .FirstOrDefaultAsync(m => m.Serial_id == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var devices = await _context.T00_DEVICE.FindAsync(id);
            _context.T00_DEVICE.Remove(devices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevicesExists(string id)
        {
            return _context.T00_DEVICE.Any(e => e.Serial_id == id);
        }


        public JsonResult GetSite(int Memco_cd)
        {
            List<Site> sites = new List<Site>();
            sites = (from _data in _context.T00_SITE
                     where _data.Memco_cd.Equals(Memco_cd)
                     select _data).ToList();

            sites.Insert(0, new Site { Site_cd = 0, Site_nm = "- Select -" });

            return Json(new SelectList(sites, "Site_cd", "Site_nm"));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult GoAddSite([Bind(Prefix = "Sub_id")] string[] sub_id)
        public async Task<IActionResult> GoAddSite(List<DeviceViewModel> devices)
        {
            if (ModelState.IsValid)
            {
                var memco_cd = HttpContext.Request.Form["Memco_cd"].ToString();
                var site_cd = HttpContext.Request.Form["Site_cd"].ToString();
                var reg_dt = HttpContext.Request.Form["Reg_dt"].ToString();
                var code3 = HttpContext.Request.Form["Code3"].ToString();
                var code4 = HttpContext.Request.Form["Code4"].ToString();
                var code5 = HttpContext.Request.Form["Code5"].ToString();
                var memo1 = HttpContext.Request.Form["Memo1"].ToString();
                var memo2 = HttpContext.Request.Form["Memo2"].ToString();

                if (memco_cd == "0" || site_cd == "0")
                {
                    ModelState.AddModelError("", "Select SiteGroup & Site");
                    return NotFound();
                }
                else
                {
                    foreach (var dev in devices)
                    {
                        if (dev.Chk_val)
                        {
                            Device_Logs devLog = new Device_Logs();
                            devLog.Serial_id = dev.Serial_id;
                            devLog.Site_cd = Convert.ToInt32(site_cd);
                            devLog.Reg_dt = Convert.ToDateTime(reg_dt);
                            devLog.Code3 = Convert.ToInt32(code3);
                            devLog.Code4 = Convert.ToInt32(code4);
                            devLog.Code5 = Convert.ToInt32(code5);
                            devLog.Memo1 = memo1;
                            devLog.Memo2 = memo2;
                            devLog.Input_id = User.FindFirst(ClaimTypes.Name).Value;
                            devLog.Update_id = User.FindFirst(ClaimTypes.Name).Value;
                            devLog.Input_dt = DateTime.Now;
                            devLog.Update_dt = DateTime.Now;

                            // Device_Log 저장 한다
                            _context.Add(devLog);
                            await _context.SaveChangesAsync();

                            // Device_Sts 저장 한다
                            var rData1 = _context.T00_DEVICE_LOG.Where(n => n.Serial_id.Equals(dev.Serial_id)).OrderByDescending(n => n.Reg_dt).Take(1).ToList();
                            var rData2 = _context.T00_DEVICE_STS.Where(n => n.Serial_id.Equals(dev.Serial_id)).ToList();

                            if (rData1.Count > 0)
                            {

                                if (rData2.Count > 0)
                                {
                                    rData2[0].Serial_id = dev.Serial_id;
                                    rData2[0].Site_cd = rData1[0].Site_cd;
                                    rData2[0].Log_id = rData1[0].Log_id;

                                    _context.Update(rData2[0]);
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    Device_Sts devSts = new Device_Sts();
                                    devSts.Serial_id = dev.Serial_id;
                                    devSts.Site_cd = rData1[0].Site_cd;
                                    devSts.Log_id = rData1[0].Log_id;

                                    _context.Add(devSts);
                                    await _context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult GoAddSite([Bind(Prefix = "Sub_id")] string[] sub_id)
        public async Task<IActionResult> GoAddSite_ScanView()
        {
            if (ModelState.IsValid)
            {
                var serial_id = HttpContext.Request.Form["Serial_id"].ToString();
                var memco_cd = HttpContext.Request.Form["Memco_cd"].ToString();
                var site_cd = HttpContext.Request.Form["Site_cd"].ToString();
                var reg_dt = HttpContext.Request.Form["Reg_dt"].ToString();
                var code3 = HttpContext.Request.Form["Code3"].ToString();
                var code4 = HttpContext.Request.Form["Code4"].ToString();
                var code5 = HttpContext.Request.Form["Code5"].ToString();
                var memo1 = HttpContext.Request.Form["Memo1"].ToString();
                var memo2 = HttpContext.Request.Form["Memo2"].ToString();

                if (memco_cd == "0" || site_cd == "0")
                {
                    ModelState.AddModelError("", "Select SiteGroup & Site");
                    return NotFound();
                }
                else
                {
                    if (serial_id != null)
                    {
                        Device_Logs devLog = new Device_Logs();
                        devLog.Serial_id = serial_id;
                        devLog.Site_cd = Convert.ToInt32(site_cd);
                        devLog.Reg_dt = Convert.ToDateTime(reg_dt);
                        devLog.Code3 = Convert.ToInt32(code3);
                        devLog.Code4 = Convert.ToInt32(code4);
                        devLog.Code5 = Convert.ToInt32(code5);
                        devLog.Memo1 = memo1;
                        devLog.Memo2 = memo2;
                        devLog.Input_id = User.FindFirst(ClaimTypes.Name).Value;
                        devLog.Update_id = User.FindFirst(ClaimTypes.Name).Value;
                        devLog.Input_dt = DateTime.Now;
                        devLog.Update_dt = DateTime.Now;

                        // Device_Log 저장 한다
                        _context.Add(devLog);
                        await _context.SaveChangesAsync();

                        // Device_Sts 저장 한다
                        var rData1 = _context.T00_DEVICE_LOG.Where(n => n.Serial_id.Equals(serial_id)).OrderByDescending(n => n.Reg_dt).Take(1).ToList();
                        var rData2 = _context.T00_DEVICE_STS.Where(n => n.Serial_id.Equals(serial_id)).ToList();

                        if (rData1.Count > 0)
                        {

                            if (rData2.Count > 0)
                            {
                                rData2[0].Serial_id = serial_id;
                                rData2[0].Site_cd = Convert.ToInt32(site_cd);
                                rData2[0].Log_id = rData1[0].Log_id;

                                _context.Update(rData2[0]);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                Device_Sts devSts = new Device_Sts();
                                devSts.Serial_id = serial_id;
                                devSts.Site_cd = Convert.ToInt32(site_cd);
                                devSts.Log_id = rData1[0].Log_id;

                                _context.Add(devSts);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: Devices/Details/5
        public async Task<IActionResult> ScanView(string id)
        {
            // 현장 그룹
            List<SiteGroup> siteGroups = new List<SiteGroup>();
            siteGroups = (from _data1 in _context.T00_MEMCO
                          select _data1).ToList();
            siteGroups.Insert(0, new SiteGroup { Memco_cd = 0, Memco_nm = "- Select -" });
            ViewBag.ListOfSiteGroup = siteGroups;

            // 기준일자
            string dateTime = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            ViewBag.DataOfReg_dt = dateTime;

            // 코드3
            List<Codes> codes3 = new List<Codes>();
            codes3 = (from _data_code3 in _context.T00_CODE
                      where _data_code3.Code_grp.Equals(3)
                      select _data_code3).ToList();
            codes3.Insert(0, new Codes { Code = 0, Code_nm = "- Select -" });
            ViewBag.ListOfCode3 = codes3;

            // 코드4
            List<Codes> codes4 = new List<Codes>();
            codes4 = (from _data_code4 in _context.T00_CODE
                      where _data_code4.Code_grp.Equals(4)
                      select _data_code4).ToList();
            codes4.Insert(0, new Codes { Code = 0, Code_nm = "- Select -" });
            ViewBag.ListOfCode4 = codes4;

            // 코드5
            List<Codes> codes5 = new List<Codes>();
            codes5 = (from _data_code5 in _context.T00_CODE
                      where _data_code5.Code_grp.Equals(5)
                      select _data_code5).ToList();
            codes5.Insert(0, new Codes { Code = 0, Code_nm = "- Select -" });
            ViewBag.ListOfCode5 = codes5;


            ViewData["CodeList"] = _context.T00_CODE
                .Where(n => n.Code_grp.Equals(2))
                .Select(n => new SelectListItem { Value = n.Code.ToString(), Text = n.Code_nm }).ToList();

            if (id == null)
            {
                return NotFound();
            }

            var devices = await _context.T00_DEVICE
                .FirstOrDefaultAsync(m => m.Serial_id == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }
    }
}
