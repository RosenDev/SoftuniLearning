
using SIS.WebServer.Attributes.Validation;

namespace App.ViewModels.TrackViewModels
{
    public class TrackCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Link { get; set; }
        
        public decimal Price { get; set; }
     
    }
}