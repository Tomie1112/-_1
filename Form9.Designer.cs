
namespace Приложение_для_курсовой
{
    partial class Form9
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.повторноеоткрытиезаявокBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new Приложение_для_курсовой.Database1DataSet();
            this.повторное_открытие_заявокTableAdapter = new Приложение_для_курсовой.Database1DataSetTableAdapters.Повторное_открытие_заявокTableAdapter();
            this.database1DataSet3 = new Приложение_для_курсовой.Database1DataSet3();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.database1DataSet7 = new Приложение_для_курсовой.Database1DataSet7();
            this.повторноеоткрытиезаявокBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.повторное_открытие_заявокTableAdapter1 = new Приложение_для_курсовой.Database1DataSet7TableAdapters.Повторное_открытие_заявокTableAdapter();
            this.номерповторногооткрытиязаявкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерзаявкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.причинаповторногооткрытиязаявкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.повторноеоткрытиезаявокBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.повторноеоткрытиезаявокBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Укажите причину повторного открытия заявки:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(361, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(13, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "ОТМЕНА";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Visible = false;
            // 
            // повторноеоткрытиезаявокBindingSource
            // 
            this.повторноеоткрытиезаявокBindingSource.DataMember = "Повторное_открытие_заявок";
            this.повторноеоткрытиезаявокBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // повторное_открытие_заявокTableAdapter
            // 
            this.повторное_открытие_заявокTableAdapter.ClearBeforeFill = true;
            // 
            // database1DataSet3
            // 
            this.database1DataSet3.DataSetName = "Database1DataSet3";
            this.database1DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерповторногооткрытиязаявкиDataGridViewTextBoxColumn,
            this.номерзаявкиDataGridViewTextBoxColumn,
            this.причинаповторногооткрытиязаявкиDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.повторноеоткрытиезаявокBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(1, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(10, 33);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            // 
            // database1DataSet7
            // 
            this.database1DataSet7.DataSetName = "Database1DataSet7";
            this.database1DataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // повторноеоткрытиезаявокBindingSource1
            // 
            this.повторноеоткрытиезаявокBindingSource1.DataMember = "Повторное_открытие_заявок";
            this.повторноеоткрытиезаявокBindingSource1.DataSource = this.database1DataSet7;
            // 
            // повторное_открытие_заявокTableAdapter1
            // 
            this.повторное_открытие_заявокTableAdapter1.ClearBeforeFill = true;
            // 
            // номерповторногооткрытиязаявкиDataGridViewTextBoxColumn
            // 
            this.номерповторногооткрытиязаявкиDataGridViewTextBoxColumn.DataPropertyName = "Номер_повторного_открытия_заявки";
            this.номерповторногооткрытиязаявкиDataGridViewTextBoxColumn.HeaderText = "Номер_повторного_открытия_заявки";
            this.номерповторногооткрытиязаявкиDataGridViewTextBoxColumn.Name = "номерповторногооткрытиязаявкиDataGridViewTextBoxColumn";
            // 
            // номерзаявкиDataGridViewTextBoxColumn
            // 
            this.номерзаявкиDataGridViewTextBoxColumn.DataPropertyName = "Номер_заявки";
            this.номерзаявкиDataGridViewTextBoxColumn.HeaderText = "Номер_заявки";
            this.номерзаявкиDataGridViewTextBoxColumn.Name = "номерзаявкиDataGridViewTextBoxColumn";
            // 
            // причинаповторногооткрытиязаявкиDataGridViewTextBoxColumn
            // 
            this.причинаповторногооткрытиязаявкиDataGridViewTextBoxColumn.DataPropertyName = "Причина_повторного_открытия_заявки";
            this.причинаповторногооткрытиязаявкиDataGridViewTextBoxColumn.HeaderText = "Причина_повторного_открытия_заявки";
            this.причинаповторногооткрытиязаявкиDataGridViewTextBoxColumn.Name = "причинаповторногооткрытиязаявкиDataGridViewTextBoxColumn";
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 167);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form9";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.повторноеоткрытиезаявокBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.повторноеоткрытиезаявокBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox textBox1;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource повторноеоткрытиезаявокBindingSource;
        private Database1DataSetTableAdapters.Повторное_открытие_заявокTableAdapter повторное_открытие_заявокTableAdapter;
        private Database1DataSet3 database1DataSet3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Database1DataSet7 database1DataSet7;
        private System.Windows.Forms.BindingSource повторноеоткрытиезаявокBindingSource1;
        private Database1DataSet7TableAdapters.Повторное_открытие_заявокTableAdapter повторное_открытие_заявокTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерповторногооткрытиязаявкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерзаявкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn причинаповторногооткрытиязаявкиDataGridViewTextBoxColumn;
    }
}