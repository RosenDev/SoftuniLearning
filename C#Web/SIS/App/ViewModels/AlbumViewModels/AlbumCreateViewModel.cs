using System.ComponentModel.DataAnnotations;

namespace App.ViewModels.AlbumViewModels
{
    public class AlbumCreateViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cover { get; set; }
        
    }
}