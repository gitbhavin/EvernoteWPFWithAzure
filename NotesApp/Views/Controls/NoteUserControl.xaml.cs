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
    /// Interaction logic for NoteUserControl.xaml
    /// </summary>
    public partial class NoteUserControl : UserControl
    {


        public Note DispalyNote
        {
            get { return (Note)GetValue(noteProperty); }
            set { SetValue(noteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty noteProperty =
            DependencyProperty.Register("DispalyNote", typeof(Note), typeof(NoteUserControl), new PropertyMetadata(null,SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NoteUserControl noteUserControl = d as NoteUserControl;
            if (noteUserControl != null)
            {
               // noteUserControl.noteTitleTextBlock.Text = (e.NewValue as Note).Title;
               // noteUserControl.noteEditedTextBlock.Text = (e.NewValue as Note).UpdatedTime.ToShortDateString();
              //  noteUserControl.noteContentTextBlock.Text = (e.NewValue as Note).Title;
            }
        }

        public NoteUserControl()
        {
            InitializeComponent();
        }
    }
}
