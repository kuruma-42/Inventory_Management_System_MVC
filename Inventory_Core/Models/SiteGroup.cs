﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Core.Models
{
    public class SiteGroup
    {
        [Key]
        public int Memco_cd { get; set; }

        [Required(ErrorMessage = "그룹명을 입력하세요.")]
        public string Memco_nm { get; set; }

        [Required(ErrorMessage = "정렬번호 입력하세요.")]
        public int Sort_no { get; set; }

        public string Use_yn { get; set; }

        public string Memo1 { get; set; }

        public string Memo2 { get; set; }

        public DateTime Input_dt { get; set; }

        public DateTime Update_dt { get; set; }

        public string Input_id { get; set; }

        public string Update_id { get; set; }
    }
}