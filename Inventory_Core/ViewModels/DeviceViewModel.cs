using System;
using System.Collections.Generic;

namespace Inventory_Core.ViewModels
{
    public class DeviceViewModel
    {
        public bool Chk_val { get; set; }

        public string Serial_id { get; set; }

        public int Code2 { get; set; }

        public string Code2_nm { get; set; }

        public string Sub_id { get; set; }

        public string Use_yn { get; set; }

        public string Memo1 { get; set; }

        public string Memo2 { get; set; }

        public DateTime Input_dt { get; set; }

        public DateTime Update_dt { get; set; }

        public string Input_id { get; set; }

        public string Update_id { get; set; }

        public int Memco_cd { get; set; }

        public string Memco_nm { get; set; }

        public int Site_cd { get; set; }

        public string Site_nm { get; set; }
    }
}
