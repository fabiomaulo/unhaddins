namespace SessionManagement.GUI.Views
{
	partial class CreateOrderView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.NumberTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.AddButton = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// NumberTextBox
			// 
			this.NumberTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.NumberTextBox.Location = new System.Drawing.Point(54, 42);
			this.NumberTextBox.Name = "NumberTextBox";
			this.NumberTextBox.Size = new System.Drawing.Size(76, 20);
			this.NumberTextBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(4, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Number";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(136, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Date";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.AliceBlue;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.label4.ForeColor = System.Drawing.Color.SteelBlue;
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(548, 24);
			this.label4.TabIndex = 0;
			this.label4.Text = "Create Order";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(302, 37);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(81, 29);
			this.AddButton.TabIndex = 4;
			this.AddButton.Text = "Add/Modify";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(172, 42);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(124, 20);
			this.dateTimePicker1.TabIndex = 5;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(7, 90);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(527, 266);
			this.dataGridView1.TabIndex = 6;
			// 
			// CreateOrderView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.NumberTextBox);
			this.Name = "CreateOrderView";
			this.Size = new System.Drawing.Size(548, 380);
			this.Load += new System.EventHandler(this.AddProductView_Load);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox NumberTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}
