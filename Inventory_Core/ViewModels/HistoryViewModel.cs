using System;

namespace Inventory_Core.ViewModels
{
        public class HistoryViewModel
    {
        public int Log_id { get; set; }

        public DateTime Reg_dt { get; set; }

        public string Serial_id { get; set; }

        public int Memco_cd { get; set; }

        public string Memco_nm { get; set; } // 타입 체크 

        public int Site_cd { get; set; }

        public string Site_nm { get; set; }

        public string Code_nm3 { get; set; }

        public string Code_nm4 { get; set; }

        public string Code_nm5 { get; set; }

        public int Sub_id { get; set; }

        public string Memo1 { get; set; }

        public string Memo2 { get; set; }              

        public string Input_id { get; set; }

        public int Code { get; set; }

        public int Code3 { get; set; }

        public int Code4 { get; set; }

        public int Code5 { get; set; }

    }
}
