namespace 登录案例
{
    partial class select
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
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.exampleDBDataSet6 = new 登录案例.ExampleDBDataSet6();
            this.allcourseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allcourseTableAdapter = new 登录案例.ExampleDBDataSet6TableAdapters.allcourseTableAdapter();
            this.claidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clanameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sctimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teachernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exampleDBDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allcourseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(618, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 98);
            this.button2.TabIndex = 6;
            this.button2.Text = "加入我的课表";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2017第一学期",
            "2017第二学期",
            "2018第一学期",
            "2018第二学期",
            "2019第一学期",
            "2019第二学期",
            "2020第一学期",
            "2020第二学期"});
            this.comboBox1.Location = new System.Drawing.Point(95, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 23);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "学期：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.claidDataGridViewTextBoxColumn,
            this.clanameDataGridViewTextBoxColumn,
            this.sctimeDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.termDataGridViewTextBoxColumn,
            this.teachernameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.allcourseBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-2, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(600, 337);
            this.dataGridView1.TabIndex = 10;
            // 
            // exampleDBDataSet6
            // 
            this.exampleDBDataSet6.DataSetName = "ExampleDBDataSet6";
            this.exampleDBDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // allcourseBindingSource
            // 
            this.allcourseBindingSource.DataMember = "allcourse";
            this.allcourseBindingSource.DataSource = this.exampleDBDataSet6;
            // 
            // allcourseTableAdapter
            // 
            this.allcourseTableAdapter.ClearBeforeFill = true;
            // 
            // claidDataGridViewTextBoxColumn
            // 
            this.claidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.claidDataGridViewTextBoxColumn.DataPropertyName = "claid";
            this.claidDataGridViewTextBoxColumn.HeaderText = "课程";
            this.claidDataGridViewTextBoxColumn.Name = "claidDataGridViewTextBoxColumn";
            // 
            // clanameDataGridViewTextBoxColumn
            // 
            this.clanameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clanameDataGridViewTextBoxColumn.DataPropertyName = "claname";
            this.clanameDataGridViewTextBoxColumn.HeaderText = "课程名";
            this.clanameDataGridViewTextBoxColumn.Name = "clanameDataGridViewTextBoxColumn";
            // 
            // sctimeDataGridViewTextBoxColumn
            // 
            this.sctimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sctimeDataGridViewTextBoxColumn.DataPropertyName = "sctime";
            this.sctimeDataGridViewTextBoxColumn.HeaderText = "上课时间";
            this.sctimeDataGridViewTextBoxColumn.Name = "sctimeDataGridViewTextBoxColumn";
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "上课地点";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // termDataGridViewTextBoxColumn
            // 
            this.termDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.termDataGridViewTextBoxColumn.DataPropertyName = "term";
            this.termDataGridViewTextBoxColumn.HeaderText = "学期";
            this.termDataGridViewTextBoxColumn.Name = "termDataGridViewTextBoxColumn";
            // 
            // teachernameDataGridViewTextBoxColumn
            // 
            this.teachernameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.teachernameDataGridViewTextBoxColumn.DataPropertyName = "teachername";
            this.teachernameDataGridViewTextBoxColumn.HeaderText = "任课老师";
            this.teachernameDataGridViewTextBoxColumn.Name = "teachernameDataGridViewTextBoxColumn";
            // 
            // select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 459);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Name = "select";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "select";
            this.Load += new System.EventHandler(this.select_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exampleDBDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allcourseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ExampleDBDataSet6 exampleDBDataSet6;
        private System.Windows.Forms.BindingSource allcourseBindingSource;
        private ExampleDBDataSet6TableAdapters.allcourseTableAdapter allcourseTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn claidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clanameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sctimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn termDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teachernameDataGridViewTextBoxColumn;
    }
}