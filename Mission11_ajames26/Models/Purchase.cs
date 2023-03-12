using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
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

        [Required(ErrorMessage = "Please enter a name.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a postal/zip code.")]
        public string PostalCode { get; set; }

        public string Country { get; set; }
    }
}
