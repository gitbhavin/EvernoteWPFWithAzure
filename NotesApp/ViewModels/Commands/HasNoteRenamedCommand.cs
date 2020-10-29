using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModels.Commands
{
    public class HasNoteRenamedCommand : ICommand
    {
        public NotesVM VM { get; set; }
        public HasNoteRenamedCommand(NotesVM vm)
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
            Note note = parameter as Note;

            VM.HasNoteRenamed(note);
        }
    }
}
