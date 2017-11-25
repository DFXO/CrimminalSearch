using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalCriminal.Search.DataContracts;

namespace NationalCriminal.Search.Service.UnitTests
{
    public class TestData
    {
        public static CriminalSearchCriteria GetSearchCriteria()
        {
            return new CriminalSearchCriteria()
            {
                Sex = "Male",
                CriminalNames = new List<string>()
                {
                    "abhishek","abhilash"
                },
                Age = new Range()
                {
                    Start = 20,
                    End = 24,
                },
                Height = new Range()
                {
                    Start = 170,
                    End = 190
                },
                Nationality = "Indian",
                Weight = new Range()
                {
                    Start = 50,
                    End = 65,
                }
            };
        }

        public static CriminalSearchRequest GetCriminalSearchRequest()
        {
            return new CriminalSearchRequest()
            {
                MaxResults = 5,
                SessionId = new Guid().ToString(),
                SearchCriteria = TestData.GetSearchCriteria(),
                EmailId = "testemail@gmail.com",
            };
        }
    }
}
