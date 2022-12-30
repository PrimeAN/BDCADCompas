using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasWrapper
{
	/// <summary>
	/// Класс для работы с Компас 3D
	/// </summary>
    public class KompasWrapper
    {
		/// <summary>
		/// Возвращает экземпляр Компас 3D
		/// </summary>
		public KompasObject KompasObject { get; private set; }

		/// <summary>
		/// Запускает Компас 3D
		/// </summary>
		public void RunKompas()
		{
			if (KompasObject == null)
			{
				var kompasType = Type.GetTypeFromProgID(
					"KOMPAS.Application.5");
				KompasObject = (KompasObject)Activator.CreateInstance(kompasType);
			}

			if (KompasObject != null)
			{
				var retry = true;
				short tried = 0;
				while (retry)
				{
					try
					{
						tried++;
						KompasObject.Visible = true;
						retry = false;
					}
					catch (COMException)
					{
						var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
						KompasObject =
							(KompasObject)Activator.CreateInstance(kompasType);

						if (tried > 3)
						{
							retry = false;
						}
					}
				}

				KompasObject.ActivateControllerAPI();
			}
		}

		/// <summary>
		/// Выдавливание объекта
		/// </summary>
		/// <param name="part"></param>
		/// <param name="sketch"></param>
		/// <param name="height"></param>
		/// <param name="directionType"></param>
		public void BossExtrusion(ksPart part, ksEntity sketch, double height, Direction_Type directionType)
		{
			ksEntity extrude = part.NewEntity((int)Obj3dType.o3d_bossExtrusion);
			ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
			extrudeDefinition.directionType = (short)directionType;
			extrudeDefinition.SetSketch(sketch);
			ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
			extrudeParam.depthNormal = height;
			extrude.Create();
		}
		
		/// <summary>
		/// Выдавливание с вырезом
		/// </summary>
		/// <param name="part"></param>
		/// <param name="sketch"></param>
		/// <param name="depth"></param>
		public void CutEvolution(ksPart part, ksEntity sketch, double depth)
		{
			// Выдавливание с вырезом
			ksEntity cutExtrusion =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
			ksCutExtrusionDefinition extrusionDefinition =
				cutExtrusion.GetDefinition();
			ksExtrusionParam extrusionParam =
				(ksExtrusionParam)extrusionDefinition.ExtrusionParam();
			extrusionDefinition.SetSketch(sketch);
			extrusionParam.direction = (short)Direction_Type.dtNormal;
			extrusionParam.typeNormal = (short)End_Type.etBlind;
			extrusionParam.depthNormal = depth;
			cutExtrusion.Create();
		}

		/// <summary>
		/// Создание плоскости относительно плоскости <see cref="type"/> на расстоянии <see cref="offsetValue"/> 
		/// </summary>
		/// <param name="part"></param>
		/// <param name="offsetValue"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public ksEntity CreatePlaneOffset(ksPart part, double offsetValue, Obj3dType type)
		{
			ksEntity plane = part.GetDefaultEntity((short)type);
			ksEntity planeOffset = part.NewEntity((int)Obj3dType.o3d_planeOffset);
			ksPlaneOffsetDefinition planeOffsetDefinition = planeOffset.GetDefinition();
			planeOffsetDefinition.direction = true;
			planeOffsetDefinition.offset = offsetValue;
			planeOffsetDefinition.SetPlane(plane);
			planeOffset.Create();
			return planeOffset;
		}
    }
}
