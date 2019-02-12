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
                       
            // Add the components to the assembly. 
            vcompNames = compNames;
            vcompXforms = compXforms;
            //vcompXforms = Nothing   //also achieves zero rotation and translation of the component
            vcompCoordSysNames = compNames; //compCoordSysNames;

            vcomponents = swAsm.AddComponents3((vcompNames), (null), (vcompCoordSysNames));

            var pecas = (Component2[])vcomponents;

            ReadKey();
        }
    }
}
