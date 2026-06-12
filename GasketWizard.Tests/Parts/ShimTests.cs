using GasketWizard.Creators.Shims.Part;
using GasketWizard.Domain.Shims;
using GasketWizard.Factory;
using Kompas6Constants;
using KompasAPI7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GasketWizard.Tests.Parts
{
    /// <summary>
    /// Requires running kompas app
    /// </summary>
    [TestClass]
    public class ShimTests
    {
        private Shim _shim = new Shim()
        {
            InternalDiameter = 20,

            ExternalDiameter = 22,

            Width = 2
        };

        [TestMethod]
        public void TestCreating()
        {
            Guid guid = Guid.NewGuid();

            Type comType = Type.GetTypeFromProgID("KOMPAS.Application.7");

            IApplication kompas = (IApplication)Activator.CreateInstance(comType);
            kompas.Visible = true;

            ShimsFactory shimsFactory = new ShimsFactory();
            ShimPartCreator partCreator = shimsFactory.CreateShimPart((IPartDocument)kompas.Documents.Add(DocumentTypeEnum.ksDocumentPart));
            partCreator.Create(_shim);
        }
    }
}
