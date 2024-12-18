﻿using PasswordManager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PasswordManager.Models
{
    public class ManagerRepo
    {
        // A list of the passwords the manager has
        private List<Manager> manager = new List<Manager>();

        public ManagerRepo()
        {
            // Loads the txt file
            ReadTxTFile();
        }

        // Reads the txt file
        private void ReadTxTFile()
        {
            // Creates a .txt file if you dont already have one created
            if (!File.Exists("Passwords.txt"))
            {
                // Create the file
                using (StreamWriter sw = File.CreateText("Passwords.txt"))
                {

                }
            }

            // Tries to save the details to the .txt file.
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Passwords.txt"))
                {
                    // Read the stream to a string, and instantiate a Person object
                    String line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        // parts[0] contains Name
                        // parts[1] contains Username
                        // parts[2] contains Password
                        Add(parts[0], parts[1], (parts[2]));

                        //Read the next line
                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        // Saves the passwords to the txt file
        public void SaveTxTFile()
        {
            using (StreamWriter sw = new StreamWriter("Passwords.txt"))
            {
                foreach (Manager manager in manager)
                {
                    sw.WriteLine($"{manager.Name},{manager.Username},{manager.Password}");
                }
            }
        }

        public Manager Get(int id)
        {
            Manager result = null;

            foreach (Manager manager in manager)
            {
                if (manager.Id == id)
                {
                    result = manager;
                    break;
                }
            }

            return result;
        }

        public List<Manager> GetAll()
        {
            return manager;
        }

        public void Update(int ID, string name, string username, string password)
        {
            Manager manager = Get(ID);
            manager.Name = name;
            manager.Username = username;
            manager.Password = password;
        }

        public Manager Add(string name, string username, string password)
        {
            Manager result = null;

            if (!string.IsNullOrEmpty(name)
                && !string.IsNullOrEmpty(username)
                && !string.IsNullOrEmpty(password))
            {
                result = new Manager()
                {
                    Name = name,
                    Username = username,
                    Password = password,
                };

                // Add to managers list
                manager.Add(result);
            }
            else
            {
                throw (new ArgumentException("Not all arguments are valid"));
            }
            return result;
        }

        public void Remove(int id)
        {
            // Find the person in the internal persons list with same Id as the 'id'-parameter
            Manager foundManager = Get(id);

            if (foundManager != null)
            {
                manager.Remove(foundManager);
            }
            else
            {
                throw (new ArgumentException("Person with id = " + id + " not found"));
            }
        }

    }
}
