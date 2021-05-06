using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Services;

namespace Presentation.Model
{
    class UserModel
    {
        static ObservableCollection<UserModel> models;

        public UserModel()
        {
        }


        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public static ObservableCollection<UserModel> GetUsers()
        {
            models = (ObservableCollection<UserModel>)UserCRUD.GetAllUsers();

            return models;
        }
    }
}
