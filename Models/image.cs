using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Models
{
    [Table(name:"images")]
    public class image
    {
        public image()
        {
            created = DateTime.Now;
            updated = new DateTime();
        }
        public int ID { get; set; }
        [Display(Name = "Название")]
        public string title { get; set; }
        [Display(Name = "Url картинки"), DataType(DataType.ImageUrl)]
        public string url { get; set; }

        [DataType(DataType.Date)]
        public DateTime created { get; set; }
        [DataType(DataType.Date)]
        public DateTime updated { get; set; }

        public int? postID { get; set; }
        public int? imagesAlbumID { get; set; }
    }
}
