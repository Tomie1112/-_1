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
    public partial class Form2 : Form
    {
        public static SqlConnection sqlConnection = null;
        public Form2(string kod)
        {
            InitializeComponent();
        }
        //public bool proverka_zav_zayavok=true;
        SqlDataAdapter adapter;
        public string kod_zayavki;
        public string status_zavershen = "Завершен";
        public string status_v_processe = "В процессе";
        string status_deyst = "Действующий";
        string status_nedeyst = "Прекратил работу";
        public bool pr = false;//проверка добавления организаций
        public bool pr_obl = false;//проверка добавления областей
        public string obl;//добавленная область-если удалять
        public bool PROVERKA;//проверка загразки формы
        public bool RowVisble = true;

        private async void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet8.Сотрудники_предприятия". При необходимости она может быть перемещена или удалена.
            this.сотрудники_предприятияTableAdapter.Fill(this.database1DataSet8.Сотрудники_предприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet6.Заявки". При необходимости она может быть перемещена или удалена.
            this.заявкиTableAdapter1.Fill(this.database1DataSet6.Заявки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet5.Области_заявок". При необходимости она может быть перемещена или удалена.
            this.области_заявокTableAdapter.Fill(this.database1DataSet5.Области_заявок);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet2.Организации". При необходимости она может быть перемещена или удалена.
            this.организацииTableAdapter.Fill(this.database1DataSet2.Организации);
            ///выравниваем таблицы
            dataGridView3.Columns[0].Width = 79;
            dataGridView3.Columns[3].Width = 120;
            dataGridView3.Columns[4].Width = 129;
            dataGridView4.Columns[0].Width = 79;
            dataGridView4.Columns[3].Width = 120;
            dataGridView4.Columns[4].Width = 129;
            dataGridView6.Columns[0].Width = 262;



            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\IS for HCS\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            PROVERKA = true;
            заявкиBindingSource5.Filter = "Статус like '" + status_v_processe + "'";
            bindingSource1.Filter = "Статус like '" + status_deyst + "'";
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                int j = 2;
                if (dataGridView3.Rows[i].Cells[j].Value != null)
                {
                    comboBox1.Items.Add(Convert.ToString(dataGridView3.Rows[i].Cells[j].Value));
                    comboBox7.Items.Add(Convert.ToString(dataGridView3.Rows[i].Cells[j].Value));
                }
                j = 0;
                if (dataGridView3.Rows[i].Cells[j].Value != null)
                {
                    comboBox5.Items.Add(Convert.ToString(dataGridView3.Rows[i].Cells[j].Value));
                }
            }
            for (int i = 0; i < dataGridView6.RowCount; i++)
            {
                int j = 0;
                if (dataGridView6.Rows[i].Cells[j].Value != null)
                {
                    comboBox2.Items.Add(Convert.ToString(dataGridView6.Rows[i].Cells[j].Value));
                    comboBox3.Items.Add(Convert.ToString(dataGridView6.Rows[i].Cells[j].Value));
                    comboBox8.Items.Add(Convert.ToString(dataGridView6.Rows[i].Cells[j].Value));
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)//помощь1
        {
            MessageBox.Show(
                   "Уважаемый пользователь!\nДля сортировки текущих заявок выберите\nинтересующие вас параметры поиска и\nнажмите конпку найти. Для более подробной\nинформации о заявке дважды кликните\nпо ней.",
                   "Сообщение", MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);
        }

        private void label28_Click(object sender, EventArgs e)//помощь2
        {
            MessageBox.Show(
                   "Уважаемый пользователь!\nДля сортировки текущих заявок выберите\nинтересующие вас параметры поиска и нажмите\nкнопку найти. Для перемещения заявки в\nтекущие дважды кликните по ней.",
                   "Сообщение", MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);
        }

        private void button1_Click(object sender, EventArgs e)//сортировка текущих заявок по чекбоксам
        {
            int index = comboBox1.SelectedIndex;
            int kodorg = Convert.ToInt32(comboBox5.Items[index].ToString());
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            if (checkBox1.Checked) заявкиBindingSource5.Filter = "Дата_оформления=" + "'" + dateTimePicker1.Value.Date + "'" + "AND " + "Статус like '" + status_v_processe + "'";
            if (checkBox2.Checked) заявкиBindingSource5.Filter = "Код_организации=" + "'" + kodorg + "'" + "AND " + "Статус like '" + status_v_processe + "'";
            if (checkBox3.Checked) заявкиBindingSource5.Filter = "Тип_заявки=" + "'" + comboBox2.Text + "'" + "AND " + "Статус like '" + status_v_processe + "'";
            if (checkBox1.Checked && checkBox2.Checked) заявкиBindingSource5.Filter = "Дата_оформления=" + "'" + dateTimePicker1.Value.Date + "'" + "AND " + "Статус like '" + status_v_processe + "'" + "AND " + "Код_организации=" + "'" + kodorg + "'";
            if (checkBox2.Checked && checkBox3.Checked) заявкиBindingSource5.Filter = "Код_организации=" + "'" + kodorg + "'" + "AND " + "Статус like '" + status_v_processe + "'" + "AND " + "Тип_заявки=" + "'" + comboBox2.Text + "'";
            if (checkBox1.Checked && checkBox3.Checked) заявкиBindingSource5.Filter = "Дата_оформления=" + "'" + dateTimePicker1.Value.Date + "'" + "AND " + "Статус like '" + status_v_processe + "'" + "AND " + "Тип_заявки=" + "'" + comboBox2.Text + "'";
            if (checkBox1.Checked && checkBox3.Checked && checkBox2.Checked) заявкиBindingSource5.Filter = "Дата_оформления=" + "'" + dateTimePicker1.Value.Date + "'" + "AND " + "Статус like '" + status_v_processe + "'" + "AND " + "Тип_заявки=" + "'" + comboBox2.Text + "'" + "AND " + "Код_организации=" + "'" + kodorg + "'";
        }

        private void button7_Click(object sender, EventArgs e)//отмена сортировки текущих заявок
        {
            заявкиBindingSource5.Filter = "Статус like '" + status_v_processe + "'";
        }
        
        private async void button4_Click(object sender, EventArgs e)//добавление новых заявок в таблицу заявки
        {
            заявкиBindingSource5.Filter = "";
            int lastrow = Convert.ToInt32(dataGridView2.RowCount.ToString()) - 2;
            int kod_zayavki2 = Convert.ToInt32(dataGridView2.Rows[lastrow].Cells[0].Value.ToString());
            заявкиBindingSource5.Filter = "Статус like '" + status_v_processe + "'";
            int index = comboBox7.SelectedIndex;
            int kodorg = Convert.ToInt32(comboBox5.Items[index].ToString());////код оганизации присвоить через комбобокс comboBox1.Items[3].ToString()
            string mail = Convert.ToString(textBox5.Text) + Convert.ToString(comboBox4.Text);
            if (!string.IsNullOrEmpty(comboBox11.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrEmpty(comboBox7.Text) && !string.IsNullOrEmpty(textBox3.Text) &&
                !string.IsNullOrEmpty(comboBox8.Text) && !string.IsNullOrEmpty(richTextBox1.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Заявки] (Номер_заявки, Дата_оформления," +
                    " Заявитель, Код_сотрудника, Контактный_телефон, Электронная_почта, Адрес, Код_организации," +
                    "Тип_заявки, Жалоба, Статус)VALUES(@Номер_заявки,@Дата_оформления,@Заявитель,@Код_сотрудника," +
                    "@Контактный_телефон, @Электронная_почта, @Адрес,@Код_организации,@Тип_заявки,@Жалоба,@Статус)", sqlConnection);
                command.Parameters.AddWithValue("Номер_заявки", Convert.ToInt32(kod_zayavki2) + 1);
                command.Parameters.AddWithValue("Дата_оформления", dateTimePicker3.Value.Date);
                command.Parameters.AddWithValue("Заявитель", Convert.ToString(textBox2.Text));
                command.Parameters.AddWithValue("Код_сотрудника", Convert.ToString(comboBox11.Text));
                command.Parameters.AddWithValue("Контактный_телефон", Convert.ToString(textBox4.Text));
                command.Parameters.AddWithValue("Электронная_почта", Convert.ToString(mail));
                command.Parameters.AddWithValue("Адрес", Convert.ToString(textBox3.Text));
                command.Parameters.AddWithValue("Код_организации", Convert.ToInt32(kodorg));
                command.Parameters.AddWithValue("Тип_заявки", Convert.ToString(comboBox8.Text));
                command.Parameters.AddWithValue("Жалоба", Convert.ToString(richTextBox1.Text));
                command.Parameters.AddWithValue("Статус", Convert.ToString(status_v_processe));
                await command.ExecuteNonQueryAsync();
                richTextBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox2.Clear();
                MessageBox.Show("Успешно добавлено!");
            }
            else
                MessageBox.Show("Заполните все значения!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//поиск по номеру заявки(текушие)
        {
            if (textBox1.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    int j = 0;
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                        }
                    }

                }
            }
            else dataGridView1.ClearSelection();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)//поиск по заявителю(текушие)
        {
            if (textBox7.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    int j = 2;
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox7.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                        }
                    }
                }
            }
            else dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            kod_zayavki = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            Form5 form = new Form5(kod_zayavki);
            form.textBox1.Text = "" + Convert.ToString(kod_zayavki);
            form.ShowDialog();
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)//сортировка заявок по разделам
        {
            if (tabControl3.SelectedTab == tabControl3.TabPages["tabPage10"])//your specific tabname
            {
                ///заявкиBindingSource5.Filter = "Статус like '" + status_zavershen + "'";
            }
            if (tabControl3.SelectedTab == tabControl3.TabPages["tabPage11"])
            {
                //заявкиBindingSource5.Filter = "";
            }
            if (tabControl3.SelectedTab == tabControl3.TabPages["tabPage9"])//your specific tabname
            {
                //заявкиBindingSource5.Filter = "Статус like '" + status_v_processe + "'";
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//Изменение заявки на текущую
        {
            string kod = dataGridView5.Rows[dataGridView5.CurrentRow.Index].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show(
                   "Изменить статус данной\nзаявки на текующую?",
                   "Сообщение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form9 form = new Form9(kod);
                form.textBox1.Text = "" + Convert.ToString(kod);
                form.ShowDialog();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            dateTimePicker4.CustomFormat = "dd.MM.yyyy";
            dateTimePicker5.CustomFormat = "dd.MM.yyyy";
            if (checkBox6.Checked) заявкиBindingSource5.Filter = "Дата_завершения=" + "'" + dateTimePicker2.Value.Date + "'" + "AND " + "Статус like '" + status_zavershen + "'";
            //период
            if (checkBox5.Checked) заявкиBindingSource5.Filter = "Дата_завершения>=" + "'" + dateTimePicker4.Value.Date + "'" + "AND " + "Дата_завершения<=" + "'" + dateTimePicker5.Value.Date + "'" + "AND " + "Статус like '" + status_zavershen + "'";
            //область заявки
            if (checkBox4.Checked) заявкиBindingSource5.Filter = "Тип_заявки=" + "'" + comboBox3.Text + "'" + "AND " + "Статус like '" + status_zavershen + "'";
            //область и дата
            if (checkBox4.Checked && checkBox6.Checked) заявкиBindingSource5.Filter = "Тип_заявки=" + "'" + comboBox3.Text + "'" + "AND " + "Дата_завершения=" + "'" + dateTimePicker2.Value.Date + "'" + "AND " + "Статус like '" + status_zavershen + "'";
            //область и период
            if (checkBox4.Checked && checkBox5.Checked) заявкиBindingSource5.Filter = "Тип_заявки=" + "'" + comboBox3.Text + "'" + "AND " + "Дата_завершения=>" + "'" + dateTimePicker4.Value.Date + "'" + "AND " + "Дата_завершения<=" + "'" + dateTimePicker5.Value.Date + "'" + "AND " + "Статус like '" + status_zavershen + "'";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            заявкиBindingSource5.Filter = "Статус like '" + status_zavershen + "'";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                for (int i = 0; i < dataGridView5.RowCount; i++)
                {
                    dataGridView5.Rows[i].Selected = false;
                    int j = 0;
                    if (dataGridView5.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView5.Rows[i].Cells[j].Value.ToString().Contains(textBox8.Text))
                        {
                            dataGridView5.Rows[i].Selected = true;
                        }
                    }

                }
            }
            else dataGridView1.ClearSelection();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                for (int i = 0; i < dataGridView5.RowCount; i++)
                {
                    dataGridView5.Rows[i].Selected = false;
                    int j = 2;
                    if (dataGridView5.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView5.Rows[i].Cells[j].Value.ToString().Contains(textBox6.Text))
                        {
                            dataGridView5.Rows[i].Selected = true;
                        }
                    }
                }
            }
            else dataGridView5.ClearSelection();
        }

        private async void button11_Click(object sender, EventArgs e)//Заполнение организаций
        {
            bindingSource1.Filter = "";
            int lastrow = Convert.ToInt32(dataGridView3.RowCount.ToString()) - 2;
            int kod_org = Convert.ToInt32(dataGridView3.Rows[lastrow].Cells[0].Value.ToString());
            if (!string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrEmpty(textBox9.Text) &&
                !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrEmpty(comboBox12.Text) &&
                !string.IsNullOrEmpty(textBox10.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Организации] (Код_организации, Тип_организации," +
                    " Название, Электронная_почта, Адрес, Номер_телефона, Статус)VALUES(@Код_организации,@Тип_организации,@Название,@Электронная_почта," +
                    "@Адрес, @Номер_телефона, @Статус)", sqlConnection);
                command.Parameters.AddWithValue("Код_организации", Convert.ToInt32(kod_org) + 1);
                command.Parameters.AddWithValue("Тип_организации", Convert.ToString(comboBox12.Text));
                command.Parameters.AddWithValue("Название", Convert.ToString(textBox9.Text));
                command.Parameters.AddWithValue("Электронная_почта", Convert.ToString(textBox10.Text));
                command.Parameters.AddWithValue("Адрес", Convert.ToString(textBox11.Text));
                command.Parameters.AddWithValue("Номер_телефона", Convert.ToString(textBox12.Text));
                command.Parameters.AddWithValue("Статус", Convert.ToString(status_deyst));
                await command.ExecuteNonQueryAsync();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();               
                pr = true;
                MessageBox.Show("Успешно добавлено!");
            }
            else
            { MessageBox.Show("Заполните все значения!"); }
            

        }

        private async void button12_Click(object sender, EventArgs e)//удаление орагнизаций
        {
            if (pr == true)
            {
                int lastrow = Convert.ToInt32(dataGridView3.RowCount.ToString()) - 2;
                int kod_org = Convert.ToInt32(dataGridView3.Rows[lastrow].Cells[0].Value.ToString());
                SqlCommand command = new SqlCommand("DELETE FROM [Организации] WHERE Код_организации=@Код_организации", sqlConnection);
                command.Parameters.AddWithValue("Код_организации", Convert.ToInt32(kod_org));
                await command.ExecuteNonQueryAsync();
                pr = false;
                MessageBox.Show("Успешно удалено!");
            }
            else
            {
                MessageBox.Show("Вы еще не добавили ни одной строки!");
            }
        }

        private async void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//перенести организацию в не дейтсвующие
        {
            string kod = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show(
                   "Перенести данную организацю в архив\n и отметить как не действительную?",
                   "Сообщение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("UPDATE [Организации] SET [Статус]=@Статус WHERE [Код_организации]=@Код_организации", sqlConnection);
                command.Parameters.AddWithValue("Статус", status_nedeyst);
                command.Parameters.AddWithValue("Код_организации", Convert.ToInt32(kod));
                await command.ExecuteNonQueryAsync();
                MessageBox.Show("Успешно перемещено!");
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)//поиск по организациям
        {
            if (textBox13.Text != "")
            {
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    dataGridView3.Rows[i].Selected = false;
                    int j = 2;
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView3.Rows[i].Cells[j].Value.ToString().Contains(textBox13.Text))
                        {
                            dataGridView3.Rows[i].Selected = true;
                        }
                    }
                }
            }
            else dataGridView3.ClearSelection();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)///контроль администратора
        {
            if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage6"])
            {          
                tabControl2.SelectedTab = tabControl2.TabPages["tabPage5"];
            }
        }

        private async void button6_Click(object sender, EventArgs e)//добавление областей
        {
            if (textBox14.Text != "")
            {
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Области_заявок] (Тип_заявки)VALUES(@Тип_заявки)", sqlConnection);
                command.Parameters.AddWithValue("Тип_заявки", Convert.ToString(textBox14.Text));
                await command.ExecuteNonQueryAsync();
                pr_obl = true;
                obl = Convert.ToString(textBox14.Text);
                textBox14.Clear();
                MessageBox.Show("Успешно добавлено!");
            }
        }

        private async void button3_Click(object sender, EventArgs e)///удаление областей заявок
        {
            if (pr_obl == true)
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Области_заявок] WHERE Тип_заявки=@Тип_заявки", sqlConnection);
                command.Parameters.AddWithValue("Тип_заявки", Convert.ToString(obl));
                await command.ExecuteNonQueryAsync();
                MessageBox.Show("Успешно удалено!");
                pr_obl = false;
            }
            else MessageBox.Show("Вы еще не добавили область\n чтобы ее удалить!");
        }

        private void Form2_Activated(object sender, EventArgs e)
        {

            if (PROVERKA == true)
            {
                adapter = new SqlDataAdapter("Select * From Организации", sqlConnection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataTable dt2 = new DataTable();
                adapter.Fill(dt2);
                dataGridView3.DataSource = dt2;
                adapter.Update((DataTable)dataGridView3.DataSource);//обновляет БД
                dataGridView4.DataSource = dt2;
                adapter.Update((DataTable)dataGridView4.DataSource);

                dataGridView3.CurrentCell = null;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells[6].Value != null && (string)row.Cells[6].Value == status_nedeyst)
                    {
                        row.Visible = false;
                    }
                }
                dataGridView4.CurrentCell = null;
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.Cells[6].Value != null && (string)row.Cells[6].Value == status_deyst)
                    {
                        row.Visible = false;
                    }
                }
                comboBox1.Items.Clear();
                comboBox7.Items.Clear();
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    int j = 2;
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                    {
                        comboBox1.Items.Add(Convert.ToString(dataGridView3.Rows[i].Cells[j].Value));
                        comboBox7.Items.Add(Convert.ToString(dataGridView3.Rows[i].Cells[j].Value));
                    }
                    j = 0;
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                    {
                        comboBox5.Items.Add(Convert.ToString(dataGridView3.Rows[i].Cells[j].Value));
                    }



                    adapter = new SqlDataAdapter("Select * From Области_заявок", sqlConnection);
                    SqlCommandBuilder builder3 = new SqlCommandBuilder(adapter);
                    DataTable dt3 = new DataTable();
                    adapter.Fill(dt3);
                    dataGridView6.DataSource = dt3;
                    adapter.Update((DataTable)dataGridView6.DataSource);
                    comboBox2.Items.Clear();
                    comboBox3.Items.Clear();
                    comboBox8.Items.Clear();
                    for (int i1 = 0; i1 < dataGridView6.RowCount-1; i1++)
                    {
                        int j1 = 0;
                        if (dataGridView6.Rows[i1].Cells[j1].Value != null)
                        {
                            comboBox2.Items.Add(Convert.ToString(dataGridView6.Rows[i1].Cells[j1].Value));
                            comboBox3.Items.Add(Convert.ToString(dataGridView6.Rows[i1].Cells[j1].Value));
                            comboBox8.Items.Add(Convert.ToString(dataGridView6.Rows[i1].Cells[j1].Value));
                        }
                    }
                    
                 adapter = new SqlDataAdapter("Select * From Заявки", sqlConnection);
                 SqlCommandBuilder builder2 = new SqlCommandBuilder(adapter);
                 DataTable dt4 = new DataTable();
                 adapter.Fill(dt4);
                 dataGridView1.DataSource = dt4;
                 adapter.Update((DataTable)dataGridView1.DataSource);//обновляет БД
                 dataGridView2.DataSource = dt4;
                 adapter.Update((DataTable)dataGridView2.DataSource);//обновляет БД
                 dataGridView5.DataSource = dt4;
                 adapter.Update((DataTable)dataGridView5.DataSource);//обновляет БД
                    dataGridView1.CurrentCell = null;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[6].Value != null && (string)row.Cells[6].Value == status_zavershen)
                        {
                            row.Visible = false;
                        }
                    }
                    dataGridView2.CurrentCell = null;
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Cells[6].Value != null && (string)row.Cells[6].Value == status_v_processe)
                        {
                            row.Visible = false;
                        }
                    }
                }
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])//your specific tabname
            {
                bindingSource1.Filter = "Статус like '" + status_deyst + "'";
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                bindingSource1.Filter = "Статус='" + status_nedeyst + "'";
            }
        }
    }
}
