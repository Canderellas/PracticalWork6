using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddPartner.xaml
    /// </summary>
    public partial class AddPartner : Window
    {
        private ws11Entities conn;
        private Partner partner;
        public AddPartner(Partner inPartner, ws11Entities inConn)
        {
            InitializeComponent();
            conn = inConn;
            partner = inPartner;
            cbTypes.ItemsSource = conn.Type_partner.ToList();
            this.DataContext = partner;
            if(partner.FK_Type != 0)
            {
                cbTypes.SelectedValue = partner.FK_Type;
            }
        }

        private void cbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

                partner.FK_Type = Convert.ToInt32(cbTypes.SelectedValue);

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Partner.AddOrUpdate(partner);
                conn.SaveChanges();
                this.Close();
            }
            catch(Exception es)
            {
                MessageBox.Show($"Ошибка сохранения. Проверьте правильность заполнения {es.Message}");
            }

        }
    }
}
