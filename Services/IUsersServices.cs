using blazorControlPanel.Data;
using blazorControlPanel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Services
{
    interface IUsersServices
    {
        Task<List<string>> rolesAsync(user user);
        void update(user user, string role);
    }

    public class UsersServices : IUsersServices
    {
        ApplicationDbContext _context;
        UserManager<user> _userManager;

        public UsersServices(ApplicationDbContext context, UserManager<user> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<string>> rolesAsync(user user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public void update(user user, string role)
        {
            _userManager.AddToRoleAsync(user, role);
            _context.SaveChanges();
        }
    }
}
