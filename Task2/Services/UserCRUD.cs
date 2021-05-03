using Data;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
   public class UserCRUD
    {
        public UserCRUD()
        {
        }

        static public bool AddUser(int id, string firstName, string lastName)
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

        static public user GetUser(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (user user in context.users.ToList())
                {
                    if (user.user_id == id)
                    {
                        return user;
                    }
                }

                return null;
            }
        }

        static public IEnumerable<user> GetAllUsers()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var result = context.users.ToList();

                return result;
            }
        }

        static public IEnumerable<user> GetUsersByFirstName(string firstName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<user> result = new List<user>();

                foreach (user user in context.users)
                {
                    if (user.user_first_name.Equals(firstName))
                    {
                        result.Add(user);
                    }
                }

                return result;
            }
        }

        static public user GetUserByLastName(string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<user> result = new List<user>();

                foreach (user user in context.users)
                {
                    if (user.user_last_name.Equals(lastName))
                    {
                        return user;
                    }
                }

                return null;
            }
        }

        static public user GetUserByNames(string firstName, string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (user user in context.users.ToList())
                {
                    if (user.user_first_name == firstName && user.user_last_name == lastName)
                    {
                        return user;
                    }
                }

                return null;
            }
        }

        static public List<Dictionary<string, string>> GetUsersInfo()
        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();

            List<user> tempUsers = GetAllUsers().ToList();

            foreach (user user in tempUsers)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();

                temp.Add("firstName", user.user_first_name);
                temp.Add("id", user.user_id.ToString());
                temp.Add("l_name", user.user_last_name);

                returnList.Add(temp);
            }

            return returnList;
        }

        static public Dictionary<string, string> GetUserInfo(int user_id)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();

            user user = GetUser(user_id);

            temp.Add("id", user.user_id.ToString());
            temp.Add("firstName", user.user_first_name);
            temp.Add("lastName", user.user_last_name);

            return temp;
        }

        static public bool UpdateFirstName(int id, string firstName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = context.users.SingleOrDefault(usr => usr.user_id == id);

                user.user_first_name = firstName;

                context.SubmitChanges();

                return true;
            }
        }

        static public bool UpdateLastName(int id, string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = context.users.SingleOrDefault(usr => usr.user_id == id);

                user.user_last_name = lastName;

                context.SubmitChanges();

                return true;
            }
        }

        static public bool DeleteUser(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = context.users.SingleOrDefault(usr => usr.user_id == id);

                context.users.DeleteOnSubmit(user);

                context.SubmitChanges();

                return true;
            }
        }
    }

}
