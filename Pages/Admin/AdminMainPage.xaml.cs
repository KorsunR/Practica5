using Practica5.JEDKIYDataSet2TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Practica5.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        List<TextBlock> tableLinks;
      
        public AdminMainPage()
        {
            InitializeComponent();
            
        }

        private void getSquare(int count, ref int N, ref int M)
        {
            N = (int)Math.Sqrt(count);

            int i = N;
            for(; i > 1; i--)
                if(count % i == 0)
                {
                    N = i;
                    M = count / N;
                    return;
                }

            if (i == 1)
            {
                getSquare(count + 1, ref N, ref M);
            }
        }

        public string addSpaces(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return string.Empty;
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(inputString[0]);

            for (int i = 1; i < inputString.Length; i++)
            {
                if (char.IsUpper(inputString[i]))
                {
                    stringBuilder.Append(" ");
                }

                stringBuilder.Append(inputString[i]);
            }

            return stringBuilder.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tableLinks = new List<TextBlock>();
            int row = 0;
            int column = 0;
            int maxRows = 0;
            int maxColumns = 0;

            getSquare(MainWindow.ds.Tables.Count, ref maxRows, ref maxColumns);

            AdminMainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            foreach (var table in MainWindow.ds.Tables)
            {
                TextBlock newLabel = new TextBlock();
                newLabel.Text = table.ToString() == "USsER" ? "Список пользователей" : addSpaces(table.ToString());
                newLabel.TextWrapping= TextWrapping.Wrap;
                newLabel.HorizontalAlignment= HorizontalAlignment.Stretch;
                newLabel.VerticalAlignment = VerticalAlignment.Center;
                newLabel.FontSize = 18;
                newLabel.TextAlignment= TextAlignment.Center;   
                

                Border border= new Border();
                border.BorderBrush = Brushes.BlanchedAlmond;
                border.BorderThickness = new Thickness(3);
                border.Child = newLabel;
                border.Margin= new Thickness(10,10,10,10);
                border.Cursor = Cursors.Hand;
                border.Background = Brushes.White;

                border.Tag = table;
                border.MouseLeftButtonDown += Border_MouseLeftButtonDown;

                tableLinks.Add(newLabel);

                if(AdminMainGrid.ColumnDefinitions.Count != maxColumns)
                    AdminMainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
             
                border.SetValue(Grid.RowProperty, row);
                border.SetValue(Grid.ColumnProperty, column);
                

                column++;
                if (column == maxColumns)
                {
                    column = 0;
                    row++;
                    AdminMainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                }

                AdminMainGrid.Children.Add(border);

            }

   

        }

        private void SelectPage(object sender, ref DataGrid dataGrid)
        {
            //-----------------
            if ((sender as Border).Tag.ToString() == "USsER")
            {
                USsERTableAdapter userAdapter = new USsERTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.USsER);
                dataGrid.ItemsSource = ds.Tables["USsER"].DefaultView;
            }

            //-----------------       

            if ((sender as Border).Tag.ToString() == "Законодательство")
            {
                ЗаконодательствоTableAdapter userAdapter = new ЗаконодательствоTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.Законодательство);
                dataGrid.ItemsSource = ds.Tables["Законодательство"].DefaultView;
            }

            //-----------------      

            if ((sender as Border).Tag.ToString() == "ИсполнителиОрганыМетногоСамоуправления")
            {
                ИсполнителиОрганыМетногоСамоуправленияTableAdapter userAdapter = new ИсполнителиОрганыМетногоСамоуправленияTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.ИсполнителиОрганыМетногоСамоуправления);
                dataGrid.ItemsSource = ds.Tables["ИсполнителиОрганыМетногоСамоуправления"].DefaultView;
            }

            //-----------------      

            if ((sender as Border).Tag.ToString() == "ИсполнительныеОрганы")
            {
                ИсполнительныеОрганыTableAdapter userAdapter = new ИсполнительныеОрганыTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.ИсполнительныеОрганы);
                dataGrid.ItemsSource = ds.Tables["ИсполнительныеОрганы"].DefaultView;
            }

            //-----------------      

            if ((sender as Border).Tag.ToString() == "Правительство")
            {
                ПравительствоTableAdapter userAdapter = new ПравительствоTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.Правительство);
                dataGrid.ItemsSource = ds.Tables["Правительство"].DefaultView;
            }

            //-----------------      

            if ((sender as Border).Tag.ToString() == "ПредставительныеОрганыМетногоСамоуправления")
            {
                ПредставительныеОрганыМетногоСамоуправленияTableAdapter userAdapter = new ПредставительныеОрганыМетногоСамоуправленияTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.ПредставительныеОрганыМетногоСамоуправления);
                dataGrid.ItemsSource = ds.Tables["ПредставительныеОрганыМетногоСамоуправления"].DefaultView;
            }

            //-----------------      

            if ((sender as Border).Tag.ToString() == "Президент")
            {
                ПрезидентTableAdapter userAdapter = new ПрезидентTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.Президент);
                dataGrid.ItemsSource = ds.Tables["Президент"].DefaultView;
            }

            //-----------------      

            if ((sender as Border).Tag.ToString() == "ФедеральноеCобрание")
            {
                ФедеральноеCобраниеTableAdapter userAdapter = new ФедеральноеCобраниеTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.ФедеральноеCобрание);
                dataGrid.ItemsSource = ds.Tables["ФедеральноеCобрание"].DefaultView;
            }

            //-----------------      

            if ((sender as Border).Tag.ToString() == "ФизическиеЛица")
            {
                ФизическиеЛицаTableAdapter userAdapter = new ФизическиеЛицаTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.ФизическиеЛица);
                dataGrid.ItemsSource = ds.Tables["ФизическиеЛица"].DefaultView;
            }

            //-----------------      

            if ((sender as Border).Tag.ToString() == "ЮридическиеЛица")
            {
                ЮридическиеЛицаTableAdapter userAdapter = new ЮридическиеЛицаTableAdapter();
                JEDKIYDataSet2 ds = new JEDKIYDataSet2();
                userAdapter.Fill(ds.ЮридическиеЛица);
                dataGrid.ItemsSource = ds.Tables["ЮридическиеЛица"].DefaultView;
            }

            //-----------------
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Page page = new Page();
            Grid grid = new Grid();
            DataGrid dataGrid = new DataGrid(); 

            dataGrid.CanUserAddRows = false;
            dataGrid.AutoGenerateColumns = true;
            dataGrid.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            SelectPage(sender, ref dataGrid);   

            grid.Children.Add(dataGrid);
            page.Content = grid;
            NavigationService.Navigate(page);
        }

        public List<string> GetTableList(JEDKIYDataSet2TableAdapters.USsERTableAdapter userAdapter)
        {
            List<string> tableList = new List<string>();

            DataTable schemaTable = userAdapter.GetData();

            foreach (DataRow row in schemaTable.Rows)
            {
                string tableName = (string)row["TABLE_NAME"];
                tableList.Add(tableName);
            }

            return tableList;
        }
    }
}
