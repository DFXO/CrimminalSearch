using System;

namespace NationalCriminal.Search.Service.Entities
{
    public class CriminalCrimeDetails
    {
        public int CrimeId { get; set; }

        public int CriminalId { get; set; }

        public string CrimeType  { get; set; }

        public string CrimeDescription { get; set; }

        public DateTime CrimeDateTime   { get; set; }

        public string CrimeLocation { get; set; }

        public string CrimeCharges { get; set; }

        public string FirNo { get; set; }


    }
}
 