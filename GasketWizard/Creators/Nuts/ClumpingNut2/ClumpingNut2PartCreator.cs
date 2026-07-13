using GasketWizard.Domain.Nut;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using KompasAPI7;
using System.Runtime.InteropServices;

namespace GasketWizard.Creators.Nuts
{
    public class ClumpingNut2PartCreator : ClumpingNut2Creator
    {
        private readonly IPartDocument _partDocument;

        private IPart7 _nutPart;


        public ClumpingNut2PartCreator(ClumpingNut2 partModel, IPartDocument partDocument) : base(partModel)
        {
            _partDocument = partDocument;
        }

        public override void Save(string path)
        {
            base.Save(path);

            path = $"{path}\\Нажимная гайка исполнения 2.m3d";
            _partDocument.SaveAs(path);
        }

        public override bool Create()
        {
            _nutPart = _partDocument.TopPart;

            IHatchParam hatchParam = _nutPart.HatchParam;
            hatchParam.Style = (int)ksHatchStyleEnum.ksHatchNonMetal;

            ISketch sketch1 = AddSketch1();
            IExtrusion sketch1Extrusion = ExtrudeSketch1(sketch1);

            ISketch sketch2 = AddSketch2();
            IExtrusion sketch2Extrusion = ExtrudeSketch2(sketch2);

            ISketch sketch3 = AddSketch3();
            IExtrusion sketch3Extrusion = ExtrudeSketch3(sketch3);

            ISketch sketch4 = AddSketch4();
            ICutExtrusion cutSketch4 = CutSketch4(sketch4);

            IThread thread = AddThread();
            IChamfer chamfer = AddChamfer();

            _nutPart.Update();

            return base.Create();
        }

        private ISketch AddSketch1()
        {
            ISketch sketch = (_nutPart as IModelContainer).Sketchs.Add();
            sketch.Plane = _nutPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];

            sketch.Update();

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            IRegularPolygon hexagon = drawingContainer.RegularPolygons.Add();
            hexagon.Xc = 0;
            hexagon.Yc = 0;
            hexagon.Count = 6;
            hexagon.Radius = partModel.WidthAcrossCorners / 2;
            hexagon.Update();

            sketch.EndEdit();

            return sketch;
        }

        private IExtrusion ExtrudeSketch1(ISketch sketch)
        {
            IExtrusion extrusion = (_nutPart as IModelContainer).Extrusions.Add(ksObj3dTypeEnum.o3d_baseExtrusion);
            extrusion.Sketch = (Sketch)sketch;
            extrusion.Depth[true] = partModel.HexagonHeight;
            extrusion.Direction = ksDirectionTypeEnum.dtNormal;
            extrusion.Update();

            return extrusion;
        }

        private ISketch AddSketch2()
        {
            IModelContainer modelContainer = (_nutPart as IModelContainer);

            ISketch sketch = modelContainer.Sketchs.Add();

            IPlane3DByOffset offsetPlane = (IPlane3DByOffset)modelContainer.AddObject(ksObj3dTypeEnum.o3d_planeOffset);
            offsetPlane.Offset = partModel.HexagonHeight;
            offsetPlane.BasePlane = _nutPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];
            offsetPlane.Update();

            sketch.Plane = offsetPlane;
            sketch.Update();

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Xc = 0;
            circle.Yc = 0;
            circle.Radius = partModel.LeftCylinderDiameter / 2;

            circle.Update();

            sketch.EndEdit();

            return sketch;
        }

        private IExtrusion ExtrudeSketch2(ISketch sketch)
        {
            IExtrusion extrusion = (_nutPart as IModelContainer).Extrusions.Add(ksObj3dTypeEnum.o3d_baseExtrusion);
            extrusion.Sketch = (Sketch)sketch;
            extrusion.Depth[true] = partModel.LeftCylinderLength;
            extrusion.Direction = ksDirectionTypeEnum.dtNormal;
            extrusion.Update();

            return extrusion;
        }

        private ISketch AddSketch3()
        {
            IModelContainer modelContainer = (_nutPart as IModelContainer);

            ISketch sketch = modelContainer.Sketchs.Add();


            IPlane3DByOffset offsetPlane = (IPlane3DByOffset)modelContainer.AddObject(ksObj3dTypeEnum.o3d_planeOffset);
            offsetPlane.Offset = partModel.HexagonHeight + partModel.LeftCylinderLength;
            offsetPlane.BasePlane = _nutPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];
            offsetPlane.Update();

            sketch.Plane = offsetPlane;
            sketch.Update();


            sketch.Update();

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Xc = 0;
            circle.Yc = 0;
            circle.Radius = partModel.RightCylinderDiameter / 2;

            circle.Update();

            sketch.EndEdit();


            return sketch;
        }

        private IExtrusion ExtrudeSketch3(ISketch sketch)
        {
            IExtrusion extrusion = (_nutPart as IModelContainer).Extrusions.Add(ksObj3dTypeEnum.o3d_baseExtrusion);
            extrusion.Sketch = (Sketch)sketch;
            extrusion.Depth[true] = partModel.Length - partModel.HexagonHeight - partModel.LeftCylinderLength;
            extrusion.Direction = ksDirectionTypeEnum.dtNormal;
            extrusion.Update();

            return extrusion;
        }

        private ISketch AddSketch4()
        {
            ISketch sketch = (_nutPart as IModelContainer).Sketchs.Add();
            sketch.Plane = _nutPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];

            sketch.Update();

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Xc = 0;
            circle.Yc = 0;
            circle.Radius = partModel.NominalShaftDiameter / 2;
            circle.Update();

            sketch.EndEdit();

            return sketch;
        }

        private ICutExtrusion CutSketch4(ISketch sketch)
        {
            IModelContainer modelContainer = (_nutPart as IModelContainer);

            ICutExtrusion cutExtrusion = (ICutExtrusion)modelContainer.Extrusions.Add(ksObj3dTypeEnum.o3d_cutExtrusion);
            cutExtrusion.Sketch = (Sketch)sketch;
            cutExtrusion.ExtrusionType[false] = ksEndTypeEnum.etThroughAll;

            cutExtrusion.Update();

            return cutExtrusion;
        }

        private IThread AddThread()
        {
            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");

            IModelContainer modelContainer = (_nutPart as IModelContainer);

            IThread thread = (IThread)modelContainer.AddObject(ksObj3dTypeEnum.o3d_thread);

            foreach (var edgeObj in modelContainer.Objects[Obj3dType.o3d_edge])
            {
                IEdge edge = (IEdge)edgeObj;

                edge.GetPoint(true, out double x, out double y, out double z);

                if (z == partModel.HexagonHeight + partModel.LeftCylinderLength && x == partModel.LeftCylinderDiameter / 2)
                {
                    thread.BaseObject = edge;
                    thread.Lenght = partModel.ThreadLength;

                    IThreadsParameters threadsParameters = (IThreadsParameters)thread;
                    threadsParameters.Diameter = partModel.Thread.NominalDiameter;
                    threadsParameters.Pitch = partModel.Thread.Pitch;
                }
            }

            thread.Update();

            return thread;
        }

        private IChamfer AddChamfer()
        {
            IModelContainer modelContainer = (_nutPart as IModelContainer);

            IChamfer chamfer = modelContainer.Chamfers.Add();

            foreach (var obj in modelContainer.Objects[Obj3dType.o3d_edge])
            {
                if (obj is IEdge edge && edge.IsCircle)
                {
                    edge.GetPoint(true, out double x, out double y, out double z);

                    if (z == 0)
                    {
                        chamfer.BaseObjects = edge;

                        break;
                    }
                }
            }

            chamfer.Distance1 = partModel.ChamferLength;
            chamfer.Angle = 45;
            chamfer.Update();

            return chamfer;
        }
    }
}
