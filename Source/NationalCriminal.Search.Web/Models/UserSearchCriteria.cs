using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NationalCriminal.Search.Web.Models
{
    public class UserSearchCriteria
    {
        public List<string> CriminalNames { get; set; }
        
        public Range Age { get; set; }
        
        public Range Height { get; set; }

        public Range Weight { get; set; }

        public string Sex { get; set; }

        public string Nationality { get; set; }

        public int MaxResults { get; set; }        
    }

    public class JsonUserSearchCriteria
    {             
        public string NameLists { get; set; }

        public int StartAge { get; set; }

        public int EndAge { get; set; }

        public int StartHeight { get; set; }

        public int EndHeight { get; set; }

        public int StartWeight { get; set; }

        public int EndWeight { get; set; }

        public string Sex { get; set; }

        public string Nationality { get; set; }

        public int MaxResults { get; set; }
    }






}