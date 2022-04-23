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

namespace Приложение_для_курсовой
{
    public partial class Form9 : Form
    {
        public static SqlConnection sqlConnection = null;
        public Form9(string kod)
        {
            InitializeComponent();
        }



        private async void Form9_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet7.Повторное_открытие_заявок". При необходимости она может быть перемещена или удалена.
            this.повторное_открытие_заявокTableAdapter1.Fill(this.database1DataSet7.Повторное_открытие_заявок);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.Повторное_открытие_заявок". При необходимости она может быть перемещена или удалена.
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\IS for HCS\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
        }        
        private async void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text!="")
            { 
            string kod_z = Convert.ToString(textBox1.Text);            
            string new_status = "В процессе";
            SqlCommand command = new SqlCommand("UPDATE [Заявки] SET [Статус]=@Статус WHERE [Номер_заявки]=@Номер_заявки", sqlConnection);
            command.Parameters.AddWithValue("Статус", new_status);
            command.Parameters.AddWithValue("Номер_заявки", Convert.ToInt32(kod_z));
            await command.ExecuteNonQueryAsync();

            int lastrow = Convert.ToInt32(dataGridView1.RowCount.ToString()) - 2;
            int kod_otkr = Convert.ToInt32(dataGridView1.Rows[lastrow].Cells[0].Value.ToString());
            SqlCommand command2= new SqlCommand("INSERT INTO [dbo].[Повторное_открытие_заявок] (Номер_повторного_открытия_заявки, Номер_заявки," +
                        " Причина_повторного_открытия_заявки)VALUES(@Номер_повторного_открытия_заявки,@Номер_заявки,@Причина_повторного_открытия_заявки)", sqlConnection);
                    command2.Parameters.AddWithValue("Номер_повторного_открытия_заявки", Convert.ToInt32(kod_otkr) + 1);
                    command2.Parameters.AddWithValue("Номер_заявки", Convert.ToInt32(kod_z));
                    command2.Parameters.AddWithValue("Причина_повторного_открытия_заявки", Convert.ToString(richTextBox1.Text));
                    await command2.ExecuteNonQueryAsync();
            MessageBox.Show("Заявка успешно открыта!");
            this.Close();
            }
            else MessageBox.Show("Сначала заполните причину открытия!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
