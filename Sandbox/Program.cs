using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SldWorks;
using SwConst;
using static System.Console;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            SldWorks.SldWorks swApp;
            ModelDoc2 swModel;
            AssemblyDoc swAsm;
            Component2 swComp;
            Feature swFeat;

            swApp = (SldWorks.SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            swModel = swApp.ActiveDoc;

            swAsm = (AssemblyDoc)swModel;

            string[] compNames = new string[]
            {
                @"C:\Users\RICARDO.000\Documents\_Projetos teste powerPDM\TORNO 2700 2008\53015012.sldprt",
                @"C:\Users\RICARDO.000\Documents\_Projetos teste powerPDM\TORNO 2700 2008\53015012.sldprt",
                @"C:\Users\RICARDO.000\Documents\_Projetos teste powerPDM\TORNO 2700 2008\53-104-43-006.SLDPRT",
                @"C:\Users\RICARDO.000\Documents\_Projetos teste powerPDM\TORNO 2700 2008\BRACO REGULADOR CONTRA-ROLO 2.SLDPRT",
                @"C:\Users\RICARDO.000\Documents\_Projetos teste powerPDM\TORNO 2700 2008\CUBO BRACO REGULADOR CONTRA-ROLO 2.SLDPRT",
                @"C:\Users\RICARDO.000\Documents\_Projetos teste powerPDM\TORNO 2700 2008\53-104-43-008.SLDPRT",
                @"C:\Users\RICARDO.000\Documents\_Projetos teste powerPDM\TORNO 2700 2008\teste4.SLDASM"
            };

            double[] compXforms = new double[16];
            string[] compCoordSysNames = new string[] { "", "", "", "", "", "", "" };
            object vcompNames;
            object vcompXforms;
            object vcompCoordSysNames;
            object vcomponents;


            //compNames[0] = @"C:\Users\RICARDO.000\Documents\_Projetos teste powerPDM\TORNO 2700 2008\53015012.sldprt";
            //compNames[1] = @"C:\Users\RICARDO.000\Documents\_Projetos teste powerPDM\TORNO 2700 2008\53015012.sldprt";

            // Define the transformation matrix. See the IMathTransform API documentation.
            // Add a rotational diagonal unit matrix (zero rotation) to the transform
            // x-axis components of rotation
            compXforms[0] = 1.0;
            compXforms[1] = 0.0;
            compXforms[2] = 0.0;
            // y-axis components of rotation
            compXforms[3] = 0.0;
            compXforms[4] = 1.0;
            compXforms[5] = 0.0;
            // z-axis components of rotation
            compXforms[6] = 0.0;
            compXforms[7] = 0.0;
            compXforms[8] = 1.0;

            // Add a translation vector to the transform (zero translation) 
            compXforms[9] = 0.0;
            compXforms[10] = 0.0;
            compXforms[11] = 0.0;

            // Add a scaling factor to the transform
            compXforms[12] = 0.0;

            // The last three elements in the transformation matrix are unused

            // Register the coordinate system name for the component 
            //compCoordSysNames[0] = "";
            //compCoordSysNames[1] = "";

            // Add the components to the assembly. 
            vcompNames = compNames;
            vcompXforms = compXforms;
            //vcompXforms = Nothing   //also achieves zero rotation and translation of the component
            vcompCoordSysNames = compNames; //compCoordSysNames;

            vcomponents = swAsm.AddComponents3((vcompNames), (null), (vcompCoordSysNames));

            ReadKey();
        }
    }
}
