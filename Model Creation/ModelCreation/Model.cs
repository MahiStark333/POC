using NativeGeomHelper;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelCreation
{
    public class Model : NativeGeomHelper.DxHPart
    {
        public double width { get; set; }
        public double height { get; set; }
        public double breadth { get; set; }
        public string mailId { get; set; }
        public string path { get; set; }
        public DrawHelper DrawHelper { get; set; }
        public Model()
        {
            mailId = "maheswaran@gmail.com";
            Name = "Job";
            width = 0.050;
            height = 0.030;
            breadth = 0.060;
            ModelDoc = AppHandle.CreateNewDocument(swDocumentTypes_e.swDocPART);
            PartHelper = new PartHelper(ModelDoc);
            ExecutionCounter executionCounter = new ExecutionCounter();
            path = executionCounter.Counter();
        }

        public override void CreateModel()
        {

            PartHelper.CreateSketch(DefaultPlanes.Top);
            PartHelper.SketchMgr.CreateCenterRectangle(0, 0, 0, breadth / 2, width / 2, 0);
            string sketch = PartHelper.ExitSketch();

            PartHelper.CreateExtrude(sketch, true, false, height);

            PartHelper.ClearSelection();
            PartHelper.ModelDoc.ViewZoomtofit2();

            AppHandle.SaveCurrentDoc(Path.Combine(path, Name + ".SLDPRT"));


        }
    }
}
