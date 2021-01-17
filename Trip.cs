using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataApplication
{
    public class Trip
    {
        public IFileOperation _fileOperation { get; set; }
        private readonly string[] fileContent;
        public Trip(IFileOperation fileOperation)
        {
            _fileOperation = fileOperation;
            fileContent = _fileOperation.GetFileContent();

        }
        private List<DriverReportModel> BuildDriverReport()
        {
            var drivers = _fileOperation.GetDriverName(fileContent);
            var trips = _fileOperation.GetTripDetail(fileContent);
            var result = new List<DriverReportModel>();
            foreach(var driver in drivers)
            {
                var driverTrips = trips.Where(x=>x.DriverName == driver);
                var driverDetail = new DriverReportModel();
                foreach(var driverTrip in driverTrips)
                {
                    var totalMinutes = DateTime.Parse(driverTrip.EndTime).Subtract(DateTime.Parse(driverTrip.StartTime)).TotalMinutes;
                    var speed = driverTrip.Distance*60/DateTime.Parse(driverTrip.EndTime).Subtract(DateTime.Parse(driverTrip.StartTime)).TotalMinutes;
                    if (speed > 5 && speed < 100)
                    {
                        driverDetail.Distance = driverDetail.Distance + driverTrip.Distance;
                        driverDetail.TimeSpend = driverDetail.TimeSpend + totalMinutes;
                    }
                }
                if (driverDetail.Distance != 0)
                {
                    driverDetail.Speed = driverDetail.Distance * 60 / driverDetail.TimeSpend;
                    driverDetail.DriverName = driver;
                    result.Add(driverDetail);
                }

            }
            result.Sort();
            return result;
        }
        public string ConvertResultToReport()
        {
            var driverReports = BuildDriverReport();
            string reportString = "";
            foreach(var report in driverReports)
            {
                reportString = reportString + report.DriverName + ":" + " " + report.Distance + " " + "@" + " " + report.Speed + " " + "mph" + System.Environment.NewLine;

            }
            return reportString;

        }
    }
}
