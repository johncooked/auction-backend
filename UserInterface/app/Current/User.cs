using System;
using System.Collections.Generic;

using CAB201;
using MAIN;
using ITEM;

namespace CHECKUSER                  
{
    /// <summary>
    /// Take the user input and store it as a temporary instance.
    /// This is mainly for authenticating.
    /// </summary>
    public class User
    {
        public static bool loggedIn = false;
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string email, string password) 
        {
            this.Email = email;
            this.Password = password;
        }

        /// <summary>
        /// Sends out prompts and create a new user instance.
        /// </summary>
        public static void LoginUser()
        {
            string userEmail = UserInterface.GetInput("Email");
            string userPassword = UserInterface.GetPassword("Password");

            User newUser = new User(userEmail, userPassword);

            AuthUser(userEmail, userPassword);
        }

        /// <summary>
        /// Take the stored input as arguments.
        /// Search the UserData to see if the inputs exists and check if email and password matches for that user.
        /// </summary>
        public static void AuthUser(string _email, string _password)
        {
            if (UserData.dataEmail.Contains(_email))
            {

                string _name = " ";
                string passToCheck = " ";
                string emailToCheck = " ";

                for (int i = 0; i < UserData.dataEmail.Count; i++)
                {
                    if (UserData.dataEmail[i] == _email)
                    {
                        _name = UserData.dataName[i];
                        emailToCheck = UserData.dataEmail[i];
                        passToCheck = UserData.dataPassword[i];
                    }
    
                }

                if (_email == emailToCheck && _password == passToCheck)
                {
                    loggedIn = true;
                    Console.WriteLine($"\nWelcome {_name}!\n");
                    ItemData newInstItem = new ItemData();
                    Program.SubMenu();
                }
                else 
                {
                    loggedIn = false;
                    Console.WriteLine("\nEmail or Password incorrect!. Please try again.\n");
                    LoginUser();
                }
            }
            else 
            {
                loggedIn = false;
                Console.WriteLine("\nUser does not exist!\n");
                LoginUser();
            }
        }
        public static void LogoutUser()
        {
            Console.WriteLine("\nLogged out successfully!\n");
            loggedIn = false;
        }
    }
    /// <summary>
    /// Store users for the current runtime.
    /// Will lose all data console is restarted.
    /// </summary>
    public class UserData
    {
        public static List<string> dataName { get; set; }
        public static List<string> dataEmail { get; set; }
        public static List<string> dataAddress { get; set; }
        public static List<string> dataPassword { get; set; }

        /// Store the all items
        public static List<string> myItem { get; set; }
        public static List<string> myItemDescription { get; set; }
        public static List<int> myItemCost{ get; set; }


        public UserData()
        {
            dataName = new List<string>();
            dataEmail = new List<string>();
            dataAddress = new List<string>();
            dataPassword = new List<string>();

            myItem = new List<string>();
            myItemDescription = new List<string>();
            myItemCost = new List<int>();
        }

        /// Method that takes field inputs class and add it to data
        public void AddUser(string _name, string _email, string _address, string _password)
        {
            dataName.Add(_name);
            dataEmail.Add(_email);
            dataAddress.Add(_address);
            dataPassword.Add(_password);
        }

        /// Prompt user for inputs and store the inputs.
        public void RegisterUser()
        {
            string fullName = UserInterface.GetInput("Full Name");
            string userEmail = UserInterface.GetInput("Email");

            /// Check if data already exists
            if (dataEmail.Contains(userEmail)) 
            {
                Console.WriteLine("\nEmail already in use! Please use another email.\n");
                userEmail = UserInterface.GetInput("Email");

            }

            string userAddress = UserInterface.GetInput("Adress");
            string userPassword = UserInterface.GetInput("Password");

            AddUser(fullName, userEmail, userAddress, userPassword);

            Console.WriteLine($"\nUser {fullName} registered successfully.\n");
        }

        /// <summary>
        /// Search myItem database and list all the items
        /// </summary>
        public static void SearchItem() 
        {
            string _itemName = UserInterface.GetInput("Item Name");

            string items = "";

            for (int i = 0; i < myItem.Count; i++) 
            {
                if (myItem[i] == _itemName)
                {
                    items += $"   {i + 1}. {myItem[i]}, {myItemDescription[i]} - ${myItemCost[i]}\n";
                }
            }

            if (items == "")
            {
                Console.WriteLine("\nItem not found.\n");
            }
            else 
            {
                Console.WriteLine($"\nItems listed:\n{items}");
            }
        }
    }
}
