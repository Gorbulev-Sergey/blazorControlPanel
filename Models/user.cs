using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Models
{
    public class user : IdentityUser
    {
        public user()
        {
            posts = new List<post>();
            imageAlbums = new List<imagesAlbum>();
            comments = new List<comment>();
            likes = new List<like>();
            schedule = new List<schedule_string>();
        }
        [PersonalData, Display(Name = "Публикации")]
        public virtual IList<post> posts { get; set; }
        [PersonalData, Display(Name = "Албомы фотографий")]
        public virtual IList<imagesAlbum> imageAlbums { get; set; }
        [PersonalData, Display(Name = "Комментарии")]
        public virtual IList<comment> comments { get; set; }
        [PersonalData, Display(Name = "Лайки")]
        public virtual IList<like> likes { get; set; }
        [PersonalData, Display(Name = "Расписания")]
        public virtual IList<schedule_string> schedule { get; set; }
    }
}
