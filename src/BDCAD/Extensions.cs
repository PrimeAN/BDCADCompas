using System.Drawing;
using System.Windows.Forms;
using BDCAD_BusinessLogic;

namespace BDCAD
{
    public static class Extensions
    {
        /// <summary>
        /// Функция проверки значения, написанного в TextBox.
        /// </summary>
        /// <param name="box">Сам TextBox</param>
        /// <param name="from">Минимальное значение</param>
        /// <param name="to">Максимальное значение</param>
        public static void ValidateValueRange(this TextBox box, int from, int to)
        {
            if (box.Text == string.Empty)
            {
                box.BackColor = Color.White;
                return;
            }
            
            if (int.TryParse(box.Text, out var value))
            {
                box.BackColor = value.IsInRange(from, to) ? Color.White : Color.Brown;
                return;
            }

            box.BackColor = Color.Brown;
        }


        public static void ShowHelpMessageIfEmpty(this TextBox box, string message)
        {
            if (box.Text != string.Empty) return;
            box.Text = message;
            box.ForeColor = Color.Gray;
        }
        
        public static void HideHelpMessageIfEmpty(this TextBox box, string message)
        {
            if (box.Text != message) return;
            box.Clear();
            box.ForeColor = Color.Black;
        }
    }
}