using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using KompasAPI7;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace GasketWizard.Creators.Nuts
{
    public class ClumpingNut1PartCreator : ClumpingNut1Creator
    {
        private readonly IPartDocument _partDocument;

        private IPart7 _nutPart;

        public ClumpingNut1PartCreator(ClumpingNut1 partModel, IPartDocument partDocument) : base(partModel)
        {
            _partDocument = partDocument;
        }

        public override bool Create()
        {
            _nutPart = _partDocument.TopPart;

            ISketch sketch1 = AddSketch1();
            IExtrusion sketch1Extrusion = ExtrudeSketch1(sketch1);

            ISketch sketch2 = AddSketch2();
            IExtrusion sketch2Extrusion = ExtrudeSketch2(sketch2);

            ISketch sketch3 = AddSketch3();
            IExtrusion sketch3Extrusion = ExtrudeSketch3(sketch3);

            ISketch sketch4 = AddSketch4();
            ICutExtrusion cutExtrusion = CutSketch4(sketch4);
            IThread thread = AddThread(cutExtrusion);

            //IHole3D hole = AddHole();
            IChamfer chamfer = AddChamfer();

            return true;
        }

        public override void Save(string path)
        {
            base.Save(path);

            _partDocument.SaveAs(path);
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
            circle.Radius = partModel.LessCylinderDiameter / 2;

            circle.Update();

            sketch.EndEdit();

            return sketch;
        }

        private IExtrusion ExtrudeSketch2(ISketch sketch)
        {
            IExtrusion extrusion = (_nutPart as IModelContainer).Extrusions.Add(ksObj3dTypeEnum.o3d_baseExtrusion);
            extrusion.Sketch = (Sketch)sketch;
            extrusion.Depth[true] = partModel.Length - partModel.HexagonHeight - partModel.ThreadLength;
            extrusion.Direction = ksDirectionTypeEnum.dtNormal;
            extrusion.Update();

            return extrusion;
        }

        private ISketch AddSketch3()
        {
            IModelContainer modelContainer = (_nutPart as IModelContainer);

            IPlane3DByOffset offsetPlane = (IPlane3DByOffset)modelContainer.AddObject(ksObj3dTypeEnum.o3d_planeOffset);
            offsetPlane.Offset = partModel.Length - partModel.ThreadLength;
            offsetPlane.BasePlane = _nutPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];
            offsetPlane.Update();

            ISketch sketch = modelContainer.Sketchs.Add();
            sketch.Plane = offsetPlane;

            sketch.Update();

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Xc = 0;
            circle.Yc = 0;
            circle.Radius = partModel.BigCylinderDiameter / 2;

            circle.Update();

            sketch.EndEdit();

            return sketch;
        }

        private IExtrusion ExtrudeSketch3(ISketch sketch)
        {
            IExtrusion extrusion = (_nutPart as IModelContainer).Extrusions.Add(ksObj3dTypeEnum.o3d_baseExtrusion);
            extrusion.Sketch = (Sketch)sketch;
            extrusion.Depth[true] = partModel.ThreadLength;
            extrusion.Direction = ksDirectionTypeEnum.dtNormal;
            extrusion.Update();

            return extrusion;
        }

        private IChamfer AddChamfer()
        {
            IModelContainer modelContainer = (_nutPart as IModelContainer);

            IChamfer chamfer = modelContainer.Chamfers.Add();

            foreach(var obj in modelContainer.Objects[Obj3dType.o3d_edge])
            {
                if (obj is IEdge edge && edge.IsCircle)
                {
                    edge.GetPoint(true, out double x, out double y, out double z);

                    if (z == partModel.Length)
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

        private ISketch AddSketch4()
        {
            IModelContainer modelContainer = (_nutPart as IModelContainer);

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

            IPlane3DByOffset offsetPlane = (IPlane3DByOffset)modelContainer.AddObject(ksObj3dTypeEnum.o3d_planeOffset);
            offsetPlane.Offset = partModel.Length;
            offsetPlane.BasePlane = _nutPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];
            offsetPlane.Update();


            ICutExtrusion cutExtrusion = (ICutExtrusion)modelContainer.Extrusions.Add(ksObj3dTypeEnum.o3d_cutExtrusion);
            cutExtrusion.Sketch = (Sketch)sketch;
            cutExtrusion.ExtrusionType[false] = ksEndTypeEnum.etThroughAll;

            cutExtrusion.Update();

            return cutExtrusion;
        }

        private IThread AddThread(IExtrusion extrusion)
        {
            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");

            IModelContainer modelContainer = (_nutPart as IModelContainer);

            IThread thread = (IThread)modelContainer.AddObject(ksObj3dTypeEnum.o3d_thread);

            foreach (var faceObj in modelContainer.Objects[Obj3dType.o3d_face])
            {
                if (faceObj is IFace face && face.Owner == (IFeature7)extrusion)
                {
                    foreach(var edgeObj in face.LimitingEdges)
                    {
                        if (edgeObj is IEdge edge)
                        {
                            edge.GetPoint(true, out double x, out double y, out double z);

                            if (z == partModel.Length)
                            {
                                thread.BaseObject = face;
                                thread.AutoLenght = true;

                                IThreadsParameters threadsParameters = (IThreadsParameters)thread;
                                threadsParameters.Diameter = partModel.Thread.NominalDiameter;
                                threadsParameters.Pitch = partModel.Thread.Pitch;

                                break;
                            }
                        }
                    }
                }
            }

            thread.Update();

            return thread;
        }
    }
}
