using System.Collections.Generic;
using NationalCriminal.Search.Service.DataAccess;
using NationalCriminal.Search.Service.Entities;
using CriminalProfile = NationalCriminal.Search.Service.Entities.CriminalProfile;

namespace NationalCriminal.Search.Service.BusinessLogic
{
    public static class Translator
    {
        public static List<CriminalProfile> ToEntitiesCriminalProfiles(List<DataAccess.CriminalProfile> profiles)
        {
            List<CriminalProfile> wrapperCriminalProfiles = null;

            if (profiles != null)
            {
                wrapperCriminalProfiles = new List<CriminalProfile>();

                foreach (var profile in profiles)
                {
                    wrapperCriminalProfiles.Add(ToEntitiesCriminalProfile(profile));
                }
            }

            return wrapperCriminalProfiles;
        }

        public static List<CriminalCrimeDetails> ToEntitiesCriminalCrimeDetails(
            List<CriminalCrimeDetail> crimeDetails)
        {
            List<CriminalCrimeDetails> entitiesCrimeDetails = null;
            if (crimeDetails != null && crimeDetails.Count > 0)
            {
                entitiesCrimeDetails = new List<CriminalCrimeDetails>();
                crimeDetails.ForEach(crimeDetail =>
                {
                    entitiesCrimeDetails.Add(ToEntitiesCriminalCrimeDetail(crimeDetail));
                });
            }
            return entitiesCrimeDetails;
        }

        private static CriminalCrimeDetails ToEntitiesCriminalCrimeDetail(CriminalCrimeDetail crimeDetail)
        {
            if(crimeDetail!=null)
            {
                return new CriminalCrimeDetails()
                {
                    CrimeDateTime = crimeDetail.crime_datetime,
                    CrimeDescription = crimeDetail.crime_description,
                    CrimeCharges = crimeDetail.crime_charges,
                    CrimeLocation = crimeDetail.crime_location,
                    FirNo = crimeDetail.fir_no,
                    CrimeType = crimeDetail.crime_type,
                    CrimeId = crimeDetail.crime_id,
                    CriminalId = crimeDetail.criminal_id                    
                };
            }
            return null;
        }

        public static CriminalProfile ToEntitiesCriminalProfile(DataAccess.CriminalProfile profile)
        {
            if (profile != null)
            {
                return new CriminalProfile()
                {
                    Height = (int) profile.height,
                    Age = (int) profile.age,
                    Name = profile.name,
                    Weight = (int) profile.weight,
                    Address = profile.address,
                    City = profile.city,
                    Country = profile.country,
                    Id = profile.criminal_id,
                    IdentificationMarks = profile.ciminal_identification_marks,
                    Nationality = profile.nationality,
                    Nickname = profile.nickname,
                    Photograph = profile.photo,
                    Sex = ToEntitiesSex(profile.sex),
                    State = profile.state
                };
            }
            return null;
        }

        private static Sex ToEntitiesSex(string sex)
        {
            if (sex.Equals(Sex.Male.ToString()))
                return Sex.Male;

            if (sex.Equals(Sex.Female.ToString()))
                return Sex.Female;

            return default(Sex);
        }
    }
}
