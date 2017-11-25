namespace NationalCriminal.Search.Web.Models
{
    public class UserSearchRequest
    {        
        public UserSearchCriteria SearchCriteria { get; set; }
      
        public int? MaxResults { get; set; }
      
        public string EmailId { get; set; }
      
        public string SessionId { get; set; }
    }
}