using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Core.Models
{
    public class WorkDiary
    {
        [Key]
        public int Wd_id { get; set; }
        public int Reg_date { get; set; }
        public string User_id { get; set; }
        [BindProperty, MaxLength(300)]
        public string Title { get; set; }
        public string Contents { get; set; }
        public Byte Del_flag { get; set; }
        public DateTime Input_dt { get; set; }
        public DateTime Update_dt { get; set; }
    }
}
