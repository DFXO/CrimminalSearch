using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NationalCriminal.Search.DataContracts;
using NationalCriminal.Search.Service.DataAccess;

namespace NationalCriminal.Search.Service.UnitTests
{
    [TestClass]
    public class DataAccessUnitTests
    {
        private DataAccess.DataAccess _dac = new DataAccess.DataAccess();

        [TestMethod]
        public void SearchCriminals_Passed()
        {                       
            CriminalSearchCriteria criteria= TestData.GetSearchCriteria();
            List<CriminalProfile> profiles=_dac.SearchCriminalProfiles(criteria);
            Assert.IsNotNull(profiles);
            Assert.IsTrue(profiles.Count>0);
        }

        [TestMethod]
        public void UploadImages()
        {
            _dac.UploadImage();
        }
    }
}
