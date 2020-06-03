using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tela_Login_Senha
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private bool logado = false;

        bool VerificaLogin()
        {
            bool resultado = false;

            string StrConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DBLogin;Integrated Security=True ";
            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = StrConexao;

                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIOS WHERE Nome='" + textBox1.Text + "' AND Senha='" + textBox2.Text + "';", cn); ;
                    cn.Open();
                    SqlDataReader dados = cmd.ExecuteReader();
                    resultado = dados.HasRows;
                }
                catch(SqlException e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            return resultado;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool resultado = VerificaLogin();
            logado = resultado;
            
            if(resultado)
            {
                MessageBox.Show("Login efetuado com sucesso", "Login com sucesso");
            }
            else
            {
                MessageBox.Show("Falha no login", "Usuário ou senha incorreto(s)!");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(logado)
            {
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
