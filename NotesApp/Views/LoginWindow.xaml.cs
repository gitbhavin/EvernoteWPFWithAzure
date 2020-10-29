using NotesApp.ViewModels;
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
using System.Windows.Shapes;

namespace NotesApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginVM Vm = new LoginVM();
            ContainerGrid.DataContext = Vm;
            Vm.HasLogedIn += Vm_HasLogedIn;
        }

        private void Vm_HasLogedIn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void noAccountButton_Click(object sender, RoutedEventArgs e)
        {
            loginStackpanel.Visibility = Visibility.Collapsed;
            registerStackpanel.Visibility = Visibility.Visible;
        }

        private void haveAccountButton_Click(object sender, RoutedEventArgs e)
        {
            registerStackpanel.Visibility = Visibility.Collapsed;
            loginStackpanel.Visibility = Visibility.Visible;

        }
    }
}
