using System.Collections.Generic;
using System.Data.Linq;

namespace NationalCriminal.Search.Service.Entities
{
    public class CriminalProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public int Age { get; set; }

        public Sex Sex { get; set; }

        public int Height { get; set; }       

        public int Weight { get; set; }

        public string Nationality { get; set; }

        public string Address { get; set; }

        public Binary Photograph { get; set; }

        public string Country { get; set; }

	    public string State { get; set; }

        public string City { get; set; }

        public string IdentificationMarks { get; set; }

        public List<CriminalCrimeDetails> CrimeDetails { get; set; }
    }

    public enum Sex
    {
        Male,
        Female,
        Other
    }
}
