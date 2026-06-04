using GasketWizard.Domain.Shims;
using KompasAPI7;
using System;

namespace GasketWizard.Creators.Shims.Part
{
    public class ShimPartCreator : IShimCreator
    {
        private string _path;

        private IPartDocument _document;

        private IPart7 _shimPart;

        public bool Create(Shim partModel)
        {
            _shimPart = _document.TopPart;


            return true;
        }

        public string GetGilePath()
            => _path;

        public void Save(string path)
        {
            _path = path;
        }

        internal ShimPartCreator(IPartDocument document)
        {
            _document = document;
        }
    }
}
