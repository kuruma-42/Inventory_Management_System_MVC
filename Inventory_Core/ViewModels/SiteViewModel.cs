using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Core.ViewModels
{
    public class SiteViewModel
    {
        public string Memco_nm { get; set; }

        public int Site_cd { get; set; }

        public int Memco_cd { get; set; }

        public string Site_nm { get; set; }

        public string Res_nm1 { get; set; }

        public string Tel_no1 { get; set; }

        public string Res_nm2 { get; set; }

        public string Tel_no2 { get; set; }

        public string Eldigm_res_nm { get; set; }

        public string Address { get; set; }

        public int Sort_no { get; set; }

        public string Use_yn { get; set; }

        public string Del_yn { get; set; }

        public DateTime Start_dt { get; set; }

        public DateTime End_dt { get; set; }

        public string Memo1 { get; set; }

        public string Memo2 { get; set; }

        public DateTime Input_dt { get; set; }

        public DateTime Update_dt { get; set; }

        public string Input_id { get; set; }

        public string Update_id { get; set; }
    }
}
