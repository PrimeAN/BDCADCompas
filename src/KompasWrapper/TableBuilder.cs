using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Core;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasWrapper
{
	/// <summary>
	/// Класс построения комода
	/// </summary>
	public class TableBuilder
	{
		/// <summary>
		/// Толщина стенок
		/// </summary>
		private const int WallsWidth = 20;

		/// <summary>
		/// Ширина ножек
		/// </summary>
		private const int LegsWidth = 20;

		/// <summary>
		/// Первое расстояние от угла
		/// </summary>
		private const int LegsDistance1 = 28;

		/// <summary>
		/// Второе расстояние от угла
		/// </summary>
		private const int LegsDistance2 = 38;

		/// <summary>
		///  Расстояние от отверстий
		/// </summary>
		const int HoleDistance = 30;

		/// <summary>
		/// Координаты ножек комода
		/// </summary>
		private readonly List<Point> _legPoints = new List<Point>();

		/// <summary>
		/// Длина ящиков
		/// </summary>
		private double _boxLength;

		/// <summary>
		/// Экземпляр класса работы с Компас 3D
		/// </summary>
		private readonly KompasWrapper _kompasWrapper;

		/// <summary>
		/// Часть модели
		/// </summary>
		private ksPart _part;

		/// <summary>
		/// Параметры модели
		/// </summary>
		private TableParameters _parameters;

		/// <summary>
		/// Конструктор
		/// </summary>
		public TableBuilder()
		{
			_kompasWrapper = new KompasWrapper();
		}

		/// <summary>
		/// Построить модель
		/// </summary>
		/// <param name="parameters">Параметры</param>
		public void Build(TableParameters parameters)
		{
			_legPoints.Clear();
			_parameters = parameters;
			_kompasWrapper.RunKompas();
			ksDocument3D document3D = _kompasWrapper.KompasObject.Document3D();
			document3D.Create();
			_part = document3D.GetPart((int)Part_Type.pTop_Part);

			CreateBody();
			CreateHoles();
			CreateLegs();
			CreateEdge();
			CreateHead();
			CreateDoor();
		}

		/// <summary>
		/// Создает двери
		/// </summary>
		private void CreateDoor()
		{
			const double doorDistance = 2;
			const double doorWidth = 10;
			var dresserHeight = _parameters.GetValue(
				ParameterType.HeightTable);
			var halfWidth = _parameters.GetValue(
				ParameterType.WidthTable) / 2;
			var lenght = _parameters.GetValue(
				ParameterType.LengthTable);
			ksEntity plane = _kompasWrapper.CreatePlaneOffset(_part, halfWidth, Obj3dType.o3d_planeXOZ);
			ksEntity sketch = _part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();

			var point1 = new Point(-lenght/2,
				-dresserHeight + HoleDistance + doorDistance);
			var point2 = new Point(-doorDistance, -doorDistance);
			var point3 = new Point(doorDistance,
				-dresserHeight + HoleDistance + doorDistance);
			var point4 = new Point(lenght / 2, -doorDistance);

			CreateRectangle(point1, point2, document2D);
			CreateRectangle(point3, point4, document2D);

			sketchDefinition.EndEdit();

			_kompasWrapper.BossExtrusion(_part, sketch, doorWidth,
				Direction_Type.dtNormal);

			CreateDoorHole(doorDistance, doorWidth);
		}

		/// <summary>
		/// Сделать отверстия в двери
		/// </summary>
		private void CreateDoorHole(double doorDistance, double doorWidth)
		{
			var dresserHeight = _parameters.GetValue(
				ParameterType.HeightTable);
			var halfWidth = _parameters.GetValue(
				ParameterType.WidthTable) / 2;
			ksEntity plane = _kompasWrapper.CreatePlaneOffset(_part, halfWidth, Obj3dType.o3d_planeXOZ);
			ksEntity sketch = _part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();
			const double holeRadius = 25;

			var document2D = sketchDefinition.BeginEdit();

			var y = -dresserHeight + HoleDistance + doorDistance * 2 + holeRadius * 2;
			var circlePoint1 = new Point((doorDistance + holeRadius) * 2, y);
			var circlePoint2 = new Point((-doorDistance - holeRadius)* 2, y);

			CreateEllipse(circlePoint1.X, circlePoint1.Y,
				holeRadius, holeRadius, document2D);
			CreateEllipse(circlePoint2.X, circlePoint2.Y,
				holeRadius, holeRadius, document2D);
			sketchDefinition.EndEdit();

			_kompasWrapper.CutEvolution(_part, sketch, -doorWidth);
		}

		/// <summary>
		/// Создать верхнюю часть стола
		/// </summary>
		private void CreateHead()
		{
			var radius = _parameters.GetValue(ParameterType.TableCornersRadius);
			if (radius == 0)
			{
				return;
			}

			var height = _parameters.GetValue(
				ParameterType.HeightTable);
			ksEntity plane = _kompasWrapper.CreatePlaneOffset(_part, height, Obj3dType.o3d_planeXOY);
			ksEntity sketch = _part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			var halfLength = _parameters.GetValue(ParameterType.LengthTable) / 2;
			var halfWidth = _parameters.GetValue(
				ParameterType.WidthTable) / 2 + HoleDistance;

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			var points = new List<Point>
			{
				new Point(halfLength, halfWidth),
				new Point(halfLength, halfWidth - radius),
				new Point(halfLength - radius, halfWidth)
			};

			CreateCornersConnection(document2D, points, radius,
				new[] {0, 90}, 0);

			points = new List<Point>
			{
				new Point(-halfLength, halfWidth),
				new Point(-halfLength, halfWidth - radius),
				new Point(-halfLength + radius, halfWidth)
			};

			CreateCornersConnection(document2D, points, radius,
				new[] { 90, 180 }, 0);

			points = new List<Point>
			{
				new Point(halfLength, -halfWidth),
				new Point(halfLength, -halfWidth + radius),
				new Point(halfLength - radius, -halfWidth)
			};

			CreateCornersConnection(document2D, points, radius,
				new[] { 0, -90}, -1);

			points = new List<Point>
			{
				new Point(-halfLength, -halfWidth),
				new Point(-halfLength, -halfWidth + radius),
				new Point(-halfLength + radius, -halfWidth)
			};

			CreateCornersConnection(document2D, points, radius,
				new[] { 180, 270 }, 1);

			sketchDefinition.EndEdit();
			
			_kompasWrapper.CutEvolution(_part, sketch, HoleDistance);
		}
		
		/// <summary>
		/// Создает соединения углов
		/// </summary>
		/// <param name="document2D">2Д эскиз</param>
		/// <param name="points">Коллекция точек</param>
		/// <param name="radius">Радиус закругления</param>
		/// <param name="angles">Углы для построения округления</param>
		/// <param name="direction">Направление</param>
		private void CreateCornersConnection(ksDocument2D document2D, List<Point> points,
			double radius, int[] angles, short direction)
		{
			document2D.ksLineSeg(points[0].X, 
				points[0].Y, points[1].X, points[1].Y, 1);
			document2D.ksLineSeg(points[0].X, 
				points[0].Y, points[2].X, points[2].Y, 1);
			document2D.ksArcByAngle(points[2].X, points[1].Y,
				radius, angles[0], angles[1], direction, 1);
		}

		/// <summary>
		/// Создает округленные ребра
		/// </summary>
		private void CreateEdge()
		{
			var radius = _parameters.GetValue(
				ParameterType.TableEdgeRadius);
			if (radius == 0)
			{
				return;
			}

			ksEntity plane = _part.GetDefaultEntity((int)Obj3dType.o3d_planeYOZ);
			ksEntity sketch = _part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();

			var height = _parameters.GetValue(
				ParameterType.HeightTable);
			var halfWidth = _parameters.GetValue(
				ParameterType.WidthTable) / 2;
			var points = new List<Point>
			{
				new Point(-height, halfWidth),
				new Point(-height + HoleDistance, halfWidth),
				new Point(-height + HoleDistance, 
					halfWidth + HoleDistance - radius),
				new Point(-height + HoleDistance - radius,
					halfWidth + HoleDistance),
				new Point(-height, 
					halfWidth + HoleDistance - radius),
				new Point(-height + radius,
					halfWidth + HoleDistance)
			};

			CreateEdgeConnection(document2D, points, radius, new[] {0, 90, 90, 180});

			points = points.Select(point => new Point(point.X, -point.Y)).ToList();
			CreateEdgeConnection(document2D, points, radius, new[] {270, 360, 180, 270});

			sketchDefinition.EndEdit();

			_kompasWrapper.BossExtrusion(_part, sketch, _parameters.GetValue(
				ParameterType.LengthTable), Direction_Type.dtMiddlePlane);
		}

		/// <summary>
		/// Создает соединения ребер
		/// </summary>
		/// <param name="document2D">2Д эскиз</param>
		/// <param name="points">Коллекция точек</param>
		/// <param name="radius">Радиус закругления</param>
		/// <param name="angels">Углы для построения округления</param>
		private void CreateEdgeConnection(ksDocument2D document2D, List<Point> points, double radius, int[] angels)
		{
			document2D.ksLineSeg(points[0].X, points[0].Y,
				points[1].X, points[1].Y, 1);
			document2D.ksLineSeg(points[1].X, points[1].Y,
				points[2].X, points[2].Y, 1);
			document2D.ksLineSeg(points[3].X, points[3].Y,
				points[5].X, points[5].Y, 1);
			document2D.ksLineSeg(points[0].X, points[0].Y,
				points[4].X, points[4].Y, 1);
			document2D.ksArcByAngle(points[3].X, points[2].Y,
				radius, angels[0], angels[1], 0, 1);
			document2D.ksArcByAngle(points[5].X, points[4].Y,
				radius, angels[2], angels[3], 0, 1);
		}

		/// <summary>
		/// Создать ножки
		/// </summary>
		private void CreateLegs()
		{
			ksEntity plane = _part.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
			ksEntity sketch = _part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();

			foreach (var point1 in _legPoints)
			{
				CreateEllipse(point1.X, point1.Y, 
					LegsWidth, LegsWidth,
					document2D);
			}

			var legsHeight = _parameters.GetValue(
				ParameterType.HeightTableLeg);
			sketchDefinition.EndEdit();
			_kompasWrapper.BossExtrusion(_part, sketch, -legsHeight,
				Direction_Type.dtNormal);
		}

		/// <summary>
		/// Создать тело стола
		/// </summary>
		private void CreateBody()
		{
			ksEntity plane = _part.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
			ksEntity sketch = _part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			
			var halfLength = _parameters.GetValue(
				ParameterType.LengthTable) / 2;
			var halfWidth = _parameters.GetValue(
				ParameterType.WidthTable) / 2;
			var point1 = new Point(-halfLength, -halfWidth);
			var point2 = new Point(halfLength, halfWidth);
			CreateRectangle(point1, point2, document2D);

			// Установка координат для ножек
			_legPoints.Add(new Point(point1.X + LegsDistance1,
				point1.Y + LegsDistance2));
			_legPoints.Add(new Point(point2.X - LegsDistance1 - LegsWidth,
				point1.Y + LegsDistance2));
			_legPoints.Add(new Point(point1.X + LegsDistance1,
				point2.Y - LegsDistance2 - LegsWidth));
			_legPoints.Add(new Point(point2.X - LegsDistance1 - LegsWidth,
				point2.Y - LegsDistance2 - LegsWidth));

			_boxLength = 2 * (halfLength - WallsWidth);

			sketchDefinition.EndEdit();

			_kompasWrapper.BossExtrusion(_part, sketch, _parameters.GetValue(
				ParameterType.HeightTable), Direction_Type.dtNormal);
		}

		/// <summary>
		/// Создает отверстия для ящиков
		/// </summary>
		private void CreateHoles()
		{
			var holeNumber = _parameters.GetValue(
				ParameterType.ShelvesCount);
			var dresserHeight = _parameters.GetValue(
				ParameterType.HeightTable);
			var boxHeight =
				(dresserHeight - HoleDistance * (holeNumber + 1))
				/ holeNumber;

			var halfWidth = _parameters.GetValue(
				ParameterType.WidthTable) / 2;
			ksEntity plane = _kompasWrapper.CreatePlaneOffset(_part, halfWidth, Obj3dType.o3d_planeXOZ);
			ksEntity sketch = _part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();

			var point1 = new Point(-_boxLength / 2,
				-dresserHeight + HoleDistance);
			var point2 = new Point(_boxLength / 2,
				point1.Y + boxHeight);
			for (int i = 0; i < holeNumber; i++)
			{
				CreateRectangle(point1, point2, document2D);
				point1 = new Point(-_boxLength / 2,
					point2.Y + HoleDistance);
				point2 = new Point(_boxLength / 2,
					point1.Y + boxHeight);
			}

			sketchDefinition.EndEdit();

			_kompasWrapper.CutEvolution(_part, sketch,
				_parameters.GetValue(
					ParameterType.WidthTable) - WallsWidth);
		}
		
		/// <summary>
		/// Создать прямоугольник по двум точкам
		/// </summary>
		/// <param name="point1">Координата первой точки</param>
		/// <param name="point2">Координата второй точки</param>
		/// <param name="document2D">Эскиз</param>
		private void CreateRectangle(Point point1,
			Point point2, ksDocument2D document2D)
		{
			var length = Math.Abs(point1.X - point2.X);
			var width = Math.Abs(point1.Y - point2.Y);
			document2D.ksLineSeg(point1.X, point1.Y,
				point1.X + length, point1.Y, 1);
			document2D.ksLineSeg(point1.X + length, point1.Y,
				point1.X + length, point1.Y + width, 1);
			document2D.ksLineSeg(point1.X, point1.Y + width,
				point1.X + length, point1.Y + width, 1);
			document2D.ksLineSeg(point1.X, point1.Y,
				point1.X, point1.Y + width, 1);
		}
		
		/// <summary>
		/// Создает эллипс
		/// </summary>
		/// <param name="xc">Х координата центра эллипса</param>
		/// <param name="yc">Y координата центра эллипса</param>
		/// <param name="radius1">Первый радиус эллипса</param>
		/// <param name="radius2">Второй радиус эллипса</param>
		/// <param name="document2D">Эскиз</param>
		private void CreateEllipse(double xc, double yc,
			double radius1, double radius2, ksDocument2D document2D)
		{
			const int ellipseParamId = 22;
			ksEllipseParam ellipseParam = _kompasWrapper.KompasObject.GetParamStruct(ellipseParamId);
			ellipseParam.xc = xc;
			ellipseParam.yc = yc;
			ellipseParam.A = radius1;
			ellipseParam.B = radius2;
			ellipseParam.style = 1;
			document2D.ksEllipse(ellipseParam);
		}
	}
}