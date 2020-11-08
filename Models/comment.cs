using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Models
{
    [Table(name:"comments")]
    public class comment
    {
        public comment()
        {
            created = DateTime.Now;
            updated = new DateTime();
        }
        public int ID { get; set; }
        [Display(Name = "Текст комментария")]
        public string text { get; set; }

        [DataType(DataType.Date)]
        public DateTime created { get; set; }
        [DataType(DataType.Date)]
        public DateTime updated { get; set; }

        public string userId { get; set; }
        public string userName { get; set; }
        public int? postID { get; set; }
        public int? imagesAlbumID { get; set; }
    }
}
