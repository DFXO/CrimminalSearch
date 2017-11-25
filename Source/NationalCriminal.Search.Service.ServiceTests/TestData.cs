using NationalCriminal.Search.Service.ServiceTests.CriminalSearchRefernce;

namespace NationalCriminal.Search.Service.ServiceTests
{
    public static class TestData
    {
        public static CriminalSearchCriteria GetSearchCriteria()
        {
            return new CriminalSearchCriteria()
            {
                //Sex = "Male",                
                //Age = new Range
                //{
                //    Start = 20,
                //    End = 0,
                //},
                //Height = new Range
                //{
                //    Start = 130,
                //    End = 190
                //},
                CriminalNames = new []{"abhishek"}
                //Nationality = "Indian",
            };
        }
    }
}
