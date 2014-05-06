using System.ComponentModel.DataAnnotations;

namespace SportsStore.Web.Models
{
    public class ShippingDetailsModel
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        [Required(ErrorMessage = "Please enter city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter state")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter country")]
        public string Country { get; set; }
        public bool? GiftWrap { get; set; }
    }
}