using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModels.Commands
{
    public class HasNotebookRenamedCommand : ICommand
    {
        public NotesVM VM { get; set; }
        public HasNotebookRenamedCommand(NotesVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NoteBook noteBook = parameter as NoteBook;
            VM.HasRenamed(noteBook);
        }
    }
}
