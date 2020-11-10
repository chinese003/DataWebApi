using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Web.ViewModel
{
    public class OutputViewModel
    {
        public string Date { get; set; }

        public string Name { get; set; }

        public Int64? Shift { get; set; }

        public int? Total_Parts { get; set; }

        public int? Good_Parts { get; set; }

        public int? Fail_Parts { get; set; }

        public double? Good_Parts_Ratio { get; set; }

        public double? Fail_Parts_Ratio { get; set; }

        public DateTime Period_Start { get; set; }

        public DateTime Period_End { get; set; }

        public string PN { get; set; }
    }
}
