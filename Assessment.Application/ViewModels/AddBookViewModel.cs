using System.ComponentModel.DataAnnotations;

namespace Assessment.Application.ViewModels
{
    public class AddBookViewModel
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
