using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Core.Models
{
    public class Devices
    {
        [Key]
        [Required(ErrorMessage = "ID를 입력하세요.")]
        public string Serial_id { get; set; }

        public int Code2 { get; set; }

        public string Sub_id { get; set; }

        public string Use_yn { get; set; }

        public string Memo1 { get; set; }

        public string Memo2 { get; set; }

        public DateTime Input_dt { get; set; }

        public DateTime Update_dt { get; set; }

        public string Input_id { get; set; }

        public string Update_id { get; set; }
    }
}
