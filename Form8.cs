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

namespace Приложение_для_курсовой
{
    public partial class Form8 : Form
    {
        public static SqlConnection sqlConnection = null;
        public Form8(string kod_zayavki)
        {
            InitializeComponent();
        }
        private async void Form8_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\IS for HCS\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader2 = null;
            SqlCommand command2 = new SqlCommand("SELECT * FROM [Области_заявок]", sqlConnection);

            try
            {
                sqlReader2 = await command2.ExecuteReaderAsync();

                while (await sqlReader2.ReadAsync())
                {
                    comboBox8.Items.Add(Convert.ToString(sqlReader2["Тип_заявки"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader2 != null)
                    sqlReader2.Close();
            }
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Заявки] WHERE Номер_заявки=" + Convert.ToInt32(textBox1.Text), sqlConnection);
            string proverka="";
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    textBox2.Text =(Convert.ToString(sqlReader["Заявитель"]));

                    proverka = Convert.ToString(sqlReader["Контактный_телефон"]);
                    if (proverka != "") textBox4.Text = (Convert.ToString(sqlReader["Контактный_телефон"]));
                    else textBox4.Text = "123";
                    proverka = "";

                    proverka = Convert.ToString(sqlReader["Электронная_почта"]);
                    if (proverka!="") textBox5.Text = (Convert.ToString(sqlReader["Электронная_почта"]));
                    proverka = "";

                    dateTimePicker3.Value = Convert.ToDateTime(sqlReader["Дата_оформления"]);
                    textBox3.Text = Convert.ToString(sqlReader["Адрес"]);
                    comboBox7.Text = (Convert.ToString(sqlReader["Код_организации"]));
                    comboBox8.Text = (Convert.ToString(sqlReader["Тип_заявки"]));
                    richTextBox2.Text = (Convert.ToString(sqlReader["Жалоба"]));
                    proverka = (Convert.ToString(sqlReader["Результат_заявки"]));
                    if(proverka!="")
                    richTextBox1.Text = (Convert.ToString(sqlReader["Результат_заявки"]));
                    proverka = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
        private async void button4_Click(object sender, EventArgs e)
        {           
            if (!string.IsNullOrEmpty(textBox2.Text)  &&
            !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(comboBox7.Text) &&
            !string.IsNullOrEmpty(comboBox8.Text) && !string.IsNullOrEmpty(richTextBox2.Text))
            { 
            //update
            SqlCommand command = new SqlCommand("UPDATE [Заявки] SET [Дата_оформления]=@Дата_оформления,[Заявитель]=@Заявитель," +
            "[Контактный_телефон]=@Контактный_телефон,[Электронная_почта]=@Электронная_почта,[Адрес]=@Адрес,[Код_организации]=@Код_организации," +
            "[Тип_заявки]=@Тип_заявки,[Жалоба]=@Жалоба, [Результат_заявки]=@Результат_заявки " +
            "WHERE [Номер_заявки]=" + Convert.ToInt32(textBox1.Text), sqlConnection);
            command.Parameters.AddWithValue("Дата_оформления", dateTimePicker3.Value.Date);
            command.Parameters.AddWithValue("Заявитель", Convert.ToString(textBox2.Text));
            command.Parameters.AddWithValue("Контактный_телефон", Convert.ToString(textBox4.Text));
            command.Parameters.AddWithValue("Электронная_почта", Convert.ToString(textBox5.Text));
            command.Parameters.AddWithValue("Адрес", Convert.ToString(textBox3.Text));
            command.Parameters.AddWithValue("Код_организации", Convert.ToInt32(comboBox7.Text));
            command.Parameters.AddWithValue("Тип_заявки", Convert.ToString(comboBox8.Text));
            command.Parameters.AddWithValue("Жалоба", Convert.ToString(richTextBox2.Text));

            command.Parameters.AddWithValue("Результат_заявки", Convert.ToString(richTextBox1.Text));
            await command.ExecuteNonQueryAsync();
            MessageBox.Show("Успешно добавлено!");
            }
            else
                MessageBox.Show("Заполните все значения!");
        }
    }
}
