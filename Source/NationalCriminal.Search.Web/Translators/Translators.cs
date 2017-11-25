using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NationalCriminal.Search.Service.ServiceTests.CriminalSearchRefernce;
using NationalCriminal.Search.Web.Models;
using NationalCriminal.Search.Web.Models.DataContext;
using WebGrease.Css;
using Range = NationalCriminal.Search.Web.Models.Range;
using SearchRange =NationalCriminal.Search.Service.ServiceTests.CriminalSearchRefernce.Range;
using UserProfile = NationalCriminal.Search.Web.Models.DataContext.UserProfile;

namespace NationalCriminal.Search.Web
{
    public static class Translators
    {
        public static UserSearchCriteria TranslateToServiceObjects(JsonUserSearchCriteria jsonCriteria)
        {
            UserSearchCriteria searchCriteria = null;
            try
            {               
                if (jsonCriteria != null)
                {
                    searchCriteria = GetUserSearchCriteria(jsonCriteria);     
                }
            }
            catch (Exception exception)
            {                
                throw new Exception("Error occured while translating data."+exception);
            }
            
            return searchCriteria;
        }

        private static UserSearchCriteria GetUserSearchCriteria(JsonUserSearchCriteria jsonCriteria)
        {
            return new UserSearchCriteria()
            {
                CriminalNames = GetFormattedList(jsonCriteria.NameLists),
                Sex = jsonCriteria.Sex,
                Nationality = jsonCriteria.Nationality,
                MaxResults = jsonCriteria.MaxResults,
                Age = GetRange(jsonCriteria.StartAge, jsonCriteria.EndAge),
                Height = GetRange(jsonCriteria.StartHeight, jsonCriteria.EndHeight),
                Weight=GetRange(jsonCriteria.StartWeight, jsonCriteria.EndWeight),
            };
        }

        private static Range GetRange(int start, int end)
        {           
            if (start == 0 && end == 0)
            {
                return null;
            }
            
            return new Range
                {
                    Start = start,
                    End = end,
                };            
        }

        private static List<string> GetFormattedList(string commaSaperatedList)
        {
            var criminalNameList = new List<string>();

            if (!string.IsNullOrEmpty(commaSaperatedList))
            {
                var nameLists=commaSaperatedList.Split(',');

                foreach (var name in nameLists)
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        criminalNameList.Add(name);
                    }
                }
            }

            return criminalNameList;
        }

        public static UserProfile TranslateToUserProfile(RegisterModel registeProfile)
        {
            UserProfile profile = null;
            if (registeProfile != null)
            {
                profile = new UserProfile()
                {
                    email_id= registeProfile.UserName,
                    address = registeProfile.Address,
                    name= registeProfile.Name,
                    registration_datetime = DateTime.Now,
                    UserLogin = new UserLogin
                    {
                        email_id = registeProfile.UserName,
                        password = registeProfile.Password,
                        last_login = DateTime.Now
                    }
                };
            }
            return profile;
        }

        public static CriminalSearchCriteria TranslateToCriminalSearchCriteria(UserSearchCriteria userCriteria)
        {
            CriminalSearchCriteria searchCriteria = null;

            if (userCriteria != null)
            {
                searchCriteria = new CriminalSearchCriteria()
                {
                    Age = TranslateToSearchRange(userCriteria.Age),
                    Height = TranslateToSearchRange(userCriteria.Height),
                    Weight = TranslateToSearchRange(userCriteria.Weight),
                    Nationality = userCriteria.Nationality,
                    Sex = userCriteria.Sex,
                    CriminalNames = userCriteria.CriminalNames.ToArray()
                };
            }
            return searchCriteria;
        }

        public static SearchRange TranslateToSearchRange(Range range)
        {
            SearchRange searchRange = null;
            if (range != null)
            {
                searchRange = new SearchRange()
                {
                    Start = range.Start,
                    End = range.End
                };
            }
            return searchRange;
        }      
    }
}