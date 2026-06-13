using GasketWizard.Domain.Shims;
using Kompas6Constants3D;
using KompasAPI7;

namespace GasketWizard.Creators.Shims.Part
{
    public class ShimPartCreator : ShimCreator
    {
        private IPartDocument _document;

        private IPart7 _shimPart;

        private IExtrusion ExtrudeSketch1(Sketch sketch)
        {
            IExtrusion extrusion = (_shimPart as IModelContainer).Extrusions.Add(ksObj3dTypeEnum.o3d_baseExtrusion);

            extrusion.ExtrusionType[true] = ksEndTypeEnum.etBlind;
            extrusion.Direction = ksDirectionTypeEnum.dtMiddlePlane;
            extrusion.Sketch = sketch;
            extrusion.Depth[true] = partModel.Width;

            extrusion.Update();

            return extrusion;
        }

        private ISketch AddSketch1()
        {
            ISketch sketch = (_shimPart as IModelContainer).Sketchs.Add();
            sketch.Plane = _shimPart.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];

            sketch.Update();

            IKompasDocument2D document2d = sketch.BeginEdit();

            IViewsAndLayersManager viewsAndLayersManager = document2d.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle internalCircle = drawingContainer.Circles.Add();
            internalCircle.Xc = 0;
            internalCircle.Yc = 0;
            internalCircle.Radius = partModel.InternalDiameter / 2;
            internalCircle.Update();

            ICircle externalCircle = drawingContainer.Circles.Add();
            externalCircle.Xc = 0;
            externalCircle.Yc = 0;
            externalCircle.Radius = partModel.ExternalDiameter / 2;
            externalCircle.Update();

            sketch.EndEdit();

            return sketch;
        }

        public override bool Create()
        {
            base.Create();  

            _shimPart = _document.TopPart;

            ISketch sketch1 = AddSketch1();
            IExtrusion sketch1Extrusion = ExtrudeSketch1((Sketch)sketch1);

            return true;
        }

        public override void Save(string path)
        {
            base.Save(path);

            path = $"{path}\\Шайба.m3d";
            _document.SaveAs(path);
        }

        public ShimPartCreator(Shim shim, IKompasDocument document) : base(shim, document)
        {
            _document = (IPartDocument)document;
        }
    }
}
