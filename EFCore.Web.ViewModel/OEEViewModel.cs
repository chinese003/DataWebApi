using System;

namespace EFCore.Web.ViewModel
{
    public class OEEViewModel
    {

        public string ProductionLine { get; set; }


        public string OPStation { get; set; }


        public string OPDate { get; set; }


        public double? TEEP { get; set; }


        public double? OEE { get; set; }


        public double? Availability { get; set; }


        public double? Performance { get; set; }


        public double? QualityRate { get; set; }
    }
}
