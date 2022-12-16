namespace BDCAD
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
            this.label1 = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.OpenCompassButton = new System.Windows.Forms.Button();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.HeightTableLegTextBox = new System.Windows.Forms.TextBox();
            this.HeightTableTextBox = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.BuildButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RadiusEdgeScrollBar = new System.Windows.Forms.HScrollBar();
            this.RadiusAngleScrollBar = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ширина(W):";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(12, 84);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(359, 20);
            this.WidthTextBox.TabIndex = 1;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            this.WidthTextBox.Enter += new System.EventHandler(this.WidthTextBox_Enter);
            this.WidthTextBox.Leave += new System.EventHandler(this.WidthTextBox_Leave);
            // 
            // OpenCompassButton
            // 
            this.OpenCompassButton.Location = new System.Drawing.Point(12, 12);
            this.OpenCompassButton.Name = "OpenCompassButton";
            this.OpenCompassButton.Size = new System.Drawing.Size(359, 39);
            this.OpenCompassButton.TabIndex = 2;
            this.OpenCompassButton.Text = "Запуск Компас 3D";
            this.OpenCompassButton.UseVisualStyleBackColor = true;
            this.OpenCompassButton.Click += new System.EventHandler(this.OpenCompassButton_Click);
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(12, 133);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(359, 20);
            this.LengthTextBox.TabIndex = 3;
            this.LengthTextBox.TextChanged += new System.EventHandler(this.LengthTextBox_TextChanged);
            this.LengthTextBox.Enter += new System.EventHandler(this.LengthTextBox_Enter);
            this.LengthTextBox.Leave += new System.EventHandler(this.LengthTextBox_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.Location = new System.Drawing.Point(9, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Длина(L):";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label3.Location = new System.Drawing.Point(9, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Высота ножек (H1):";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label5.Location = new System.Drawing.Point(12, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Высота стола (H2):";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label4.Location = new System.Drawing.Point(12, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Радиус закругления рёбер(R1):";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label6.Location = new System.Drawing.Point(9, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 30);
            this.label6.TabIndex = 9;
            this.label6.Text = "Радиус закругления углов(R2):";
            // 
            // HeightTableLegTextBox
            // 
            this.HeightTableLegTextBox.Location = new System.Drawing.Point(12, 181);
            this.HeightTableLegTextBox.Name = "HeightTableLegTextBox";
            this.HeightTableLegTextBox.Size = new System.Drawing.Size(359, 20);
            this.HeightTableLegTextBox.TabIndex = 10;
            this.HeightTableLegTextBox.TextChanged += new System.EventHandler(this.HeightTableLegTextBox_TextChanged);
            this.HeightTableLegTextBox.Enter += new System.EventHandler(this.HeightTableLegTextBox_Enter);
            this.HeightTableLegTextBox.Leave += new System.EventHandler(this.HeightTableLegTextBox_Leave);
            // 
            // HeightTableTextBox
            // 
            this.HeightTableTextBox.Location = new System.Drawing.Point(12, 230);
            this.HeightTableTextBox.Name = "HeightTableTextBox";
            this.HeightTableTextBox.Size = new System.Drawing.Size(359, 20);
            this.HeightTableTextBox.TabIndex = 11;
            this.HeightTableTextBox.TextChanged += new System.EventHandler(this.HeightTableTextBox_TextChanged);
            this.HeightTableTextBox.Enter += new System.EventHandler(this.HeightTableTextBox_Enter);
            this.HeightTableTextBox.Leave += new System.EventHandler(this.HeightTableTextBox_Leave);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(9, 375);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(200, 40);
            this.ClearButton.TabIndex = 14;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(215, 375);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(156, 40);
            this.BuildButton.TabIndex = 15;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 421);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(359, 39);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // RadiusEdgeScrollBar
            // 
            this.RadiusEdgeScrollBar.Location = new System.Drawing.Point(9, 351);
            this.RadiusEdgeScrollBar.Maximum = 180;
            this.RadiusEdgeScrollBar.Name = "RadiusEdgeScrollBar";
            this.RadiusEdgeScrollBar.Size = new System.Drawing.Size(365, 21);
            this.RadiusEdgeScrollBar.TabIndex = 17;
            this.RadiusEdgeScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // RadiusAngleScrollBar
            // 
            this.RadiusAngleScrollBar.Location = new System.Drawing.Point(9, 292);
            this.RadiusAngleScrollBar.Maximum = 180;
            this.RadiusAngleScrollBar.Name = "RadiusAngleScrollBar";
            this.RadiusAngleScrollBar.Size = new System.Drawing.Size(365, 21);
            this.RadiusAngleScrollBar.TabIndex = 18;
            this.RadiusAngleScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.RadiusAngleScrollBar_Scroll);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label7.Location = new System.Drawing.Point(253, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 29);
            this.label7.TabIndex = 19;
            this.label7.Text = "0";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label8.Location = new System.Drawing.Point(244, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 30);
            this.label8.TabIndex = 20;
            this.label8.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 466);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RadiusAngleScrollBar);
            this.Controls.Add(this.RadiusEdgeScrollBar);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.HeightTableTextBox);
            this.Controls.Add(this.HeightTableLegTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LengthTextBox);
            this.Controls.Add(this.OpenCompassButton);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.HScrollBar RadiusAngleScrollBar;
        private System.Windows.Forms.HScrollBar RadiusEdgeScrollBar;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.HScrollBar RadiusEdge;
        private System.Windows.Forms.HScrollBar hScrollBar2;

        private System.Windows.Forms.Button ExitButton;

        private System.Windows.Forms.Button OpenCompassButton;

        private System.Windows.Forms.Button BuildButton;

        private System.Windows.Forms.TextBox HeightTableTextBox;

        private System.Windows.Forms.TextBox HeightTableLegTextBox;

        private System.Windows.Forms.TextBox LengthTextBox;

        private System.Windows.Forms.TextBox WidthTextBox;

        private System.Windows.Forms.Button ClearButton;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}