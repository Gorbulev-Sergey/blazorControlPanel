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
            imageAlbums = new List<imageAlbum>();
            comments = new List<comment>();
            likes = new List<like>();
        }
        [PersonalData, Display(Name = "Публикации")]
        public virtual IList<post> posts { get; set; }
        [PersonalData, Display(Name = "Албомы фотографий")]
        public virtual IList<imageAlbum> imageAlbums { get; set; }
        [PersonalData, Display(Name = "Комментарии")]
        public virtual IList<comment> comments { get; set; }
        [PersonalData, Display(Name = "Лайки")]
        public virtual IList<like> likes { get; set; }
    }
}
