using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using WpfProjectQuipu.Models;
using WpfProjectQuipu.BusinessLogicLayer;
using Microsoft.Win32;
using System.Xml;



namespace WpfProjectQuipu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();

        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var editItem = new Clients();
                editItem.FirstName = FirstName_txt.Text;
                editItem.LastName = LastName_txt.Text.Trim();
                editItem.Phone = Phone_txt.Text.Trim();
                editItem.Email = Email_txt.Text.Trim();
                editItem.Address = Adress_txt.Text.Trim();

                var editResult = new Bl().Insert_User(editItem);

                if (editResult)
                {
                    MessageBox.Show("Успешно креиран клиент.");
                    FillDataGrid();
                }
                else
                {
                    MessageBox.Show("Проблем при креирање клиенти");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT ID, FirstName, LastName, Phone, Email, Address FROM dbclients";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("dbclients");
                sda.Fill(dt);
                dbclients.ItemsSource = dt.DefaultView;
            }
        }
        private void Search(string textSearch)
        {
            string ConString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT ID, FirstName, LastName, Phone, Email, Address FROM dbclients where FirstName='"+textSearch.ToString()+ "'OR LastName='" + textSearch.ToString() + "'";

                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("dbclients");
                sda.Fill(dt);
                dbclients.ItemsSource = dt.DefaultView;
            }
        }

        private void Dbclients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FirstName_txt.Text = ((DataRowView)dbclients.SelectedItem).Row["FirstName"].ToString();
            LastName_txt.Text = ((DataRowView)dbclients.SelectedItem).Row["LastName"].ToString();
            Phone_txt.Text = ((DataRowView)dbclients.SelectedItem).Row["Phone"].ToString();
            Email_txt.Text = ((DataRowView)dbclients.SelectedItem).Row["Email"].ToString();
            Adress_txt.Text = ((DataRowView)dbclients.SelectedItem).Row["Address"].ToString();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var editItem = new Clients();
                editItem.ClientId = int.Parse(((DataRowView)dbclients.SelectedItem).Row["ID"].ToString());

                var editResult = new Bl().Delete_User(editItem);

                if (editResult)
                {
                    MessageBox.Show("Успешно избришан клиент.");
                    FillDataGrid();
                }
                else
                {
                    MessageBox.Show("Проблем при бришење клиент");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Change_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var editItem = new Clients();
                editItem.ClientId = int.Parse(((DataRowView)dbclients.SelectedItem).Row["ID"].ToString());
                editItem.FirstName = FirstName_txt.Text;
                editItem.LastName = LastName_txt.Text.Trim();
                editItem.Phone = Phone_txt.Text.Trim();
                editItem.Email = Email_txt.Text.Trim();
                editItem.Address = Adress_txt.Text.Trim();

                var editResult = new Bl().Update_User(editItem);

                if (editResult)
                {
                    MessageBox.Show("Успешна измена на клиент.");
                    FillDataGrid();
                }
                else
                {
                    MessageBox.Show("Проблем при измена клиенти");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            Search(Search_txt.Text.Trim());
        }

        

        private void Btn_Import_Click_1(object sender, RoutedEventArgs e)
        {

           
        }
    }
}
