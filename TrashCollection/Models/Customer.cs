using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Customer
    {
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Key]
        public int ID { get; set; }
        [Display(Name ="Customer First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
        [Display(Name = "Account Balance")]
        public double Balance { get; set; }
        [Display(Name = "Suspend Service Start")]
        public string SuspendStart { get; set; }
        [Display(Name = "Suspend Service End")]
        public string SuspendEnd { get; set; }
        [Display(Name = "Extra Pickup Date")]
        public string ExtraPickupDate { get; set; }
        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }
        [Display(Name = "Pickup Confirmed")]
        public bool ConfirmPickup { get; set; }


    }
}