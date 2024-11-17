using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.ViewModels
{
    public class ManagerViewModel
    {
        // An instance of my manager class
        private Manager manager;

        // Properties
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor for what the user will see on the view model
        public ManagerViewModel(Manager manager)
        {
            this.manager = manager;
            Name = manager.Name;
            Username = manager.Username;
            Password = manager.Password;
        }

        // Deletes the password at the given position
        public void DeleteManager(ManagerRepo managerRepo)
        {
            managerRepo.Remove(manager.Id);
        }

        // Saves all passwords
        public void SaveManager(ManagerRepo managerRepo)
        {
            managerRepo.SaveTxTFile(manager.Name, manager.Username, manager.Password);
        }
    }
}
