using GasketWizard.Creators.Nuts;
using GasketWizard.Creators.Shims.Part;
using GasketWizard.Domain.Shims;
using GasketWizard.Domain.ValueObjects;
using Kompas6Constants;
using KompasAPI7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasketWizard.Tests.Parts
{
    [TestClass]
    public class ClumpingNut1Tests
    {
        private readonly ClumpingNut1 _clumpingNut1 = new ClumpingNut1()
        {
            NominalShaftDiameter = 9,

            WidthAcrossCorners = 21.9,

            WidthAcrosFlats = 19,

            Length = 17,

            Thread = new MetricThread("М16X1")
        };

        [TestMethod]
        public void TestCreating()
        {
            Type comType = Type.GetTypeFromProgID("KOMPAS.Application.7");

            IApplication kompas = (IApplication)Activator.CreateInstance(comType);
            kompas.Visible = true;

            var partCreator = new ClumpingNut1PartCreator(_clumpingNut1, (IPartDocument)kompas.Documents.Add(DocumentTypeEnum.ksDocumentPart));
            partCreator.Create();
        }
    }
}
