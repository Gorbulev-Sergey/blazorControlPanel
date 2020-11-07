using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Services
{
    public interface IViewBag
    {
        string заголовок_страницы { get; set; }
        event Action Заголовок_изменён;
    }
        
    public class ViewBag : IViewBag
    {
        private string _Заголовок_страницы;
        public event Action Заголовок_изменён;
        public string заголовок_страницы 
        {
            get { return _Заголовок_страницы; }
            set {
                _Заголовок_страницы = value;
                Заголовок_изменён?.Invoke();
            }
        }
    }
}
