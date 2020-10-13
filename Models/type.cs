using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Models
{
    public enum type
    {
        [Display(Name = "Новость")]
        news,
        [Display(Name = "Cтатья")]
        article,
        [Display(Name = "Видео")]
        video,
        [Display(Name = "Объявление")]
        notification
    }
}
