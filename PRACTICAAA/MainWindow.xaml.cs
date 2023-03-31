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
using System.Windows.Navigation;
using System.Windows.Shapes;

using PRACTICAAA.TestDataSetTableAdapters;
using static System.Net.Mime.MediaTypeNames;

namespace PRACTICAAA {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       CLANTableAdapter clan = new CLANTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            Background = new ImageBrush(new BitmapImage(new Uri("https://i.pinimg.com/236x/b3/db/f3/b3dbf3cd9618591bad0cb12bd55a0e9b.jpg", UriKind.RelativeOrAbsolute)));
            clanDataGrid.ItemsSource = clan.GetData();

            clanComboBox.ItemsSource = clan.GetData();
            clanComboBox.DisplayMemberPath = "Глава";

        }

        private void ClanComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (clanComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(cell.ToString());

        }

        private void ClanDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clan.AddClan(Name1Tbx.Text, Convert.ToInt32 (Name2Tbx.Text), Convert.ToInt32 (Name3Tbx.Text));
            clanDataGrid.ItemsSource = clan.GetData();
        }

        private void NameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (clanDataGrid is null) return;
            object id = (clanDataGrid.SelectedItem as DataRowView).Row[0];
            clan.DeleteQuery(Convert.ToInt32 (id));
            clanDataGrid.ItemsSource = clan.GetData();
        }
    }
}
