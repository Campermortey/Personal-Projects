using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringPogram.Data;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;
using FlooringProgram.UI.WorkFlows;
using Ninject;

namespace FlooringProgram.UI
{
    public class Menu
    {
        //AddOrder add = new AddOrder();
        //DisplayOrder display = new DisplayOrder(new OrderRepository());
        //EditOrder edit = new EditOrder(new OrderRepository());
        //RemoveOrder remove = new RemoveOrder(new OrderRepository());

        private IKernel _kernel;

        private string _userChoice;

        public IKernel ConfigureIOC()
        {
            
            string mode = ConfigurationManager.AppSettings["Mode"];

            if (mode == "Test")
               return _kernel = new StandardKernel(new FlooringProgramTestModule());

            else
            {
                return _kernel = new StandardKernel(new FloorProgramRealModule());
            }
            

        }

        public void StartApplication()
        {
            ConfigureIOC();
            do
            {
                DisplayMenu();

                //sets the userChoice to the PromptUser()
                _userChoice = PromptUser();
                ExecuteChoice(_userChoice);

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

            } while (_userChoice != "5");
        }

        /// <summary>
        /// Allows the user to choose a selection
        /// </summary>
        /// <param name="userChoice"></param>
        private void ExecuteChoice(string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    DisplayOrder display = _kernel.Get<DisplayOrder>();
                    display.Execute();
                    break;
                case "2":
                    AddOrder add = _kernel.Get<AddOrder>();
                    add.Execute();
                    break;
                case "3":
                    EditOrder edit = _kernel.Get<EditOrder>();
                     edit.Execute();
                    break;
                case "4":
                    RemoveOrder remove = _kernel.Get<RemoveOrder>();
                    remove.Execute();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("That was not a valid input.");
                    break;
            }
        }

        private string PromptUser()
        {
            Console.WriteLine();
            //get userinput from the user
            Console.Write("Enter you choice: " );
            return Console.ReadLine();
        }

        //Displays a list of possible options
        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Flooring Manager");
            Console.WriteLine("- - - - - - - - - - - - - - - - -");
            Console.WriteLine("1) Display Orders");
            Console.WriteLine("2) Add an Order");
            Console.WriteLine("3) Edit an Order");
            Console.WriteLine("4) Remove an Order");
            Console.WriteLine("5) Quit");
        }
    }
}
