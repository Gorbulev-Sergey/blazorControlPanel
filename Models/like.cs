using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Models
{
    [Table(name: "likes")]
    public class like
    {
        public like()
        {
            created = DateTime.Now;
            updated = new DateTime();
        }
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime created { get; set; }
        [DataType(DataType.Date)]
        public DateTime updated { get; set; }

        public string userId { get; set; }
        public int? postID { get; set; }
        public int? imageAlbumID { get; set; }
    }
}
