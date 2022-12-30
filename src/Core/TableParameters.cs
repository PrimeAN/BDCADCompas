using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
	/// <summary>
	/// Класс, содержащий все параметры стола
	/// </summary>
	public class TableParameters
	{
		/// <summary>
		/// Словарь параметров стола
		/// </summary>
		private Dictionary<ParameterType, Parameter> _parameters =
			new Dictionary<ParameterType, Parameter>
			{
				{
					ParameterType.HeightTable,
					new Parameter(600, 1050, 600)
				},
				{
					ParameterType.HeightTableLeg,
					new Parameter(50, 80, 80)
				},
				{
					ParameterType.WidthTable,
					new Parameter(600, 1000, 600)
				},
				{
					ParameterType.LengthTable,
					new Parameter(450, 750, 450)
				},
				{
					ParameterType.TableCornersRadius,
					new Parameter(0, 30, 10)
				},
				{
					ParameterType.TableEdgeRadius,
					new Parameter(0, 15, 10)
				},
				{
					ParameterType.ShelvesCount,
					new Parameter(1, 4, 2)
				}
			};

		/// <summary>
		/// Словарь ошибок
		/// </summary>
		public Dictionary<ParameterType, string> Errors { get; }  =
			new Dictionary<ParameterType, string>();

		/// <summary>
		/// Возвращает <see cref="true"/>, если есть ошибка
		/// </summary>
		public bool HasError => Errors.Any();

		/// <summary>
		/// Возвращает тексты ошибок
		/// </summary>
		public string ErrorsMessage => string.Join("\n", Errors.Values);

		/// <summary>
		/// Получить значение параметра
		/// </summary>
		/// <param name="type">Тип параметра</param>
		/// <returns></returns>
		public double GetValue(ParameterType type)
		{
			return _parameters[type].Value;
		}

		/// <summary>
		/// Установить значение параметру
		/// </summary>
		/// <param name="type">Тип параметра</param>
		/// <param name="value">Значение</param>
		public void SetValue(ParameterType type, double value)
		{
			ClearError(type);
			try
			{
				_parameters[type].Value = value;
			}
			catch (ArgumentException e)
			{
				Errors.Add(type, e.Message);
				throw new ArgumentException(e.Message, type.ToString(), e);
			}

			switch (type)
			{
				case ParameterType.WidthTable:
				{
					var selectedType = ParameterType.LengthTable;
					ClearError(selectedType);
					var newValue = 
						_parameters[selectedType].Value;
					const double minimumCoefficient = 0.75;
					const double addingToMaximum = 300;

					var minValue = minimumCoefficient * _parameters[type].Value;
					var maxValue = minValue + addingToMaximum;
					TrySetValue(minValue, maxValue, newValue,
						selectedType);
					break;
				}
				case ParameterType.HeightTable:
				{
					var selectedType = ParameterType.HeightTableLeg;
					ClearError(selectedType);
						var newValue =
						_parameters[selectedType].Value;
					var minValue = _parameters[selectedType].MinValue;
					const double maximumCoefficient = 7.5;
					
                    var maxValue = _parameters[type].Value / maximumCoefficient;
					TrySetValue(minValue, maxValue, newValue,
						selectedType);
					break;
				}
			}
		}

		/// <summary>
		/// Установить значение параметру
		/// </summary>
		/// <param name="type">Тип параметра</param>
		/// <param name="stringValue">Значение в виде строки</param>
		public void SetValue(ParameterType type, string stringValue)
		{
			ClearError(type);
			if (!double.TryParse(stringValue, out var value))
			{
				var message = $"Значение {stringValue} не является числом!";
				Errors.Add(type, message);
				throw new ArgumentException(message, type.ToString());
			}

			SetValue(type, value);
		}

		/// <summary>
		/// Очищает ошибку по типу
		/// </summary>
		/// <param name="type">Тип параметра</param>
		private void ClearError(ParameterType type)
		{
			if (Errors.ContainsKey(type))
			{
				Errors.Remove(type);
			}
		}

		/// <summary>
		/// Попытка установления новых значений параметра
		/// </summary>
		/// <param name="minValue">Минимальное значение</param>
		/// <param name="maxValue">Максимальное значение</param>
		/// <param name="newValue">Новое значение</param>
		/// <param name="type">Тип параметра</param>
		private void TrySetValue(double minValue, 
			double maxValue, double newValue, ParameterType type)
		{
			try
			{
				_parameters[type].MaxValue = maxValue;
				_parameters[type].MinValue = minValue;
				_parameters[type].Value = newValue;
			}
			catch (ArgumentException e)
			{
				Errors.Add(type, e.Message);
				throw new ArgumentException(e.Message, type.ToString(), e);
			}
		}
	}
}