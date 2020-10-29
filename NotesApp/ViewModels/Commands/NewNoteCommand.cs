using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModels.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NotesVM VM { get; set; }
        public NewNoteCommand(NotesVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            NoteBook noteBook = parameter as NoteBook;
            if(noteBook!=null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            ///TODO:
            ///

            NoteBook selectedNotebook = parameter as NoteBook;
            VM.CreateNewNote(selectedNotebook.Id);
            
        }
    }
}
