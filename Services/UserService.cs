using System;
using System.Collections.Generic;
using MusicLibrary.Models;
using MusicLibrary.Repositories;
using MusicLibrary.Services;



namespace MusicLibrary.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetUserByEmail(string email);
        void AddUser(String email, String name, String password);
        void UpdateUserName(String email, string newUsername);
        void UpdateUserPassword(String email, String newPassword);
        void DeleteUser(String email);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetUserByEmail(String email)
        {
            User user = _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            return user;
        }

        public void AddUser(String email, String name, String password)
        {
            _userRepository.AddUser(email, name, password);
            _userRepository.SaveChanges();
        }

        public void UpdateUserName(String email, String newUsername)
        {
            _userRepository.UpdateUserName(email, newUsername);
            _userRepository.SaveChanges();
        }

        public void UpdateUserPassword(String email, String newUserpassword)
        {
            _userRepository.UpdateUserPassword(email, newUserpassword);
            _userRepository.SaveChanges();
        }

        public void DeleteUser(String email)
        {
            User userToDelete = _userRepository.GetUserByEmail(email);

            if(userToDelete != null)
            {
                _userRepository.DeleteUser(email);
                _userRepository.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Album not found");
            }
        }
    }
}
