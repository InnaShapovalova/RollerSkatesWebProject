using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.ViewModels
{
    public class RollerSkateMapLocationViewModel
    {
        [Required(ErrorMessage = "Please enter Longitude")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "Please enter Latitude")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Please enter LocationName")]
        public string LocationName { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
    }
}
