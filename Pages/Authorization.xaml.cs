using Practica5.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Practica5
{
    /// <summary>
    /// Логика взаимодействия для NirrerPage.xaml
    /// </summary>
    public partial class Authorization : Page
    {
       
        public static User user;
        public Authorization()
        {
            InitializeComponent();      
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JEDKIYDataSet2TableAdapters.USsERTableAdapter userAdapter = new JEDKIYDataSet2TableAdapters.USsERTableAdapter();
            userAdapter.Fill(MainWindow.ds.USsER);

            if (MainWindow.ds.USsER.Count(x => x.Login == LoginTB.Text && x.Password == PasswordTB.Password) > 0)
            {
                user = new User(MainWindow.ds.USsER.FirstOrDefault(x => x.Login == LoginTB.Text && x.Password == PasswordTB.Password));
                if (user.Role == 1)
                    NavigationService.Navigate(new AdminMainPage());
                else if (user.Role == 2)
                    NavigationService.Navigate(new UserMainPage());
            }
           else MessageBox.Show("Не удалось войти, логин и пароль не найдены. Попробуйте изменить их и зайти снова.", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void _1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
