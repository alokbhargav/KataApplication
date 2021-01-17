using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace KataApplication
{
    public class FileOperation: IFileOperation
    {
        public string[] GetFileContent()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(Infra.GetFileObject()))
            using (StreamReader reader = new StreamReader(stream))
            {
                var splitString = reader.ReadToEnd().Split("\r\n");
                return splitString;
                
            }
        }

        public List<string> GetDriverName(string [] rawData)
        {
            var drivers = new List<string>();
            foreach(var line in rawData)
            {
                var tempString = line.Split(" ");
                if (tempString[0] == "Driver")
                    drivers.Add(tempString[1]);
            }
            return drivers;

        }
        public List<TripDetailModel> GetTripDetail(string[] rawData)
        {
            var trips = new List<TripDetailModel>();
            foreach (var line in rawData)
            {
                var tempString = line.Split(" ");
                if (tempString[0] == "Trip")
                {
                    trips.Add(new TripDetailModel() { DriverName = tempString[1],StartTime = tempString[2],EndTime = tempString[3],Distance = double.Parse(tempString[4])});
                }
                    
            }
            return trips;

        }
    }
}
