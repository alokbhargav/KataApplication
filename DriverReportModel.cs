using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace KataApplication
{
    public class DriverReportModel : IComparable<DriverReportModel>
    {
        public string DriverName { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }
        public double TimeSpend { get; set; }

        public int CompareTo([AllowNull] DriverReportModel other)
        {
            if (this.Distance < other.Distance)
                return 1;
            if (this.Distance < other.Distance)
                return -1;
            else
                return 0;
        }
    }
}
