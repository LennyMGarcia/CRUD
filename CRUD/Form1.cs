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

namespace CRUD
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
            llenaTabla();
        }

        public void llenaTabla()
        {
            SqlConnection Conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog = PruebaCRUD; Data Source = DESKTOP-BSKLS9C");
            string consulta = @"SELECT * FROM Profesor";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, Conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgvPuebaCRUD.DataSource = dataTable;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog = PruebaCRUD; Data Source = DESKTOP-BSKLS9C");
                Conn.Open();
                string query = @"INSERT INTO Profesor (Nombre, Ocupacion)
                            VALUES(
                                    @Nombre,
                                    @Ocupacion
                                    )";
                SqlCommand command = new SqlCommand(query, Conn);
                command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                command.Parameters.AddWithValue("@Nombre", textBox2.Text);
                command.Parameters.AddWithValue("@Ocupacion", textBox3.Text);
                command.ExecuteNonQuery();
                Conn.Close();

                MessageBox.Show("Guardado Exitosamente");

                llenaTabla();

            }
            catch (Exception err)
            {
                MessageBox.Show("Este es el error  " + err.Message);

            }
            finally
            {
                SqlConnection Conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog = PruebaCRUD; Data Source = DESKTOP-BSKLS9C");
                Conn.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog = PruebaCRUD; Data Source = DESKTOP-BSKLS9C");
                Conn.Open();
                string query = @"UPDATE Profesor
                            SET
                                Nombre=@Nombre,
                                Ocupacion=@Ocupacion
                             WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, Conn);
                command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                command.Parameters.AddWithValue("@Nombre", textBox2.Text);
                command.Parameters.AddWithValue("@Ocupacion", textBox3.Text);
                command.ExecuteNonQuery();
                Conn.Close();

                MessageBox.Show(" Actualizado exitosamente");

                llenaTabla();
            }
            catch (Exception err)
            {
                MessageBox.Show("Este es el error  " + err.Message);

            }
            finally
            {
                SqlConnection Conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog = PruebaCRUD; Data Source = DESKTOP-BSKLS9C");
                Conn.Close();
            }
        }

        private void dgvPuebaCRUD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
