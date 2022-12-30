using System;
using Core;
using NUnit.Framework;

namespace TestCore
{
	/// <summary>
	/// Тест класса <see cref="Core.Parameter"/>
	/// </summary>
	public class ParameterTest
	{
		/// <summary>
		/// Возвращает новый параметр
		/// </summary>
		private Parameter Parameter => new Parameter(1, 10, 5);

		[TestCase(-12, TestName = "Проверка некорректного установления значения. " +
		                          "Установка значения меньшего минимального. " +
		                          "Должно выкинуть исключение")]
		[TestCase(99999, TestName = "Проверка некорректного установления значения. " +
									"Установка значения больше максимального. " +
		                            "Должно выкинуть исключение")]
		public void TestSetValue_IncorrectValue(double value)
		{
			var parameter = Parameter;

			Assert.Throws<ArgumentException>(() => parameter.Value = value,
				"Удалось присвоить некорректное значение!");
		}

		[TestCase(TestName = "Проверка корректного установления значения. " +
		                     "Не должно выбросится исключение.")]
		public void TestSetValue_CorrectValue()
		{
			var parameter = Parameter;
			var value = 2;

			Assert.DoesNotThrow(() => parameter.Value = value,
				"Не удалось присвоить корректное значение!");
		}

		[TestCase(TestName = "Проверка корректного получения значения.")]
		public void TestGetValue_CorrectValue()
		{
			var parameter = Parameter;
			var excepted = 2;

			parameter.Value = excepted;

			var actual = parameter.Value;

			Assert.AreEqual(excepted, actual,
				"Вернулось некорректное значение!");
		}

		[TestCase(TestName = "Проверка корректного установления" +
		                     " максимального значения. " +
		                     "Не должно выбросится исключение.")]
		public void TestSetMaxValue_CorrectValue()
		{
			var parameter = Parameter;
			var value = 200;

			Assert.DoesNotThrow(() => parameter.MaxValue = value,
				"Не удалось присвоить корректное значение!");
		}

		[TestCase(TestName = "Проверка корректного получения " +
		                     "максимального значения.")]
		public void TestMaxValue_CorrectValue()
		{
			var parameter = Parameter;
			var excepted = 200;

			parameter.MaxValue = excepted;

			var actual = parameter.MaxValue;

			Assert.AreEqual(excepted, actual,
				"Вернулось некорректное значение!");
		}

		[TestCase(TestName = "Проверка корректного установления " +
		                     "минимального значения. " +
		                     "Не должно выбросится исключение.")]
		public void TestSetMinValue_CorrectValue()
		{
			var parameter = Parameter;
			var value = -12;

			Assert.DoesNotThrow(() => parameter.MinValue = value,
				"Не удалось присвоить корректное значение!");
		}

		[TestCase(TestName = "Проверка корректного получения" +
		                     " минимального значения.")]
		public void TestGetMinValue_CorrectValue()
		{
			var parameter = Parameter;
			var excepted = -12;

			parameter.MinValue = excepted;

			var actual = parameter.MinValue;

			Assert.AreEqual(excepted, actual,
				"Вернулось некорректное значение!");
		}
	}
}