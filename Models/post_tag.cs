using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Models
{
    [Table(name: "poststags")]
    public class post_tag
    {
        public int postID { get; set; }
        public post post { get; set; } = new post();

        public int tagID { get; set; }
        public tag tag { get; set; } = new tag();
    }
}
