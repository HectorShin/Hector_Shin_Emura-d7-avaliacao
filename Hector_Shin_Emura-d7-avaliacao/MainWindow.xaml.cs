using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Hector_Shin_Emura_d7_avaliacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string stringConexao = "Server=labsoft.pcs.usp.br;Initial Catalog=db_9; User Id=usuario_9; Password=4766470290;";
            SqlConnection con = new SqlConnection(stringConexao);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                String query = "SELECT COUNT(*) FROM [dbo].[avaliacao] WHERE email=@Email AND senha=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Email", EmailForm.Text);
                sqlCmd.Parameters.AddWithValue("@Password", PasswordForm.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if (count == 1)
                {
                    this.Opacity = 0.5;
                    Sucess.IsOpen = true;
                }
                else
                {
                    this.Opacity = 0.5;
                    Fail.IsOpen = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Sucess.IsOpen = false;
            Fail.IsOpen = false;
            this.Opacity = 1;
        }
    }
}
