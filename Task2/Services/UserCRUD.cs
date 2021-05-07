using Data;
using Services.DTOModels;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
   public class UserCRUD
    {
        public UserCRUD()
        {
        }

        private static UserDTO Map(user user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = user.user_id,
                FirstName = user.user_first_name,
                LastName = user.user_last_name
            };
        }



        public bool AddUser(int id, string firstName, string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user newUser = new user
                {
                    user_id = id,
                    user_first_name = firstName,
                    user_last_name = lastName
                };

                context.users.InsertOnSubmit(newUser);
                context.SubmitChanges();

                return true;
            }
        }

        public bool AddUser(string firstName, string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user newUser = new user
                {
                    user_id = context.users.Count() + 1,
                    user_first_name = firstName,
                    user_last_name = lastName
                };

                context.users.InsertOnSubmit(newUser);
                context.SubmitChanges();

                return true;
            }
        }

        public UserDTO GetUser(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = context.users.FirstOrDefault(u => u.user_id == id);

                return Map(user);
            }
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var users = context.users.ToList();
                var result = new List<UserDTO>();

                users.ForEach(delegate (user user)
                {
                    result.Add(Map(user));
                });

                return result;
            }
        }

        public IEnumerable<UserDTO> GetUsersByFirstName(string firstName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var users = from user in context.users
                               where user.user_first_name == firstName
                               select Map(user);

                return users.ToList();
            }
        }

        public UserDTO GetUserByLastName(string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = context.users.FirstOrDefault(u => u.user_last_name == lastName);

                return Map(user);
            }
        }

        public UserDTO GetUserByNames(string firstName, string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = context.users.FirstOrDefault(u => 
                    u.user_first_name == firstName && u.user_last_name == lastName);

                return Map(user);
            }
        }

        //static public List<Dictionary<string, string>> GetUsersInfo()
        //{
        //    List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();

        //    List<user> tempUsers = GetAllUsers().ToList();

        //    foreach (user user in tempUsers)
        //    {
        //        Dictionary<string, string> temp = new Dictionary<string, string>();

        //        temp.Add("firstName", user.user_first_name);
        //        temp.Add("id", user.user_id.ToString());
        //        temp.Add("l_name", user.user_last_name);

        //        returnList.Add(temp);
        //    }

        //    return returnList;
        //}

        //static public Dictionary<string, string> GetUserInfo(int user_id)
        //{
        //    Dictionary<string, string> temp = new Dictionary<string, string>();

        //    user user = GetUser(user_id);

        //    temp.Add("id", user.user_id.ToString());
        //    temp.Add("firstName", user.user_first_name);
        //    temp.Add("lastName", user.user_last_name);

        //    return temp;
        //}

        public bool UpdateFirstName(int id, string firstName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = context.users.FirstOrDefault(usr => usr.user_id == id);

                user.user_first_name = firstName;

                context.SubmitChanges();

                return true;
            }
        }

        public bool UpdateLastName(int id, string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = context.users.FirstOrDefault(usr => usr.user_id == id);

                user.user_last_name = lastName;

                context.SubmitChanges();

                return true;
            }
        }

        public bool DeleteUser(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = context.users.FirstOrDefault(usr => usr.user_id == id);

                context.users.DeleteOnSubmit(user);

                context.SubmitChanges();

                return true;
            }
        }
    }

}
