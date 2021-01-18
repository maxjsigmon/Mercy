using Mercy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercy.Models.Mercy_Post
{
    public class PostListItem
    {
        [Key]
        public int PostID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfNeed { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime TimeOfNeed { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Work of Mercy")]
        [Display(Name = "Work of Mercy")]
        public WorkOfMercy WorkOfMercy { get; set; }
    }
}
