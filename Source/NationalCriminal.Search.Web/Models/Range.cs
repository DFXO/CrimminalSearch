using System.ComponentModel.DataAnnotations;

namespace NationalCriminal.Search.Web.Models
{
    public class Range
    {
        [Display(Name = "Start Range")]
        public int Start { get; set; }

        [Display(Name = "End Range")]
        public int End { get; set; }
    }
}