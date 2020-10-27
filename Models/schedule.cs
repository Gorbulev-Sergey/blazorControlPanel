using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Models
{
    [Table(name: "schedules")]
    public class schedule
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Год и месяц расписания")]
        public DateTime schedule_year_and_month { get; set; }
        [Display(Name ="Расписание на месяц")]
        public List<schedule_string> Schedule { get; set; }
        [Display(Name ="Дней в месяце")]
        public int days_in_month
        {
            get
            {
                return DateTime.DaysInMonth(schedule_year_and_month.Year, schedule_year_and_month.Month);
            }
        }

        public schedule(DateTime schedule_year_and_month)
        {
            this.schedule_year_and_month = schedule_year_and_month;
            Schedule = new List<schedule_string>(DateTime.DaysInMonth(schedule_year_and_month.Year, schedule_year_and_month.Month));
            for(int i=1; i<= days_in_month; i++)
            {
                Schedule.Add(new schedule_string {date_and_time = new DateTime(schedule_year_and_month.Year, schedule_year_and_month.Month, i, 0, 0, 0) });
            }
        }

        /// <summary>
        /// Метод, который позволяет получить значение атрибута "description" для этого enum
        /// </summary>
        public static string GetDescription(Enum enumElement)
        {
            Type type = enumElement.GetType();

            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumElement.ToString();
        }
    }




    [Table(name: "schedules_strings")]
    public class schedule_string
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Дата и время")]
        public DateTime date_and_time { get; set; }
        /// <summary>
        /// Праздник
        /// </summary>
        [Display(Name = "Праздник")]
        public string description { get; set; }
        /// <summary>
        /// Служба
        /// </summary>
        [Display(Name = "Служба")]
        public тип_службы prayer { get; set; }        
    }

    public enum тип_службы
    {
        [Description("")]
        пусто=0,
        [Description("Литургия")]
        Литургия=1,
        [Description("Всенощное бдение")]
        Всенощное_бдение=2,
        [Description("Молебен")]
        Молебен=3,
        [Description("Акафист")]
        Акафист=4,
        [Description("Панихида")]
        Панихида=5,
        [Description("Литургия, молебен")]
        Литургия_и_молебен=6,
        [Description("Литургия, панихида")]
        Литургия_и_панихида=7,
        [Description("Молебен с акафистом")]
        Молебен_с_акафистом=8
    }


}
