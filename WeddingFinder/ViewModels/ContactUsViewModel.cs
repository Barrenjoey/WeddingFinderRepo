using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingFinder.ViewModels
{
    public class ContactUsViewModel
    {
        [DisplayName("First Name")]
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "First Name must contain letters only")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Last Name must contain letters only")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [DisplayName("Contact Number")]
        [Required]
        [StringLength(10, ErrorMessage = "Contact Number must contain 10 digits", MinimumLength = 10)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Contact Number must contain numbers only")]
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(30)]
        //[RegularExpression(@"^[a-zA-Z&]+$", ErrorMessage = "Category is invalid")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Category is invalid")]
        public string Category { get; set; }

        [DisplayName("Description")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9/&#!'.,?:;-_ ]*$", ErrorMessage = "Description contains invalid characters")]
        //[StringLength(200, MinimumLength = 50)]
        public string Description { get; set; }

        public List<string> Categories { get; set; }
    }
}
