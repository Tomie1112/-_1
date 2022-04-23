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
    public partial class Form5 : Form
    {
        public static SqlConnection sqlConnection = null;
        public Form5(string kod_zayavki)
        {
            InitializeComponent(); 

        }

        public string kodorg;
        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public bool b;
        private async void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.Работы_по_заявкам". При необходимости она может быть перемещена или удалена.
            this.работы_по_заявкамTableAdapter.Fill(this.database1DataSet1.Работы_по_заявкам);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.Работы_по_заявкам". При необходимости она может быть перемещена или удалена.        
            dataGridView2.Columns[4].Width = 205;
            dataGridView2.Columns[3].Width = 129;   

            dataGridView2.BringToFront();
            string number = "" + textBox1.Text;
            label1.Text = "Работа  с завкой №" + number;
            label2.Text+=  number;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\IS for HCS\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
                


        }

        private void button6_Click(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)
        {
           //отправка на электронную почту

        }

        private async void button3_Click(object sender, EventArgs e)//завершение заявки
        {
            string number = "" + textBox1.Text;
            
            SqlDataReader sqlReader5 = null;
            SqlCommand command3 = new SqlCommand("SELECT * FROM [Заявки] WHERE Номер_заявки=" + Convert.ToInt32(number), sqlConnection);

            try
            {
                sqlReader5 = await command3.ExecuteReaderAsync();

                while (await sqlReader5.ReadAsync())
                {
                    textBox2.Text = "" + (Convert.ToString(sqlReader5["Результат_заявки"]));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader5 != null)
                    sqlReader5.Close();
            }
            string status_zavershen="Завершен";
            if (textBox2.Text != "")
            {
                SqlCommand command = new SqlCommand("UPDATE [Заявки] SET [Статус]=@Статус, [Дата_завершения]=@Дата_завершения WHERE [Номер_заявки]=@Номер_заявки", sqlConnection);
                command.Parameters.AddWithValue("Статус", status_zavershen);
                command.Parameters.AddWithValue("Номер_заявки", Convert.ToInt32(number));
                command.Parameters.AddWithValue("Дата_завершения", dateTimePicker1.Value.Date);
                await command.ExecuteNonQueryAsync();
                MessageBox.Show("Заявка пермещена в завершенные!");
            }
            else
            {
                MessageBox.Show(
                  "Вы не можете завершить заявку пока не оправили\n ответ заявителю или не заполнили результат!");
            }
        }


        private void button4_Click(object sender, EventArgs e)//открытие формы редактирования заявок
        {
            string kod_zayavki = textBox1.Text;
            Form8 form = new Form8(kod_zayavki);           
            form.textBox1.Text = "" + Convert.ToString(kod_zayavki);
            form.ShowDialog();
            b = false;
        }

        private async void Form5_Activated(object sender, EventArgs e)
        {

                richTextBox2.Clear();
                string number = "" + textBox1.Text;
                SqlDataReader sqlReader = null;
                SqlCommand command3 = new SqlCommand("SELECT * FROM [Заявки] WHERE Номер_заявки=" + Convert.ToInt32(number), sqlConnection);

                try
                {
                    sqlReader = await command3.ExecuteReaderAsync();

                    while (await sqlReader.ReadAsync())
                    {
                        richTextBox2.Text += "Дата_оформления:                  " + (Convert.ToString(sqlReader["Дата_оформления"] + "\n"));
                        richTextBox2.Text += "Заявитель:                                    " + (Convert.ToString(sqlReader["Заявитель"] + "\n"));
                        richTextBox2.Text += "Контактный телефон:             " + (Convert.ToString(sqlReader["Контактный_телефон"] + "\n"));
                        richTextBox2.Text += "Электронная почта:                " + (Convert.ToString(sqlReader["Электронная_почта"] + "\n"));
                        richTextBox2.Text += "Адрес:                                              " + (Convert.ToString(sqlReader["Адрес"] + "\n"));

                        kodorg = (Convert.ToString(sqlReader["Код_организации"]));
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
                SqlDataReader sqlReader2 = null;
                SqlCommand command2 = new SqlCommand("SELECT * FROM [Организации] WHERE Код_организации=" + Convert.ToInt32(kodorg), sqlConnection);
                try
                {
                    sqlReader2 = await command2.ExecuteReaderAsync();
                    while (await sqlReader2.ReadAsync())
                    {

                        richTextBox2.Text += "Организация:                               " + (Convert.ToString(sqlReader2["Название"] + "\n"));
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader2 != null)
                    {
                        sqlReader2.Close();
                        b = false;
                    }

                }
            SqlDataReader sqlReader3 = null;
            SqlCommand command4 = new SqlCommand("SELECT * FROM [Заявки] WHERE Номер_заявки=" + Convert.ToInt32(number), sqlConnection);

            try
            {
                sqlReader3 = await command4.ExecuteReaderAsync();

                while (await sqlReader3.ReadAsync())
                {
                    richTextBox2.Text += "Область заявки:                         " + (Convert.ToString(sqlReader3["Тип_заявки"] + "\n"));
                    richTextBox2.Text += "Жалоба:                                          " + (Convert.ToString(sqlReader3["Жалоба"] + "\n"));
                    richTextBox2.Text += "Дата_завершения:                    " + (Convert.ToString(sqlReader3["Дата_завершения"] + "\n"));
                    richTextBox2.Text += "Статус:" + "                                            " + (Convert.ToString(sqlReader3["Статус"] + "\n"));
                    richTextBox2.Text += "Результат заявки:                    " + (Convert.ToString(sqlReader3["Результат_заявки"] + "\n"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader3 != null)
                    sqlReader3.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)//сохранить как документ
        {
            
        }
    }
}
