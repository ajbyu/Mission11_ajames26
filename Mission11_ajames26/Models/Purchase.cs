using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mission11_ajames26.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }

        [BindNever]
        public ICollection<CartItem> Items { get; set; }

        [DisplayName("First and Last Namme")]
        [Required(ErrorMessage = "Please enter a name.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }
        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }
        [DisplayName("Address Line 3")]
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state.")]
        public string State { get; set; }

        [DisplayName("Postal/ZIP Code")]
        [Required(ErrorMessage = "Please enter a postal/zip code.")]
        public string PostalCode { get; set; }

        public string Country { get; set; }
    }
}
