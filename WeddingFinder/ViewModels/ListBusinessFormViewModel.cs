using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeddingFinder.Models;

namespace WeddingFinder.ViewModels
{
    public class ListBusinessFormViewModel
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
        [StringLength(70)]
        [RegularExpression(@"^[a-zA-Z0-9/, ]*$", ErrorMessage = "Street address contains invalid characters")]
        public string Street { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Suburb must contain letters only")]
        public string Suburb { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "Postcode must contain 4 digits", MinimumLength = 4)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Postcode must contain numbers only")]
        public string Postcode { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "State is invalid")]
        public string State { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Region is invalid")]
        public string Region { get; set; }

        [DisplayName("Business Name")]
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Business Name must contain letters or numbers only")]
        public string BusinessName { get; set; }

        [Required]
        [StringLength(30)]
        //[RegularExpression(@"^[a-zA-Z&]+$", ErrorMessage = "Category is invalid")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Category is invalid")]
        public string Category { get; set; }

        [DisplayName("Instagram Url")]
        [StringLength(70)]
        [RegularExpression(@"^.*(instagram.com).*", ErrorMessage = "Url is invalid")]
        public string Instagram { get; set; }

        [DisplayName("Facebook Url")]
        [StringLength(70)]
        [RegularExpression(@"^.*(facebook.com).*$", ErrorMessage = "Url is invalid")]
        public string Facebook { get; set; }

        [DisplayName("Website Url")]
        [StringLength(70)]
        public string Website { get; set; }

        [DisplayName("Short Description")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9/&#!'.,?:;-_ ]*$", ErrorMessage = "Description contains invalid characters")]
        //[StringLength(50,MinimumLength=20)]
        public string ShortDescription { get; set; }

        [DisplayName("Full Description")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9/&#!'.,?:;-_ ]*$", ErrorMessage = "Description contains invalid characters")]
        //[StringLength(200, MinimumLength = 50)]
        public string FullDescription { get; set; }

        [DisplayName("I Agree to the Terms and Conditions")]
        [Compare("isTrue", ErrorMessage = "You must agree to the Terms and Conditions")]
        public bool TermsAndConditions { get; set; }

        public bool HasSeveralRegions { get; set; }

        [DisplayName("Additional Regions Serviced")]
        public List<int> ServicedRegions { get; set; }

        [BindProperty]
        public FormFile Upload { get; set; }

        public List<Category> CategoryList { get; set; }

        public List<State> StateList { get; set; }        

        public bool isTrue { get { return true; } }
    }
}
