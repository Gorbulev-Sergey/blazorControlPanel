using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace blazorControlPanel.Models
{
    [Table(name: "posts")]
    public class post
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Добавьте, пожалуйста, название публикации"), Display(Name ="Название")]
        public string title { get; set; }
        [Display(Name = "Url обложки"), DataType(DataType.ImageUrl)]
        public string cover_image { get; set; }
        [Display(Name = "Url обложки (видео)"), DataType(DataType.ImageUrl)]
        public string cover_video { get; set; }
        [Display(Name = "Краткое описание"), AllowHtml, DataType(DataType.Html)]
        public string description { get; set; }
        [Display(Name = "Содержимое"), AllowHtml, DataType(DataType.Html)]
        public string content { get; set; }
        [Display(Name = "Тип")]
        public type type { get; set; }
        [Display(Name = "Опубликовать")]
        public bool published { get; set; } = false;
        [Display(Name = "Дата создания"), DataType(DataType.Date)]
        public DateTime created { get; set; } = DateTime.Now;
        [Display(Name = "Дата обновления"), DataType(DataType.Date)]
        public DateTime updated { get; set; } = DateTime.Now;
        [Display(Name = "Теги")]
        public List<post_tag> posts_tags { get; set; } = new List<post_tag>();
        [Display(Name = "Комментарии")]
        public virtual IList<comment> comments { get; set; } = new List<comment>();
        [Display(Name = "Нравится")]
        public virtual IList<like> likes { get; set; } = new List<like>();
        [Display(Name = "Картинки")]
        public virtual IList<image> images { get; set; } = new List<image>();
        [Display(Name = "Видео")]
        public virtual IList<video> videos { get; set; } = new List<video>();

        public string userId { get; set; }
    }
}
