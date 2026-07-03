using GasketWizard.Domain.Sockets;
using Kompas6Constants3D;
using KompasAPI7;
using System;

namespace GasketWizard.Creators.Sockets
{
    public class SKROGasketSocketPartCreator : SKROGasketSocketCreator
    {
        private readonly IPartDocument _partDocument;

        private IPart7 _socketPart;

        public override bool Create()
        {
            _socketPart = _partDocument.TopPart;

            ISketch sketch1 = AddSketch1();
            IExtrusion extrudeSketch1 = ExtrudeSketch1(sketch1);

            ISketch sketch2 = AddSketch2();
            ICutExtrusion cutExtrusion = CutSketch2(sketch2);

            ISketch sketch3 = AddSketch3();
            IExtrusion extrudeSketch2 = ExtrudeSketch3(sketch3);

            ISketch sketch4 = AddSketch4();
            ICutExtrusion cutSketch4 = CutSketch4(sketch4);

            IThread thread = AddThread(cutExtrusion);

            return true;
        }

        public override void Save(string path)
        {
            base.Save(path);

            path = $"{path}\\Гнездо сальника типа СКРО.m3d";
            _partDocument.SaveAs(path);
        }

        public SKROGasketSocketPartCreator(SKROGasketSocket partModel, IPartDocument partDocument) : base(partModel)
        {
            _partDocument = partDocument;
        }

        private ISketch AddSketch1()
        {
            IModelContainer modelContainer = (IModelContainer)_socketPart;

            ISketch sketch = modelContainer.Sketchs.Add();
            sketch.Plane = _socketPart.DefaultObject[Kompas6Constants3D.ksObj3dTypeEnum.o3d_planeXOY];

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Radius = partModel.BigCylinderOutsideDiameter / 2;
            circle.Xc = 0;
            circle.Yc = 0;
            circle.Update();

            sketch.Update();

            return sketch;
        }

        private IExtrusion ExtrudeSketch1(ISketch sketch)
        {
            IModelContainer modelContainer = (IModelContainer)_socketPart;

            IExtrusion extrusion = modelContainer.Extrusions.Add(ksObj3dTypeEnum.o3d_baseExtrusion);
            extrusion.Sketch = (Sketch)sketch;
            extrusion.Depth[true] = partModel.BigCylinderLength;
            extrusion.Update();

            return extrusion;
        }


        private ISketch AddSketch2()
        {
            IModelContainer modelContainer = (IModelContainer)_socketPart;

            IPlane3DByOffset planeOffset = (IPlane3DByOffset)modelContainer.AddObject(ksObj3dTypeEnum.o3d_planeOffset);
            planeOffset.BasePlane = _socketPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];
            planeOffset.Offset = partModel.BigCylinderLength;
            planeOffset.Update();

            ISketch sketch = modelContainer.Sketchs.Add();
            sketch.Plane = planeOffset;
            sketch.Update();

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Radius = partModel.BigHoleDiameter / 2;
            circle.Xc = 0;
            circle.Yc = 0;
            circle.Update();

            sketch.EndEdit();

            return sketch;
        }

        private ICutExtrusion CutSketch2(ISketch sketch)
        {
            IModelContainer modelContainer = (IModelContainer)_socketPart;

            ICutExtrusion cutExtrusion = (ICutExtrusion)modelContainer.Extrusions.Add(ksObj3dTypeEnum.o3d_cutExtrusion);
            cutExtrusion.Sketch = (Sketch)sketch;
            cutExtrusion.Direction = ksDirectionTypeEnum.dtNormal;
            cutExtrusion.Depth[true] = partModel.BigHoleLength;
            cutExtrusion.Update();

            return cutExtrusion;
        }

        private ISketch AddSketch3()
        {
            IModelContainer modelContainer = (IModelContainer)_socketPart;

            ISketch sketch = modelContainer.Sketchs.Add();
            sketch.Plane = _socketPart.DefaultObject[Kompas6Constants3D.ksObj3dTypeEnum.o3d_planeXOY];

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Radius = partModel.SmallCylinderOutsideDiameter / 2;
            circle.Xc = 0;
            circle.Yc = 0;
            circle.Update();

            sketch.Update();

            return sketch;
        }

        private IExtrusion ExtrudeSketch3(ISketch sketch)
        {
            IModelContainer modelContainer = (IModelContainer)_socketPart;

            IExtrusion extrusion = modelContainer.Extrusions.Add(ksObj3dTypeEnum.o3d_baseExtrusion);
            extrusion.Sketch = (Sketch)sketch;
            extrusion.Direction = ksDirectionTypeEnum.dtReverse;
            extrusion.Depth[false] = partModel.Length - partModel.BigCylinderLength;
            extrusion.Update();

            return extrusion;
        }

        private ISketch AddSketch4()
        {
            IModelContainer modelContainer = (IModelContainer)_socketPart;

            IPlane3DByOffset planeOffset = (IPlane3DByOffset)modelContainer.AddObject(ksObj3dTypeEnum.o3d_planeOffset);
            planeOffset.BasePlane = _socketPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];
            planeOffset.Offset = -(partModel.Length - partModel.BigCylinderLength);
            planeOffset.Update();

            ISketch sketch = modelContainer.Sketchs.Add();
            sketch.Plane = planeOffset;

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Radius = partModel.SmallCylinderInsideDiameter / 2;
            circle.Xc = 0;
            circle.Yc = 0;
            circle.Update();

            sketch.Update();

            return sketch;
        }

        private ICutExtrusion CutSketch4(ISketch sketch)
        {
            IModelContainer modelContainer = (IModelContainer)_socketPart;

            ICutExtrusion cutExtrusion = (ICutExtrusion)modelContainer.Extrusions.Add(ksObj3dTypeEnum.o3d_cutExtrusion);
            cutExtrusion.Sketch = (Sketch)sketch;
            cutExtrusion.Direction = ksDirectionTypeEnum.dtMiddlePlane;
            cutExtrusion.ExtrusionType[true] = ksEndTypeEnum.etThroughAll;
            cutExtrusion.Update();

            return cutExtrusion;
        }

        private IThread AddThread(ICutExtrusion cutExtrusion)
        {
            IModelContainer modelContainer = (IModelContainer)_socketPart;

            IThread thread = (IThread)modelContainer.AddObject(ksObj3dTypeEnum.o3d_thread);

            foreach(var faceObj in modelContainer.Objects[Obj3dType.o3d_face])
            {
                if (faceObj is IFace face && face.Owner == cutExtrusion)
                {
                    foreach(var edgeObj in  face.LimitingEdges)
                    {
                        IEdge edge = (IEdge)edgeObj;

                        edge.GetPoint(true, out double x, out double y, out double z);

                        if (z == partModel.BigCylinderLength)
                        {
                            thread.Lenght = partModel.ThreadLength;
                            thread.BaseObject = edge;

                            IThreadsParameters threadsParameters = (IThreadsParameters)thread;
                            threadsParameters.Diameter = partModel.Thread.NominalDiameter;
                            threadsParameters.Pitch = partModel.Thread.Pitch;

                            thread.Update();

                            break;
                        }
                    }
                }
            }

            return thread;
        }
    }
}
