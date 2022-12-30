using System;
using Core;
using NUnit.Framework;

namespace TestCore
{
	/// <summary>
	/// Тестовый класс для валидатора <see cref="Validator"/>
	/// </summary>
	public class ValidatorTest
	{
		[TestCase(TestName = "Проверка корректного прохождения валидации")]
		public void TestCheckValue_CorrectValue()
		{
			var value = 10;
			var maxValue = 20;
			var minValue = 0;

			Assert.DoesNotThrow(() => 
				Validator.CheckValue(value, minValue, maxValue),
				"Не пройден тест! Проверка вхождения значение" +
				" в диапазон не пройдена");
		}

		[TestCase(-12, TestName = "Проверка прохождения валидации " +
								  "при введённом значении " +
		                          "меньшему минимальному. " + 
		                          "Должно выкинуть исключение")]
		[TestCase(99999, TestName = "Проверка прохождения валидации " +
								  "при введённом значении " +
		                          "большему максимального. " +
		                          "Должно выкинуть исключение")]
		public void TestCheckValue_IncorrectValue(double value)
		{
			var maxValue = 20;
			var minValue = 0;

			Assert.Throws<ArgumentException>(() =>
				Validator.CheckValue(value, minValue, maxValue),
			"Не пройден тест! Проверка вхождения значение" +
				" в диапазон пройдена");
		}
	}
}