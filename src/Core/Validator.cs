using System;

namespace Core
{
	/// <summary>
	/// Класс валидации
	/// </summary>
	public static class Validator
	{
        //TODO: 
		/// <summary>
		/// Проверка значение на вхождение в промежуток
		/// </summary>
		/// <param name="value">Значение для проверки</param>
		/// <param name="minValue">Минимальное значение</param>
		/// <param name="maxValue">Максимальное значение</param>
		public static void CheckValue(double value,
			double minValue, double maxValue)
		{
			if (value < minValue || value > maxValue)
			{
				throw new ArgumentException(
					"Значение должно входить в " +
					$"диапазон {minValue} — {maxValue}!" +
					$" Текущее значение {value}");
			}
		}
	}
}