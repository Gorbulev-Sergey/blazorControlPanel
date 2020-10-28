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
        List<schedule_string> schedule_not_async(DateTime schedule_year_and_month);
        Task<List<schedule_string>> schedule(DateTime schedule_year_and_month);
        Task create(List<schedule_string> schedule);
        Task update(List<schedule_string> schedule);
        Task delete(List<schedule_string> schedule);
    }

    public class ScheduleService : ISchedulesService
    {
        private ApplicationDbContext _context;
        public ScheduleService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<schedule_string> schedule_not_async(DateTime schedule_year_and_month) 
        { 
            return _context.schedule.Where(s => s.date_and_time.Year == schedule_year_and_month.Year && s.date_and_time.Month == schedule_year_and_month.Month).ToList();

        }
        public async Task<List<schedule_string>> schedule(DateTime schedule_year_and_month)
        {
            return await _context.schedule.Where(s => s.date_and_time.Year == schedule_year_and_month.Year && s.date_and_time.Month == schedule_year_and_month.Month).ToListAsync();
        }
        public async Task create(List<schedule_string> schedule)
        {
            foreach (var str in schedule)
            {
                if (!String.IsNullOrEmpty(str.description) || str.prayer != тип_службы.пусто || str.date_and_time.ToString() == "0:00")
                {
                    _context.schedule.Add(str);
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task update(List<schedule_string> schedule)
        {
            //_context.Update<schedule>(schedule);
            //await _context.SaveChangesAsync();
        }
        public async Task delete(List<schedule_string> schedule)
        {
            //_context.schedules.Remove(schedule);
            //await _context.SaveChangesAsync();
        }

        
    }
}
