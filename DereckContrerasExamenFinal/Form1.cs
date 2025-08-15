using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DereckContrerasExamenFinal
{
    public partial class Form1: Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=JC87;Initial Catalog=Bebidas_Alcohol; Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void agregar()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Bebidas", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "aaa");
            dataGridView1.DataSource = ds.Tables["aaa"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("INSERT INTO Bebidas (nombre_Bebidas,Tipo,precio,stock,fecha_registro) VALUES('" + textBox2.Text + "', '" +  textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')", conn);
            sda.SelectCommand.ExecuteNonQuery();
            agregar();  
            MessageBox.Show("Producto registrado");
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Bebidas WHERE id_Bebidas =" + textBox7.Text;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox7.Text = reader[0].ToString();
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();
                    textBox5.Text = reader[3].ToString();
                    textBox6.Text = reader[4].ToString();
                    
                }
                else
                    MessageBox.Show("Ningun registro encontrado con el id ingresado!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            textBox7.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string sql = "DELETE FROM Bebidas WHERE id_Bebidas =" + textBox8.Text;

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro eliminado correctamente!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            conn.Open();
            MessageBox.Show("Conexion Exitosa");
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }

