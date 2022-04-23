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
    public partial class Form1 : Form
    {
        public static SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();
            pictureBox4.Visible = false;

        }
        bool proverka = true;
        bool proverka2 = true;
        bool proverka3 = true;
        public int i = -1;
        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\IS for HCS\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;
            SqlCommand command1 = new SqlCommand("SELECT * FROM [Сотрудники_предприятия]", sqlConnection);

            try
            {
                sqlReader = await command1.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {

                    i=i+1;
                    comboBox1.Items.Add(Convert.ToString(sqlReader["Логин"]));
                    comboBox2.Items.Add(Convert.ToString(sqlReader["Пароль"]));
                    comboBox3.Items.Add(Convert.ToString(sqlReader["Код_сотрудника"]));
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
            textBox2.Text = "Логин";
            textBox2.ForeColor = Color.Gray;
            textBox1.Text = "Пароль";
            textBox1.ForeColor = Color.Gray;
            
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (proverka == true)
            {
                if (proverka3 == false)
                {
                    textBox1.UseSystemPasswordChar = false;
                }
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            proverka = false;
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (proverka == false )
            {
                if(proverka3 == false) 
                { 
                textBox1.UseSystemPasswordChar = true;
                }
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                proverka = true;
            }
        }
        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (proverka2 == true)
            { 
                textBox2.Clear();
                proverka2 = false;
            }
            textBox2.ForeColor = Color.Black;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(proverka3==true)
            {
                textBox1.Clear();
                proverka3 = false;
            }

            textBox1.ForeColor = Color.Black;
            if (proverka == true)
                textBox1.UseSystemPasswordChar = true;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (proverka2 == true)
            {
                textBox2.Clear();
                proverka2 = false;
            }
            textBox2.ForeColor = Color.Black;
            if (e.KeyCode == Keys.Enter)
            {

                for (int ch = i; ch > -1; ch--)
                {
                    string comb = Convert.ToString(comboBox1.Items[ch]);
                    string text = Convert.ToString(textBox2.Text);
                    if (comb == text)
                    {
                        string comb2 = Convert.ToString(comboBox2.Items[ch]);
                        string text2 = Convert.ToString(textBox1.Text);
                        if (comb2 == text2)
                        {
                            string kod = Convert.ToString(comboBox3.Items[ch]);

                            MessageBox.Show("Добро пожаловать!");

                            Form2 form = new Form2(kod);
                            this.Hide();
                            form.comboBox11.Text = "" + Convert.ToString(kod);
                            form.ShowDialog();
                            ch = -1;
                        }
                        if (comb2 != text2)
                        {
                            MessageBox.Show("Неправильный пароль!");
                            ch = -1;
                        }
                    }
                    if (ch == 0 && comb != text)
                    {
                        MessageBox.Show("Неправильный логин!");
                    }

                }
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (proverka3 == true)
            {
                textBox1.Clear();
                proverka3 = false;
            }
            if (proverka == true)
                {
                textBox1.UseSystemPasswordChar = true;            
                textBox1.ForeColor = Color.Black;
                }

            if (e.KeyCode == Keys.Enter)
            {
                
                for (int ch=i; ch>-1; ch--)
                {
                    string comb = Convert.ToString(comboBox1.Items[ch]);
                    string text = Convert.ToString(textBox2.Text);
                    if (comb == text)
                    {
                        string comb2 = Convert.ToString(comboBox2.Items[ch]);
                        string text2 = Convert.ToString(textBox1.Text);
                        if (comb2 == text2)
                        {
                            string kod = Convert.ToString(comboBox3.Items[ch]);
                            
                            MessageBox.Show("Добро пожаловать!");
                            
                            Form2 form = new Form2(kod);
                            this.Hide();
                            form.comboBox11.Text = "" + Convert.ToString(kod);
                            form.ShowDialog();
                            ch = -1;
                        }
                        if (comb2 != text2)
                        {
                            MessageBox.Show("Неправильный пароль!");
                            ch = -1;
                        }
                    }
                    if (ch == 0 && comb != text)
                    {
                        MessageBox.Show("Неправильный логин!");
                    }

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int ch = i; ch > -1; ch--)
            {
                string comb = Convert.ToString(comboBox1.Items[ch]);
                string text = Convert.ToString(textBox2.Text);
                if (comb == text)
                {
                    string comb2 = Convert.ToString(comboBox2.Items[ch]);
                    string text2 = Convert.ToString(textBox1.Text);
                    if (comb2 == text2)
                    {
                        string kod = Convert.ToString(comboBox3.Items[ch]);

                        MessageBox.Show("Добро пожаловать!");

                        Form2 form = new Form2(kod);
                        this.Hide();
                        form.comboBox11.Text = "" + Convert.ToString(kod);
                        form.ShowDialog();
                        ch = -1;
                    }
                    else
                    {
                        MessageBox.Show("Неправильный пароль!");
                        ch = -1;
                    }
                }
                if (ch == 0 && comb != text)
                {
                    MessageBox.Show("Неправильный логин!");
                }

            }
        }
    }
}
