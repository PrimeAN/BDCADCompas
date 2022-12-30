
namespace TableBuild
{
	partial class MainForm
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
			this.WidthTableTextBox = new System.Windows.Forms.TextBox();
			this.LengthTableTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.HeightTableLegTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.HeightTableBodyTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TableEdgeRoundingTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TableCornersRoundingTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.ShelvesCountTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ширина(W):";
			// 
			// WidthTableTextBox
			// 
			this.WidthTableTextBox.BackColor = System.Drawing.Color.White;
			this.WidthTableTextBox.Location = new System.Drawing.Point(13, 30);
			this.WidthTableTextBox.Name = "WidthTableTextBox";
			this.WidthTableTextBox.Size = new System.Drawing.Size(164, 20);
			this.WidthTableTextBox.TabIndex = 1;
			this.WidthTableTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.WidthTableTextBox.MouseHover += new System.EventHandler(this.TextBox_MouseHover);
			// 
			// LengthTableTextBox
			// 
			this.LengthTableTextBox.Location = new System.Drawing.Point(13, 69);
			this.LengthTableTextBox.Name = "LengthTableTextBox";
			this.LengthTableTextBox.Size = new System.Drawing.Size(164, 20);
			this.LengthTableTextBox.TabIndex = 3;
			this.LengthTableTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.LengthTableTextBox.MouseHover += new System.EventHandler(this.TextBox_MouseHover);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Длина(L):";
			// 
			// HeightTableLegTextBox
			// 
			this.HeightTableLegTextBox.Location = new System.Drawing.Point(13, 108);
			this.HeightTableLegTextBox.Name = "HeightTableLegTextBox";
			this.HeightTableLegTextBox.Size = new System.Drawing.Size(164, 20);
			this.HeightTableLegTextBox.TabIndex = 5;
			this.HeightTableLegTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.HeightTableLegTextBox.MouseHover += new System.EventHandler(this.TextBox_MouseHover);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Высота ножек(H1):";
			// 
			// HeightTableBodyTextBox
			// 
			this.HeightTableBodyTextBox.Location = new System.Drawing.Point(13, 147);
			this.HeightTableBodyTextBox.Name = "HeightTableBodyTextBox";
			this.HeightTableBodyTextBox.Size = new System.Drawing.Size(164, 20);
			this.HeightTableBodyTextBox.TabIndex = 7;
			this.HeightTableBodyTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.HeightTableBodyTextBox.MouseHover += new System.EventHandler(this.TextBox_MouseHover);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 131);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Высота стола(H2):";
			// 
			// TableEdgeRoundingTextBox
			// 
			this.TableEdgeRoundingTextBox.Location = new System.Drawing.Point(13, 186);
			this.TableEdgeRoundingTextBox.Name = "TableEdgeRoundingTextBox";
			this.TableEdgeRoundingTextBox.Size = new System.Drawing.Size(164, 20);
			this.TableEdgeRoundingTextBox.TabIndex = 9;
			this.TableEdgeRoundingTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.TableEdgeRoundingTextBox.MouseHover += new System.EventHandler(this.TextBox_MouseHover);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 209);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(164, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Радиус закругления углов(R2):";
			// 
			// TableCornersRoundingTextBox
			// 
			this.TableCornersRoundingTextBox.Location = new System.Drawing.Point(13, 225);
			this.TableCornersRoundingTextBox.Name = "TableCornersRoundingTextBox";
			this.TableCornersRoundingTextBox.Size = new System.Drawing.Size(164, 20);
			this.TableCornersRoundingTextBox.TabIndex = 11;
			this.TableCornersRoundingTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.TableCornersRoundingTextBox.MouseHover += new System.EventHandler(this.TextBox_MouseHover);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 170);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(166, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Радиус закругления ребер(R1):";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(122, 295);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "Построить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// ShelvesCountTextBox
			// 
			this.ShelvesCountTextBox.Location = new System.Drawing.Point(13, 264);
			this.ShelvesCountTextBox.Name = "ShelvesCountTextBox";
			this.ShelvesCountTextBox.Size = new System.Drawing.Size(164, 20);
			this.ShelvesCountTextBox.TabIndex = 14;
			this.ShelvesCountTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.ShelvesCountTextBox.MouseHover += new System.EventHandler(this.TextBox_MouseHover);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 248);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(102, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Количество полок:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(209, 330);
			this.Controls.Add(this.ShelvesCountTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.TableCornersRoundingTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.TableEdgeRoundingTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.HeightTableBodyTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.HeightTableLegTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LengthTableTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.WidthTableTextBox);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "TableForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox WidthTableTextBox;
		private System.Windows.Forms.TextBox LengthTableTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox HeightTableLegTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox HeightTableBodyTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TableEdgeRoundingTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox TableCornersRoundingTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolTip ErrorToolTip;
		private System.Windows.Forms.TextBox ShelvesCountTextBox;
		private System.Windows.Forms.Label label7;
	}
}

