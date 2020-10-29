using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModels.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public RegisterCommand(LoginVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            Users user = parameter as Users;
            // return true;

            if (user != null)
            {
                if (string.IsNullOrWhiteSpace(user.UserName)
                     || string.IsNullOrWhiteSpace(user.Name)
                     || string.IsNullOrWhiteSpace(user.LastName)
                     || string.IsNullOrWhiteSpace(user.Email)
                     || string.IsNullOrWhiteSpace(user.Password))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public void Execute(object parameter)
        {
            VM.Register();
        }
    }
}
