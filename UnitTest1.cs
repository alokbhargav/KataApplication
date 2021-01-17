using KataApplication;
using Moq;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace ApplicationTest
{
   
    public class UnitTest1
    {
        [Fact]
        public void TestDriverName()
        {
            //var sub = new Mock<IFileOperation>();
            var stringArray = new string[] { "Driver Dan", "Driver Alex", "Trip Dan 07:15 07:45 17.3", "Trip Alex 12:01 13:16 42.0" };
            //sub.Setup(x => x.GetFileContent()).Returns(stringArray);
            var sut = new FileOperation();
            var sutResult = sut.GetDriverName(stringArray);
            Assert.NotNull(sutResult);
            Assert.Equal(2, sutResult.Count);
            Assert.Contains("Dan", sutResult);
            Assert.Contains("Alex", sutResult);
        }
        [Fact]
        public void TestTrip()
        {
            var sub = new Mock<IFileOperation>();
            var stringArray = new string[] { "Driver Dan", "Driver Alex", "Trip Dan 07:15 07:45 17.3", "Trip Alex 12:01 13:16 42.0" };
            sub.Setup(x => x.GetFileContent()).Returns(stringArray);
            var sut = new FileOperation();
            var sutResult = sut.GetTripDetail(stringArray);
            Assert.NotNull(sutResult);
            Assert.Equal(2, sutResult.Count);
            Assert.Equal("Dan",sutResult[0].DriverName);
            Assert.Equal("Alex", sutResult[1].DriverName);

        }
        [Fact]
        public void TestOutput()
        {
            var sub = new Mock<IFileOperation>();
            var stringArray = new string[] { "Driver Dan", "Driver Alex", "Trip Dan 07:15 07:45 17.3", "Trip Alex 12:01 13:16 42.0" };
            sub.Setup(x => x.GetFileContent()).Returns(stringArray);
            sub.Setup(x => x.GetDriverName(It.IsAny<string[]>())).Returns(new List<string>() { "Dan", "Alex" });
            sub.Setup(x => x.GetTripDetail(It.IsAny<string[]>())).Returns(new List<TripDetailModel>() 
            { 
                new TripDetailModel(){ DriverName = "Dan",Distance = 17.3,StartTime = "07:15",EndTime ="07:45"},
                new TripDetailModel(){ DriverName = "Alex",Distance = 42.0,StartTime = "12:01",EndTime ="13:16"},

            });
            var sut = new Trip(sub.Object);
            var sutResult = sut.ConvertResultToReport();
            Assert.NotNull(sutResult);
            Assert.NotEqual("",sutResult);
            Assert.Equal("Alex: 42 @ 33.6 mph\r\nDan: 17.3 @ 34.6 mph\r\n", sutResult);
            //Assert.Equal("Dan", sutResult[0].DriverName);
            //Assert.Equal("Alex", sutResult[1].DriverName);

        }

    }
}
