using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Models
{
    public enum type
    {
        [Display(Name = "Объявление")]
        Объявление,
        [Display(Name = "Новость")]
        Новость,
        [Display(Name = "Cтатья")]
        Статья,
        [Display(Name = "Видео")]
        Видео
        
    }
}
