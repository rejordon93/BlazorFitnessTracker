using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace FitnessTracker.Services
{
    public class UserServices
    {
        private readonly FitnessContext _context;

        public UserServices(FitnessContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUser(UserModel user)
        {
            // Check if user already exists
            var exists = await _context.Users
                .AnyAsync(u => u.Email == user.Email || u.Username == user.Username);
            if (exists) return false;

            // Hash the password before saving
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserModel?> AuthenticateUserAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            // Verify the hashed password
            bool verified = BCrypt.Net.BCrypt.Verify(password, user.Password);
            return verified? user: null;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUser(UserModel user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}