using System;
using System.Runtime.InteropServices;
using Core;
using NUnit.Framework;

namespace TestCore
{
	/// <summary>
	/// Класс тестирования <see cref="Core.TableParameters"/>
	/// </summary>
	[TestFixture]
	public class TableParametersTest
	{
		/// <summary>
		/// Возвращает новый экземпляр класса <see cref="Core.TableParameters"/>
		/// </summary>
		private TableParameters Parameters => new TableParameters();

		[TestCase(ParameterType.HeightTable, 
			600,
			TestName = "Проверка корректного получения" +
							 " значения параметра HeightTable.")]
		[TestCase(ParameterType.HeightTableLeg,
			80,
			TestName = "Проверка корректного получения" +
							 " значения параметра HeightTableLeg.")]
		[TestCase(ParameterType.WidthTable,
			600,
			TestName = "Проверка корректного получения" +
							 " значения параметра WidthTable.")]
		[TestCase(ParameterType.LengthTable,
			450,
			TestName = "Проверка корректного получения" +
							 " значения параметра LengthTable.")]
		[TestCase(ParameterType.TableCornersRadius,
			10,
			TestName = "Проверка корректного получения" +
							 " значения параметра TableCornersRadius.")]
		[TestCase(ParameterType.TableEdgeRadius,
			10,
			TestName = "Проверка корректного получения" +
							 " значения параметра TableEdgeRadius.")]
		[TestCase(ParameterType.ShelvesCount,
			2,
			TestName = "Проверка корректного получения" +
							 " значения параметра ShelvesCount.")]
		public void TestGetValueParameter_CorrectValue(ParameterType parameterType, int expected)
		{
			var parameters = Parameters;

			var actual = parameters.GetValue(parameterType);

			Assert.AreEqual(expected, actual, 
				"Не вернулось ожидаемое значение!");
		}

		[TestCase(ParameterType.HeightTable,
			700,
			TestName = "Проверка корректного присвоения" +
					   " значения параметра HeightTable.")]
		[TestCase(ParameterType.HeightTableLeg,
			70,
			TestName = "Проверка корректного присвоения" +
					   " значения параметра HeightTableLeg.")]
		[TestCase(ParameterType.WidthTable,
			600,
			TestName = "Проверка корректного присвоения" +
					   " значения параметра WidthTable.")]
		[TestCase(ParameterType.LengthTable,
			550,
			TestName = "Проверка корректного присвоения" +
					   " значения параметра LengthTable.")]
		[TestCase(ParameterType.TableCornersRadius,
			12,
			TestName = "Проверка корректного присвоения" +
					   " значения параметра TableCornersRadius.")]
		[TestCase(ParameterType.TableEdgeRadius,
			0,
			TestName = "Проверка корректного присвоения" +
					   " значения параметра TableEdgeRadius.")]
		[TestCase(ParameterType.ShelvesCount,
			1,
			TestName = "Проверка корректного присвоения" +
			           " значения параметра ShelvesCount.")]
		public void TestSetValueParameter_CorrectValue(ParameterType parameterType, int value)
		{
			var parameters = Parameters;

			Assert.DoesNotThrow(() => parameters.SetValue(parameterType, value));
			
			var expected = value;

			var actual = parameters.GetValue(parameterType);

			Assert.AreEqual(expected, actual,
				"Не присвоилось значение!");
			Assert.IsFalse(parameters.HasError);
			Assert.IsTrue(string.IsNullOrEmpty(parameters.ErrorsMessage));
		}

		[TestCase(ParameterType.WidthTable,
			700,
			TestName = "Проверка некорректного присвоения" +
			           " значения параметра WidthTable.")]
		[TestCase(ParameterType.HeightTable,
			-700,
			TestName = "Проверка некорректного присвоения" +
			           " значения параметра HeightTable.")]
		[TestCase(ParameterType.HeightTableLeg,
			99970,
			TestName = "Проверка некорректного присвоения" +
			           " значения параметра HeightTableLeg.")]
		[TestCase(ParameterType.LengthTable,
			-550,
			TestName = "Проверка некорректного присвоения" +
			           " значения параметра LengthTable.")]
		[TestCase(ParameterType.TableCornersRadius,
			120050,
			TestName = "Проверка некорректного присвоения" +
			           " значения параметра TableCornersRadius.")]
		[TestCase(ParameterType.TableEdgeRadius,
			-45100,
			TestName = "Проверка некорректного присвоения" +
			           " значения параметра TableEdgeRadius.")]
		[TestCase(ParameterType.ShelvesCount,
			20,
			TestName = "Проверка некорректного получения" +
			           " значения параметра ShelvesCount.")]
		public void TestSetValueParameter_IncorrectValue(ParameterType parameterType, int value)
		{
			var parameters = Parameters;

			Assert.Throws<ArgumentException>(
				() => parameters.SetValue(parameterType, value),
				"Присвоилось некорректное значение!");
			Assert.IsTrue(parameters.HasError);
			Assert.IsFalse(string.IsNullOrEmpty(parameters.ErrorsMessage));
		}

		[TestCase(TestName = "Проверка очистки ошибки")]
		public void TestClearError()
		{
			var parameters = Parameters;

			Assert.Throws<ArgumentException>(() =>
				parameters.SetValue(ParameterType.WidthTable, 700));

			Assert.IsTrue(parameters.HasError);
			Assert.IsFalse(string.IsNullOrEmpty(parameters.ErrorsMessage));

			parameters.SetValue(ParameterType.WidthTable, 600);

			Assert.IsFalse(parameters.HasError);
			Assert.IsTrue(string.IsNullOrEmpty(parameters.ErrorsMessage));
		}

		[TestCase(ParameterType.HeightTable,
			"700",
			TestName = "Проверка корректного присвоения" +
					   " значения параметра HeightTable.")]
		[TestCase(ParameterType.HeightTableLeg,
			"70",
			TestName = "Проверка корректного присвоения" +
					   " значения параметра HeightTableLeg.")]
		[TestCase(ParameterType.WidthTable,
			"600",
			TestName = "Проверка корректного присвоения" +
					   " значения параметра WidthTable.")]
		[TestCase(ParameterType.LengthTable,
			"550",
			TestName = "Проверка корректного присвоения" +
					   " значения параметра LengthTable.")]
		[TestCase(ParameterType.TableCornersRadius,
			"12",
			TestName = "Проверка корректного присвоения" +
					   " значения параметра TableCornersRadius.")]
		[TestCase(ParameterType.TableEdgeRadius,
			"0",
			TestName = "Проверка корректного присвоения" +
					   " значения параметра TableEdgeRadius.")]
		public void TestSetValueParameter_CorrectStringValue(ParameterType parameterType, string value)
		{
			var parameters = Parameters;

			Assert.DoesNotThrow(() => parameters.SetValue(parameterType, value));

			var expected = int.Parse(value);

			var actual = parameters.GetValue(parameterType);

			Assert.AreEqual(expected, actual,
				"Не присвоилось значение!");
			Assert.IsFalse(parameters.HasError);
			Assert.IsTrue(string.IsNullOrEmpty(parameters.ErrorsMessage));
		}

		[TestCase(ParameterType.WidthTable,
			"700",
			TestName = "Проверка некорректного присвоения" +
					   " значения параметра WidthTable.")]
		[TestCase(ParameterType.HeightTable,
			"-700",
			TestName = "Проверка некорректного присвоения" +
					   " значения параметра HeightTable.")]
		[TestCase(ParameterType.HeightTableLeg,
			"asdasdasd",
			TestName = "Проверка некорректного присвоения" +
					   " значения параметра HeightTableLeg.")]
		[TestCase(ParameterType.LengthTable,
			"-550",
			TestName = "Проверка некорректного присвоения" +
					   " значения параметра LengthTable.")]
		[TestCase(ParameterType.TableCornersRadius,
			"sadfasda",
			TestName = "Проверка некорректного присвоения" +
					   " значения параметра TableCornersRadius.")]
		[TestCase(ParameterType.TableEdgeRadius,
			"-45100",
			TestName = "Проверка некорректного присвоения" +
					   " значения параметра TableEdgeRadius.")]
		public void TestSetValueParameter_IncorrectStringValue(ParameterType parameterType, string value)
		{
			var parameters = Parameters;

			Assert.Throws<ArgumentException>(
				() => parameters.SetValue(parameterType, value),
				"Присвоилось некорректное значение!");
			Assert.IsTrue(parameters.HasError);
			Assert.IsFalse(string.IsNullOrEmpty(parameters.ErrorsMessage));
		}
	}
}
