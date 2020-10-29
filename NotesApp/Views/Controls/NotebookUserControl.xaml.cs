using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotesApp.Views.Controls
{
    /// <summary>
    /// Interaction logic for NotebookUserControl.xaml
    /// </summary>
    public partial class NotebookUserControl : UserControl
    {


        public NoteBook DisplayNotebook
        {
            get { return (NoteBook)GetValue(notebookProperty); }
            set { SetValue(notebookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty notebookProperty =
            DependencyProperty.Register("DisplayNotebook", typeof(NoteBook), typeof(NotebookUserControl), new PropertyMetadata(new NoteBook() { Name = "Default Notebook", Id = "1", UserId = "1" }, 
                                                                                                                        SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NotebookUserControl notebookUserControl = d as NotebookUserControl;

            if (notebookUserControl != null)
            {
              //  notebookUserControl.notebookNameTextBlock.Text = (e.NewValue as NoteBook).Name;
            }
        }

        public NotebookUserControl()
        {
            InitializeComponent();
        }
    }
}
