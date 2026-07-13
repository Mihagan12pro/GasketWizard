using GasketWizard.Domain.Sockets;
using Kompas6Constants3D;
using KompasAPI7;

namespace GasketWizard.Creators.Sockets.SKSO
{
    public class SKSOGasketSocketPartCreator
        : SKSOGasketSocketCreator
    {
        private readonly IPartDocument _partDocument;

        private IPart7 _socketPart;

        public SKSOGasketSocketPartCreator(SKSOGasketSocket partModel, IPartDocument partDocument)
            : base(partModel)
        {
            _partDocument = partDocument;
        }

        public override void Save(string path)
        {
            base.Save(path);

            path = $"{path}\\Гнездо сальника типа СКСО.m3d";
            _partDocument.SaveAs(path);
        }

        public override bool Create()
        {
            _socketPart = _partDocument.TopPart;

            ISketch sketch = AddSketch1();
            IExtrusion extrusion = ExtrudeSketch1(sketch);

            IChamfer chamfer = AddChamfer();
            IThread thread = AddThread();

            return base.Create();
        }


        private ISketch AddSketch1()
        {
            IModelContainer modelContainer = _socketPart as IModelContainer;

            ISketch sketch = modelContainer.Sketchs.Add();
            sketch.Plane = _socketPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Radius = partModel.Diameter / 2;
            circle.Xc = 0;
            circle.Yc = 0;
            circle.Update();

            ICircle circle2 = drawingContainer.Circles.Add();
            circle2.Radius = partModel.Thread.NominalDiameter / 2;
            circle2.Xc = 0;
            circle2.Yc = 0;
            circle2.Update();

            sketch.Update();

            return sketch;
        }

        private IExtrusion ExtrudeSketch1(ISketch sketch)
        {
            IModelContainer modelContainer = _socketPart as IModelContainer;

            IExtrusion extrusion = modelContainer.Extrusions.Add(ksObj3dTypeEnum.o3d_baseExtrusion);
            extrusion.Sketch = (Sketch)sketch;
            extrusion.Depth[true] = partModel.Length;
            extrusion.Direction = ksDirectionTypeEnum.dtMiddlePlane;

            extrusion.Update();

            return extrusion;
        }

        private IThread AddThread()
        {
            IModelContainer modelContainer = _socketPart as IModelContainer;

            IThread thread = (IThread)modelContainer.AddObject(ksObj3dTypeEnum.o3d_thread);

            foreach (var faceObj in modelContainer.Objects[Obj3dType.o3d_face])
            {
                if (faceObj is IFace face && face.Radius == partModel.Thread.NominalDiameter / 2)
                {
                    thread.BaseObject = face;
                    thread.AutoLenght = true;

                    IThreadsParameters threadsParameters = (IThreadsParameters)thread;
                    threadsParameters.Diameter = partModel.Thread.NominalDiameter;
                    threadsParameters.Pitch = partModel.Thread.Pitch;

                    thread.Update();

                    break;
                }
            }

            return thread;
        }

        private IChamfer AddChamfer()
        {
            IModelContainer modelContainer = (_socketPart as IModelContainer);

            IChamfer chamfer = modelContainer.Chamfers.Add();

            foreach (var obj in modelContainer.Objects[Obj3dType.o3d_edge])
            {
                if (obj is IEdge edge && edge.IsCircle)
                {
                    edge.GetPoint(true, out double x, out double y, out double z);

                    if (z == partModel.Length / 2 && x == partModel.Thread.NominalDiameter / 2)
                    {
                        chamfer.BaseObjects = edge;

                        break;
                    }
                }
            }

            chamfer.Distance1 = partModel.ChamferLength;
            chamfer.Angle = partModel.Angle;
            chamfer.Update();

            return chamfer;
        }
    }
}
