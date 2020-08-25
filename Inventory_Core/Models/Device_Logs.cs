using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Core.Models
{
    public class Device_Logs
    {
        [Key]
        public int Log_id { get; set; }

        public string Serial_id { get; set; }

        public int Site_cd { get; set; }

        public DateTime Reg_dt { get; set; }

        public int Code3 { get; set; }

        public int Code4 { get; set; }

        public int Code5 { get; set; }

        public string Memo1 { get; set; }

        public string Memo2 { get; set; }

        public DateTime Input_dt { get; set; }

        public DateTime Update_dt { get; set; }

        public string Input_id { get; set; }

        public string Update_id { get; set; }
    }
}
