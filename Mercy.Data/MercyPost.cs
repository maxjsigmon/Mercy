using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercy.Data
{
    public class MercyPost
    {
        [Key]
        public int PostID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateOfNeed { get; set; }

        [Required]
        public DateTime TimeOfNeed { get; set; }

        [Required]
        public WorkOfMercy WorkOfMercy { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }

    public enum WorkOfMercy
    {
        [Display(Name="Feed the Hungry")]
        FeedTheHungry = 1,
        [Display(Name = "Give Drink to the Thirsty")]
        GiveDrinkToTheThirsty,
        [Display(Name = "Shelter the Homeless")]
        ShelterTheHomeless,
        [Display(Name = "Clothe the Naked")]
        ClotheTheNaked,
        [Display(Name = "Visit the Sick")]
        VisitTheSick,
        [Display(Name = "Visit the Imprisoned")]
        VisitTheImprisoned,
        [Display(Name = "Bury the Dead")]
        BuryTheDead
    }
}
