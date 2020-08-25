using System.ComponentModel.DataAnnotations;

namespace Inventory_Core.Models
{
    public class Device_Sts
    {
        [Key]
        public string Serial_id { get; set; }
        public int Site_cd { get; set; }
        public int Log_id { get; set; }
    }
}
