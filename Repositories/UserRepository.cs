using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetUserByEmail(string email);
        void AddUser(String email, String name, String password);
        void UpdateUserName(String email, string newUsername);
        void UpdateUserPassword(String email, String newPassword);
        void DeleteUser(String email);
        void SaveChanges();
    }
    public class UserRepository : IUserRepository
    {
        private readonly MusicLibraryContext _dbContext;

        public UserRepository(MusicLibraryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users.Find(email);
        }

        public void AddUser(String email, String name, String password)
        {
            User newUser = new User(email, name, password);
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public void UpdateUserName(String email, String newUserName)
        {
            User user = GetUserByEmail(email);

            if(user != null)
            {
                user.Name = newUserName;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }

        }

        public void UpdateUserPassword(String email, String newUserPassword)
        {
            User user = GetUserByEmail(email);

            if (user != null)
            {
                user.Password = newUserPassword;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }

        }

        public void DeleteUser(String email) 
        { 
            User userToDelete = GetUserByEmail(email);  

            if(userToDelete != null)
            {
                _dbContext.Users.Remove(userToDelete);
                _dbContext.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
