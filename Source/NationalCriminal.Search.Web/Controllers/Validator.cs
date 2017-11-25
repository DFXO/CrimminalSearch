using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NationalCriminal.Search.Web.Models;

namespace NationalCriminal.Search.Web.Controllers
{
    public static class Validator
    {
        public static void ValidateJsonRequest(JsonUserSearchCriteria jsonSearchCriteria)
        {
            if (jsonSearchCriteria == null)
            {
                throw new ArgumentException("Search criteria is not valid");
            }

            if (!jsonSearchCriteria.Sex.Contains(Sex.Male.ToString()) || !jsonSearchCriteria.Sex.Contains(Sex.Female.ToString()))
            {
                jsonSearchCriteria.Sex = null;
            }

            if (!string.IsNullOrEmpty(jsonSearchCriteria.Nationality) && (jsonSearchCriteria.Nationality.ToLower().Equals("nan") ||
                jsonSearchCriteria.Nationality.ToLower().Equals("undefined")))
            {
                jsonSearchCriteria.Nationality = null;
            }            
        }

        public enum Sex
        {
            Male,
            Female            
        }
    }
}