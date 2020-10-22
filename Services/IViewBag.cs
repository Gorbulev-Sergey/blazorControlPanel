using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Services
{
    public interface IViewBag
    {
        string заголовок_страницы { get; set; }
        event Action Заголовок_обновлён;
        void Обновить_заголовок();
    }

    public class ViewBag : IViewBag
    {
        private string _Заголовок_страницы;
        public string заголовок_страницы 
        {
            get { return _Заголовок_страницы; }
            set {
                _Заголовок_страницы = value;
            }
        }

        public event Action Заголовок_обновлён;

        public void Обновить_заголовок()
        {
            Заголовок_обновлён?.Invoke();
        }
    }
}
