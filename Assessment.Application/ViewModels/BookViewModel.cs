using Assessment.Domain.Entities;
using Assessment.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application.ViewModels
{
    public class BookViewModel : AddBookViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string Status { get; set; }
        public DateTime? DateOfReturn { get; set; }
    }
}
