using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.ViewModels
{
    public class CommentViewModel
    {
        public int RollerSkateMapLocationId { get; set; }

        [Required(ErrorMessage = "Please enter CommentText")]
        public string CommentText { get; set; }

        public int UserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
