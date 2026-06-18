using GasketWizard.Creators.Shims.Part;
using GasketWizard.Domain.Shims;
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
            Type comType = Type.GetTypeFromProgID("KOMPAS.Application.7");

            IApplication kompas = (IApplication)Activator.CreateInstance(comType);
            kompas.Visible = true;

            ShimPartCreator partCreator = new ShimPartCreator(_shim, (IPartDocument)kompas.Documents.Add(DocumentTypeEnum.ksDocumentPart));
            partCreator.Create();
        }
    }
}
