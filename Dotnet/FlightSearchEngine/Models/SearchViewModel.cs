using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightSearchEngine.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Please select a source city")]
        public string Source { get; set; }

        [Required(ErrorMessage = "Please select a destination city")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Please enter number of persons")]
        [Range(1, 10, ErrorMessage = "Number of persons must be between 1 and 10")]
        public int NumberOfPersons { get; set; }

        public SelectList SourceList { get; set; }
        public SelectList DestinationList { get; set; }
    }
}
