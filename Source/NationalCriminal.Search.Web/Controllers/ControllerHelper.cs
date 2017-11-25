using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NationalCriminal.Search.Web.Models;
using NationalCriminal.Search.Web.Models.DataContext;
using UserProfile = NationalCriminal.Search.Web.Models.DataContext.UserProfile;

namespace NationalCriminal.Search.Web.Controllers
{
    public static class ControllerHelper
    {
        private static CriminalDataContextDataContext _dataContext;
        static ControllerHelper()
        {
            _dataContext=new CriminalDataContextDataContext();
        }

        public static bool IsValidUser(LoginModel model)
        {
            bool IsSuccess = false;
            try
            {
                var query = from data in _dataContext.UserLogins
                            where data.email_id.ToLower().Equals(model.UserName.ToLower())
                                  && data.password.Equals(model.Password)
                            select data;

                foreach (var login in query)
                {
                    if (login.email_id.ToLower().Equals(model.UserName.ToLower())
                        && login.password.Equals(model.Password))
                    {
                        IsSuccess = true;
                    }
                }
            }
            catch (Exception)
            {
                IsSuccess = false;
                throw;
            }
            return IsSuccess;
        }

        public static UserProfile GetUserProfile(string userId)
        {
            var query = from data in _dataContext.UserProfiles
                        where data.email_id.ToLower().Equals(userId.ToLower())
                        select data;

            foreach (UserProfile profile in query)
            {
                if (profile.email_id.ToLower().Equals(userId))
                {
                    return profile;
                }
            }
            return null;
        }

        public static void RegisterUser(RegisterModel profile)
        {
            _dataContext.UserProfiles.InsertOnSubmit(Translators.TranslateToUserProfile(profile));
            _dataContext.SubmitChanges();            
        }

        public static bool IsExistingUser(string emailId)
        {
            bool isUserExist = false;
            try
            {
                var query = from data in _dataContext.UserProfiles
                            where data.email_id.ToLower().Equals(emailId)
                            select data.email_id;

                foreach (string email in query)
                {
                    if (!string.IsNullOrEmpty(email) && email.ToLower().Equals(emailId))
                    {
                        isUserExist = true;
                    }
                }
            }
            catch (Exception)
            {
                isUserExist = false;
                throw;
            }
            return isUserExist;
        }    
    }
}