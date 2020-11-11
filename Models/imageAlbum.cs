using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Models
{
    [Table(name: "imageAlbums")]
    public class imageAlbum
    {
        public imageAlbum()
        {
            images = new List<image>();
            comments = new List<comment>();
            likes = new List<like>();
            created = DateTime.Now;
            updated = new DateTime();
        }
        public int ID { get; set; }        
        [Display(Name = "Название")]
        public string title { get; set; }
        [Display(Name = "Краткое описание")]
        public string description { get; set; }
        [Display(Name = "Обложка альбома"), DataType(DataType.ImageUrl)]
        public string cover_image { get; set; }
        [Display(Name = "Картинки")]
        public virtual IList<image> images { get; set; }
        [Display(Name = "Комментарии")]
        public virtual IList<comment> comments { get; set; }
        [Display(Name = "Нравится")]
        public virtual IList<like> likes { get; set; }

        [DataType(DataType.Date)]
        public DateTime created { get; set; }
        [DataType(DataType.Date)]
        public DateTime updated { get; set; }

        public string userId { get; set; }
        public int? postId { get; set; }
    }
}
