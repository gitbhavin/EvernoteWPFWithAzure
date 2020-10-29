using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Models
{
    public class Note : INotifyPropertyChanged
    {
        #region Properties
        private string  id;
        [PrimaryKey, AutoIncrement]
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private string notebokId;
        [Indexed]
        public string NotbookId
        {
            get { return notebokId; }
            set
            {
                notebokId = value;
                OnPropertyChanged("NotbookId");
            }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        private DateTime createdTime;

        public DateTime CreatedTime
        {
            get { return createdTime; }
            set
            {
                createdTime = value;
                OnPropertyChanged("CreatedTime");
            }
        }

        private DateTime updatedTime;

        public DateTime UpdatedTime
        {
            get { return updatedTime; }
            set
            {
                updatedTime = value;
                OnPropertyChanged("UpdatedTime");
            }
        }
        private string fileLocation;

        public string FileLocation
        {
            get { return fileLocation; }
            set
            {
                fileLocation = value;
                OnPropertyChanged("FileLocation");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
