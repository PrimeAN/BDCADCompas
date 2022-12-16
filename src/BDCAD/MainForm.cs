using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDCAD_BusinessLogic;

namespace BDCAD
{
    public partial class MainForm : Form
    {
        private static string _widthHelpMessage = "600-1000 мм";
        private static string _lengthHelpMessage = "75% от ширины-750 мм";
        private static string _h1HelpMessage = "Меньше h1 не меньше чем в 7.5 раз и больше 100 мм";
        private static string _h2HelpMessage = "600-1050 мм";
        private static string _radiusHelpMessage = "0-180 градусов";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximumSize = Size;
            MinimumSize = Size;
            RadiusEdgeScrollBar.Value = 0;
            RadiusAngleScrollBar.Value = 0;
            HeightTableTextBox.ShowHelpMessageIfEmpty(_h2HelpMessage);
            HeightTableLegTextBox.ShowHelpMessageIfEmpty(_h1HelpMessage);
            LengthTextBox.ShowHelpMessageIfEmpty(_lengthHelpMessage);
            WidthTextBox.ShowHelpMessageIfEmpty(_widthHelpMessage);
            
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            WidthTextBox.Clear();
            LengthTextBox.Clear();
            HeightTableTextBox.Clear();
            HeightTableLegTextBox.Clear();
            HeightTableTextBox.ShowHelpMessageIfEmpty(_h2HelpMessage);
            HeightTableLegTextBox.ShowHelpMessageIfEmpty(_h1HelpMessage);
            LengthTextBox.ShowHelpMessageIfEmpty(_lengthHelpMessage);
            WidthTextBox.ShowHelpMessageIfEmpty(_widthHelpMessage);
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            WidthTextBox.ValidateValueRange(600, 1000);
        }

        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            LengthTextBox.ValidateValueRange(450, 750);

            if (int.TryParse(WidthTextBox.Text, out var temp))
                LengthTextBox.ValidateValueRange(temp * 75 / 100, 750);
        }

        private void HeightTableLegTextBox_TextChanged(object sender, EventArgs e)
        {
            HeightTableLegTextBox.ValidateValueRange(100, 140);

            if (int.TryParse(HeightTableTextBox.Text, out var temp))
                HeightTableLegTextBox.ValidateValueRange(100, temp * 75 / 100);
        }

        private void HeightTableTextBox_TextChanged(object sender, EventArgs e)
        {
            HeightTableTextBox.ValidateValueRange(600, 1050);
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OpenCompassButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WidthTextBox_Enter(object sender, EventArgs e)
        {
            WidthTextBox.HideHelpMessageIfEmpty(_widthHelpMessage);
        }

        private void WidthTextBox_Leave(object sender, EventArgs e)
        {
            WidthTextBox.ShowHelpMessageIfEmpty(_widthHelpMessage);
        }

        private void LengthTextBox_Enter(object sender, EventArgs e)
        {
            LengthTextBox.HideHelpMessageIfEmpty(_lengthHelpMessage);
        }

        private void LengthTextBox_Leave(object sender, EventArgs e)
        {
            LengthTextBox.ShowHelpMessageIfEmpty(_lengthHelpMessage);
        }

        private void HeightTableLegTextBox_Enter(object sender, EventArgs e)
        {
            HeightTableLegTextBox.HideHelpMessageIfEmpty(_h1HelpMessage);
        }

        private void HeightTableLegTextBox_Leave(object sender, EventArgs e)
        {
            HeightTableLegTextBox.ShowHelpMessageIfEmpty(_h1HelpMessage);
        }

        private void HeightTableTextBox_Enter(object sender, EventArgs e)
        {
            HeightTableTextBox.HideHelpMessageIfEmpty(_h2HelpMessage);
        }

        private void HeightTableTextBox_Leave(object sender, EventArgs e)
        {
            HeightTableTextBox.ShowHelpMessageIfEmpty(_h2HelpMessage);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label7.Text = RadiusEdgeScrollBar.Value.ToString();
        }

        private void RadiusAngleScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            label8.Text = RadiusAngleScrollBar.Value.ToString();
        }
    }
}