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


namespace laba5bd
{
    public partial class Form1 : Form
    {

        string connectionString = "Server=localhost;Database=Education;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "educationDataSet.Информация_о_туристах". При необходимости она может быть перемещена или удалена.
            this.информация_о_туристахTableAdapter.Fill(this.educationDataSet.Информация_о_туристах);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "educationDataSet.Туристы". При необходимости она может быть перемещена или удалена.
            this.туристыTableAdapter.Fill(this.educationDataSet.Туристы);

            //LoadDataIntoDataGridView(dataGridView1, "SELECT * FROM Туристы");
            //LoadDataIntoDataGridView(dataGridView2, "SELECT * FROM Информация_о_туристах");

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            туристыTableAdapter.Update(educationDataSet);
            информация_о_туристахTableAdapter.Update(educationDataSet);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }

            MessageBox.Show("Запись была успешно удалена!");
        }

        private void LoadDataIntoDataGridView(DataGridView dataGridView, string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddRecordForm addForm = new AddRecordForm(this);
            addForm.Show();
        }

        public void InsertRecordIntoDatabase(string value1, string value2, string value3, string value4)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Туристы (код_туриста, фамилия, имя, отчество) VALUES (@Value1, @Value2, @Value3, @Value4)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Value1", value1);
                        command.Parameters.AddWithValue("@Value2", value2);
                        command.Parameters.AddWithValue("@Value3", value3);
                        command.Parameters.AddWithValue("@Value4", value4);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding record: " + ex.Message);
            }

            туристыTableAdapter.Update(educationDataSet);
            информация_о_туристахTableAdapter.Update(educationDataSet);
        }
    }
}
