using PRACTICAAA.TestDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

using PRACTICAAA.TestDataSetTableAdapters;
using static System.Net.Mime.MediaTypeNames;

namespace PRACTICAAA
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        RANGTableAdapter rang = new RANGTableAdapter();
        public Window1()
        {
            InitializeComponent();
            Background = new ImageBrush(new BitmapImage(new Uri("https://i.pinimg.com/564x/29/97/0e/29970e2338c7a6232842d442aa22fff6.jpg", UriKind.RelativeOrAbsolute)));
            rangDataGrid.ItemsSource = rang.GetData();

            rangComboBox.ItemsSource = rang.GetData();
            rangComboBox.DisplayMemberPath = "rang";

        }

        private void RangComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (rangComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(cell.ToString());

        }

        private void RangDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rang.InsertQuery(Convert.ToInt32 (Name1Tbx.Text));
            rangDataGrid.ItemsSource = rang.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rangDataGrid is null) return;
            object id = (rangDataGrid.SelectedItem as DataRowView).Row[0];
            rang.DeleteQuery(Convert.ToInt32(id));
            rangDataGrid.ItemsSource = rang.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (rangDataGrid.SelectedItem != null)
            {
                object id = (rangDataGrid.SelectedItem as DataRowView).Row[0];
                rang.UpdateQuery(Convert.ToInt32(NameTbx.Text), Convert.ToInt32(id));
                rangDataGrid.ItemsSource = rang.GetData();
            }

            else
            {
                MessageBox.Show("Ошибка. Заполните поле");
            }
        }

        private void NameTbx_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            rang.InsertQuery(Convert.ToInt32(Name3Tbx.Text));
            rangDataGrid.ItemsSource = rang.GetData();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
