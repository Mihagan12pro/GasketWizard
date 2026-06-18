using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;

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
            //extrusion.Depth[true] = 

            return extrusion;
        }
    }
}
