using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using NationalCriminal.Search.DataContracts;

namespace NationalCriminal.Search.Service.DataAccess
{
    public class DataAccess
    {
        #region Private Members
        private readonly CriminalDBDataContext _criminalDb;
        #endregion

        #region Public Methods

        /// <summary>
        /// This constructor is used to initialize the database context to operate on database.
        /// </summary>
        public DataAccess()
        {
            _criminalDb = new CriminalDBDataContext();
        }

        /// <summary>
        /// This method is used to fetch the results from Database
        /// </summary>
        /// <param name="criteria">CriminalSearchCriteria criteria</param>
        /// <returns>List<CriminalProfile></returns>
        public List<CriminalProfile> SearchCriminalProfiles(CriminalSearchCriteria criteria)
        {
            List<CriminalProfile> searchResults = null;                        
            try
            {
                if (criteria != null)
                {
                    searchResults = FilterResults(criteria);                   
                }
            }
            catch (Exception exception)
            {
                throw new KeyNotFoundException("An enknown error occured while fetching results from database.",
                    exception);
            }
            
            return searchResults;
        }

        /// <summary>
        /// This method is used to fetch the crime details for criminal
        /// </summary>
        /// <param name="profile">Entities.CriminalProfile profile</param>
        /// <returns>List<CriminalCrimeDetail></returns>
        public List<CriminalCrimeDetail> GetCriminalCrimeDetails(Entities.CriminalProfile profile)
        {
            List<CriminalCrimeDetail> crimeDetails = null;
            try
            {                
                if (profile != null)
                {
                    crimeDetails = (from data in _criminalDb.CriminalCrimeDetails
                                    where profile.Id == data.criminal_id
                                    select data).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new KeyNotFoundException("An enknown error occured while fetching results from database.",
                    exception);
            }
         
            return crimeDetails;
        }

        /// <summary>
        /// This methos is use to update the criminal records with the their respective photo.
        /// </summary>
        public void UploadImage()
        {
            var query = from data in _criminalDb.CriminalProfiles
                        select data;

            foreach (CriminalProfile profile in query)
            {
                Image image =
                    Image.FromFile(string.Format(@"E:\Educational Data\Abhishek\PROGRAMS\IMP\Rx\Rx\Rx\img\Pics\a{0}.jpg", profile.criminal_id));
                byte[] img = ImageToByteArray(image);
                Binary fileBinary = new Binary(img);
                profile.photo = fileBinary;
            }

            _criminalDb.SubmitChanges();
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// This method is used to filter the results using input search criteria.
        /// </summary>
        /// <param name="criteria">CriminalSearchCriteria criteria</param>
        /// <returns>List<CriminalProfile/></returns>
        private List<CriminalProfile> FilterResults(CriminalSearchCriteria criteria)
        {
            List<CriminalProfile> searchedResults=new List<CriminalProfile>();
            try
            {
                foreach (CriminalProfile profile in _criminalDb.CriminalProfiles)
                {
                    if (ApplyFilters(criteria, profile))
                    {
                        //if search criteria contains name list then filter using listed names in criteria.
                        if (criteria.CriminalNames != null && criteria.CriminalNames.Count > 0)
                        {
                            FilterResultsForCriminalNames(criteria, profile, searchedResults);
                        }
                        else
                        {
                            searchedResults.Add(profile);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                
                throw;
            }                      
          return searchedResults;
        }

        /// <summary>
        /// This method is used to filter the results using name lists in search criteria.
        /// </summary>
        /// <param name="criteria">CriminalSearchCriteria criteria</param>
        /// <param name="profile">CriminalProfile profile</param>
        /// <param name="searchedResults">List<CriminalProfile/> searchedResults</param>
        private static void FilterResultsForCriminalNames(CriminalSearchCriteria criteria, CriminalProfile profile,
            List<CriminalProfile> searchedResults)
        {
            foreach (var name in criteria.CriminalNames)
            {
                if (!string.IsNullOrEmpty(name) && profile.name.ToLower().Contains(name.ToLower()))
                {
                    searchedResults.Add(profile);
                }
            }
        }

        /// <summary>
        /// This method is used to apply the filters.
        /// </summary>
        /// <param name="criteria">CriminalSearchCriteria criteria</param>
        /// <param name="profile">CriminalProfile profile</param>
        /// <returns></returns>
        private static bool ApplyFilters(CriminalSearchCriteria criteria, CriminalProfile profile)
        {
            return ((criteria.Sex != null && profile.sex.ToLower().Equals(criteria.Sex.ToLower())) || string.IsNullOrEmpty(criteria.Sex))
                   && ((criteria.Age != null && profile.age >= criteria.Age.Start && profile.age <= criteria.Age.End) || criteria.Age==null || (criteria.Age.End==0 && profile.age>criteria.Age.Start))
                   && ((criteria.Weight != null && profile.weight >= criteria.Weight.Start && profile.weight <= criteria.Weight.End) || criteria.Weight == null || (criteria.Weight.End == 0 && profile.weight > criteria.Weight.Start))
                   && ((criteria.Height != null && profile.height >= criteria.Height.Start && profile.height <= criteria.Height.End) || criteria.Height == null || (criteria.Height.End == 0 && profile.height> criteria.Height.Start))
                   && ((!string.IsNullOrEmpty(criteria.Nationality) && profile.nationality.ToLower().Equals(criteria.Nationality.ToLower())) || string.IsNullOrEmpty(criteria.Nationality));
        }        

        /// <summary>
        /// This method is ued to convert the Image into Byte array.
        /// </summary>
        /// <param name="imageIn">Image imageIn</param>
        /// <returns>byte[]</returns>
        private byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        #endregion
    }
}
