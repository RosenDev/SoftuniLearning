

using SIS.WebServer.Attributes.Validation;

namespace App.ViewModels.AlbumViewModels
{
    public class AlbumCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cover { get; set; }
        
    }
}