using Mercy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercy.Models.Mercy_Post
{
   public class PostDetail
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public WorkOfMercy WorkOfMercy { get; set; }

        public DateTime DateOfNeed { get; set; }

        public DateTime TimeOfNeed { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public int UserID { get; set; }
    }
}
