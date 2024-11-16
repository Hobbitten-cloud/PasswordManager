using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PasswordManager.Models
{
    public class Manager
    {
        // idCount maintains a counter assigned as Id to each new Person-object and 
        // then incremented so that each Person-object has a unique Id number
        private static int idCount = 0;

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // Id to identify what number a specific password has in the list
        public int Id { get; set; }

        // Everytime a password manager is created the Id increases
        public Manager()
        {
            Id = idCount++;
        }

        public override string ToString()
        {
            return $"{Id}: {Name}: {Username}: {Password}: {Email}";
        }
    }
}
