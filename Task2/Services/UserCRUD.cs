using Data;
using Services.DTOModels;
using System.Collections.Generic;
using System.Linq;
using Data.API;

namespace Services
{
   public class UserCRUD
    {
        private IDataApi repository;

        public UserCRUD()
        {
            repository = new Repository();
        }


        private static UserDTO Map(IUser user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }



        public bool AddUser(int id, string firstName, string lastName)
        {
            repository.AddUser(id, firstName, lastName);

            return true;
        }

        public bool AddUser(string firstName, string lastName)
        {
            repository.AddUser(firstName, lastName);

            return true;
        }

        public UserDTO GetUser(int id)
        {
            return Map(repository.GetUser(id));
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = repository.GetAllUsers();
            var result = new List<UserDTO>();

            foreach (var user in users)
            {
                result.Add(Map(user));
            }

            return result;
        }

        public bool UpdateFirstName(int id, string firstName)
        {
            repository.UpdateUserFirstName(id, firstName);
            
            return true;
        }

        public bool UpdateLastName(int id, string lastName)
        {
            repository.UpdateUserLastName(id, lastName);

            return true;
        }

        public bool DeleteUser(int id)
        {
            repository.DeleteUser(id);

            return true;
        }
    }

}
