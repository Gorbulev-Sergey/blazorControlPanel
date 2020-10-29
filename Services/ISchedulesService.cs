using blazorControlPanel.Data;
using blazorControlPanel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Services
{
    interface ISchedulesService
    {
        List<schedule_string> schedule(DateTime schedule_year_and_month);
        Task update_or_create(List<schedule_string> schedule);
        Task delete(List<schedule_string> schedule);
    }

    public class ScheduleService : ISchedulesService
    {
        private ApplicationDbContext _context;
        public ScheduleService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<schedule_string> schedule(DateTime schedule_year_and_month) 
        { 
            return _context.schedule.Where(s => s.date_and_time.Year == schedule_year_and_month.Year && s.date_and_time.Month == schedule_year_and_month.Month).OrderBy(d=>d.date_and_time).ToList();
        }
        public async Task update_or_create(List<schedule_string> schedule)
        {
            foreach (var str in schedule)
            {
                // сохраняем или меняем
                if (!String.IsNullOrEmpty(str.description) || !String.IsNullOrWhiteSpace(str.description) || str.prayer != тип_службы.пусто || str.date_and_time.ToString() == "0:00")
                {                    
                    try
                    {
                        _context.Update(str);
                    }
                    catch
                    {
                        _context.schedule.Add(str);
                    }
                }
            }
            await _context.SaveChangesAsync();

            foreach (var str in _context.schedule)
            {
                // Очищаем пустые строки в бд, которые могли попасть после обновления данных
                if (String.IsNullOrEmpty(str.description) && str.prayer == тип_службы.пусто && str.date_and_time.ToShortTimeString() == "0:00")
                {
                    try
                    {
                        _context.Remove(str);
                    }
                    catch
                    {

                    }
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task delete(List<schedule_string> schedule)
        {
            foreach (var str in schedule)
            {
                try { _context.schedule.Remove(str); }
                catch { }
            }
            await _context.SaveChangesAsync();
        }

        
    }
}
