using CORE.Models;
using INFRA.Infrastructure;
using INFRA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICE.Core
{

    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(string Username);
        User Create(User record);
        User Edit(User record);
        void Delete(User record);
        User Authentication(string username, string password);
        User GetUser(int id);
        User GetUser(string username);
        void SaveUser();

    }

    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public User Authentication(string username, string password)
        {
            return userRepository.Login(username, password);
        }

        public User Create(User record)
        {
            userRepository.Add(record);
            SaveUser();
            return record;
        }

        public void Delete(User record)
        {
            userRepository.Delete(record);
            SaveUser();

        }

        public User Edit(User record)
        {
            if(GetUser(record.Id) == null)
            {
                return null;
            }
            userRepository.Update(record);
            SaveUser();
            return record;
        }

        public User GetUser(int id)
        {
            return userRepository.GetById(id);
        }

        public User GetUser(string username)
        {
            return userRepository.GetByUsername(username);
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public IEnumerable<User> GetUsers(string Username)
        {
            return userRepository.GetAll(Username);
        }

        public void SaveUser()
        {
            unitOfWork.Commit() ;
        }
    }


}
