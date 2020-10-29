using NotesApp.Models;
using NotesApp.ViewModels.Commands;
using NotesApp.ViewModels.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModels
{
    public class NotesVM : INotifyPropertyChanged
    {

        private bool isEditing;

        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                OnPropertyChanged("IsEditing");
            }
        }

        private bool isNoteEditing;

        public bool IsNoteEditing
        {
            get { return isNoteEditing; }
            set
            {
                isNoteEditing = value;
                OnPropertyChanged("IsNoteEditing");
            }
        }

        //private ObservableCollection<NoteBook> noteBooks;
        //public ObservableCollection<NoteBook> Notebooks
        //{
        //    get
        //    {
        //        return noteBooks;
        //    }
        //    set
        //    {
        //        noteBooks = value;
        //        OnPropertyChanged("Notebooks");
        //    }
        //}

        public ObservableCollection<NoteBook> Notebooks { get; set; }
        private NoteBook selectedNotebook;

        public NoteBook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                //TODO : get notes
                OnPropertyChanged("SelectedNotebook");
                ReadNotes();
            }
        }

        private ObservableCollection<Note> notes;

        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged("Notes");
            }
        }

        private Note selectedNote;

        public Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value;
                OnPropertyChanged("SelectedNote");
                SelectedNoteChanged(this, new EventArgs());
            }
        }


        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public RenameNoteBookCommand RenameNoteBookCommand { get; set; }
        public HasNotebookRenamedCommand HasNotebookRenamedCommand { get; set; }
        public RenameNoteCommand RenameNoteCommand { get; set; }
        public HasNoteRenamedCommand HasNoteRenamedCommand { get; set; }
        public DeleteNotebookCommand DeleteNotebookCommand { get; set; }
        public DeleteNoteCommand DeleteNoteCommand { get; set; }


        public event EventHandler SelectedNoteChanged;
        public NotesVM()
        {
            IsEditing = false;
            IsNoteEditing = false;

            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            RenameNoteBookCommand = new RenameNoteBookCommand(this);
            HasNotebookRenamedCommand = new HasNotebookRenamedCommand(this);
            DeleteNotebookCommand = new DeleteNotebookCommand(this);
            RenameNoteCommand = new RenameNoteCommand(this);
            HasNoteRenamedCommand = new HasNoteRenamedCommand(this);
            DeleteNoteCommand = new DeleteNoteCommand(this);

            Notebooks = new ObservableCollection<NoteBook>();
            Notes = new ObservableCollection<Note>();

            ReadNoteBooks();
            ReadNotes();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void ReadNoteBooks()
        {
            #region Commented Code
            //using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            //{
            //    conn.CreateTable<NoteBook>();

            //    //int userid = int.Parse(App.UserId);
            //    var notebooks = conn.Table<NoteBook>().ToList();
            //    Notebooks.Clear();
            //    if (notebooks != null)
            //    {
            //        foreach (var notebook in notebooks)
            //        {
            //            Notebooks.Add(notebook);
            //        }
            //    }

            //}
            #endregion

            var notebooks = await App.mobileServiceClient.GetTable<NoteBook>().OrderBy(n=>n.Name).ToListAsync();
            Notebooks.Clear();
            if (notebooks != null)
            {
                foreach (var notebook in notebooks)
                {
                    Notebooks.Add(notebook);
                }
            }

        }

        public async void ReadNotes()
        {
            //using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            //{
            //    if (selectedNotebook != null)
            //    {
            //        conn.CreateTable<Note>();
            //        var notes = conn.Table<Note>().Where(n => n.NotbookId == selectedNotebook.Id).ToList();
            //        Notes.Clear();
            //        if (notes != null)
            //        {
            //            foreach (var note in notes)
            //            {
            //                Notes.Add(note);
            //            }
            //        }
            //    }

            //}

            if (SelectedNotebook != null)
            {
                var notes = await App.mobileServiceClient.GetTable<Note>().Where(n => n.NotbookId == selectedNotebook.Id).OrderBy(n=>n.Title).ToListAsync();
                Notes.Clear();
                if (notes != null)
                {
                    foreach (var note in notes)
                    {
                        Notes.Add(note);
                    }
                }
            }

        }
        public async void CreateNewNotebook()
        {
            NoteBook newNotebook = new NoteBook()
            {
                UserId = App.UserId,
                Name = "New NoteBook"
            };
            await DatabaseHelper.Insert(newNotebook);
            ReadNoteBooks();
        }
        public async void CreateNewNote(string id)
        {
            Note newNote = new Note()
            {
                NotbookId = id,
                Title = "New Note",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now

            };
            await DatabaseHelper.Insert(newNote);
            ReadNotes();
        }

        public void StartEditing()
        {
            IsEditing = true;
        }

        public async void HasRenamed(NoteBook noteBook)
        {
            //if (noteBook != null)
            //{
            //    DatabaseHelper.Update(noteBook);
            //    IsEditing = false;
            //    ReadNoteBooks();
            //}

            if (noteBook != null)
            {
                await DatabaseHelper.Update(noteBook);
                IsEditing = false;
                ReadNoteBooks();
            }
        }

        public async void  DeleteNotebook(NoteBook noteBook)
        {
            //if (noteBook != null)
            //{
            //    DatabaseHelper.Delete(noteBook);
            //    Notebooks.Remove(noteBook);
            //    ReadNoteBooks();
            //}

            if(noteBook!=null)
            {
                await DatabaseHelper.Delete(noteBook);
                Notebooks.Remove(noteBook);
                ReadNoteBooks();
            }
        }

        public async void UpdateSelectedNote()
        {
            await DatabaseHelper.Update(selectedNote);
        }

        public async void HasNoteRenamed(Note note)
        {
            //if (note != null)
            //{
            //    DatabaseHelper.Update(note);
            //    IsNoteEditing = false;
            //    ReadNotes();
            //}

            if(note!=null)
            {
                await DatabaseHelper.Update(note);
                IsNoteEditing = false;
                ReadNotes();
            }
        }
        public void RenameNote()
        {
            IsNoteEditing = true;
        }

        public async void DeleteNote(Note note)
        {
            //if (note != null)
            //{
            //    DatabaseHelper.Delete(note);
            //    ReadNotes();
            //}

            if(note!=null)
            {
                await DatabaseHelper.Delete(note);
                ReadNotes();
            }
        }
    }
}
