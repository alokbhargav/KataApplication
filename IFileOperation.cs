using System;
using System.Collections.Generic;
using System.Text;

namespace KataApplication
{
    public interface IFileOperation
    {
        string[] GetFileContent();
        List<string> GetDriverName(string[] rawData);
        List<TripDetailModel> GetTripDetail(string[] rawData);
    }
}
