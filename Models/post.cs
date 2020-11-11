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
        public post()
        {
            created = DateTime.Now;
            updated = new DateTime();
            type = type.Новость;
            published = false;
            tags = new List<tag>();
            comments = new List<comment>();
            likes = new List<like>();
            images = new List<image>();
            videos = new List<video>();
        }
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
        [Display(Name ="Опубликовать")]
        public bool published { get; set; }
        [Display(Name ="Дата создания"), DataType(DataType.Date)]
        public DateTime created { get; set; }
        [Display(Name = "Дата обновления"), DataType(DataType.Date)]
        public DateTime updated { get; set; }
        [Display(Name = "Теги")]
        public virtual IList<tag> tags { get; set; }
        [Display(Name = "Комментарии")]
        public virtual IList<comment> comments { get; set; }
        [Display(Name = "Нравится")]
        public virtual IList<like> likes { get; set; }
        [Display(Name = "Картинки")]
        public virtual IList<image> images { get; set; }
        [Display(Name = "Видео")]
        public virtual IList<video> videos { get; set; }

        public string userId { get; set; }
    }
}
