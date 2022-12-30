using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using KompasWrapper;

namespace TableBuild
{
	/// <summary>
	/// Главное окно
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Параметры стола
		/// </summary>
		private TableParameters _parameters = new TableParameters();

		/// <summary>
		/// Строитель стола
		/// </summary>
		private TableBuilder _builder = new TableBuilder();

		/// <summary>
		/// Словарь текстбоксов
		/// </summary>
		private readonly Dictionary<TextBox, ParameterType> _parameterTypes;

		/// <summary>
		/// Конструктор
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			_parameterTypes = new Dictionary<TextBox, ParameterType>
			{
				{HeightTableLegTextBox, ParameterType.HeightTableLeg},
				{HeightTableBodyTextBox, ParameterType.HeightTable},
				{LengthTableTextBox, ParameterType.LengthTable},
				{TableCornersRoundingTextBox, ParameterType.TableCornersRadius},
				{TableEdgeRoundingTextBox, ParameterType.TableEdgeRadius},
				{WidthTableTextBox, ParameterType.WidthTable},
				{ShelvesCountTextBox, ParameterType.ShelvesCount}
			};

			SetValues();
		}

		/// <summary>
		/// Установить значения из экземпляра класса <see cref="TableParameters"/>
		/// </summary>
		private void SetValues()
		{
			HeightTableLegTextBox.Text = _parameters.GetValue(
				ParameterType.HeightTableLeg).ToString();
			HeightTableBodyTextBox.Text = _parameters.GetValue(
				ParameterType.HeightTable).ToString();
			LengthTableTextBox.Text = _parameters.GetValue(
				ParameterType.LengthTable).ToString();
			TableCornersRoundingTextBox.Text = _parameters.GetValue(
				ParameterType.TableCornersRadius).ToString();
			TableEdgeRoundingTextBox.Text = _parameters.GetValue(
				ParameterType.TableEdgeRadius).ToString();
			WidthTableTextBox.Text = _parameters.GetValue(
				ParameterType.WidthTable).ToString();
			ShelvesCountTextBox.Text= _parameters.GetValue(
				ParameterType.ShelvesCount).ToString();
		}
		
		/// <summary>
		/// Обработчик события нажатия на кнопку
		/// </summary>
		private void Button1_Click(object sender, EventArgs e)
		{
			if (_parameters.HasError)
			{
				MessageBox.Show(_parameters.ErrorsMessage, "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_builder.Build(_parameters);
		}

		/// <summary>
		/// Обработчик события для текстбоксов
		/// </summary>
		private void TextBox_TextChanged(object sender, EventArgs e)
		{
			if (!(sender is TextBox textBox))
			{
				return;
			}

			var errorTextBox = textBox;
			var type = _parameterTypes[textBox];
			var text = textBox.Text;
			try
			{
				textBox.BackColor = Color.White;
				_parameters.SetValue(type, text);
			}
			catch (ArgumentException exception)
			{
				var errorType = (ParameterType)Enum.Parse(
					typeof(ParameterType), exception.ParamName);
				errorTextBox = _parameterTypes.First(
					parameter => 
						parameter.Value == errorType).Key;
				errorTextBox.BackColor = Color.MistyRose;
				return;
			}

			errorTextBox.BackColor = Color.White;
		}
		
		/// <summary>
		/// Оброботчик события наведения мыши на текстбокс
		/// </summary>
        private void TextBox_MouseHover(object sender, EventArgs e)
		{
			if (!(sender is TextBox textBox))
			{
				return;
			}
			
			var type = _parameterTypes[textBox];
			if (_parameters.Errors.ContainsKey(type))
			{
				ErrorToolTip.Show(_parameters.Errors[type], textBox);
			}
		}
	}
}
