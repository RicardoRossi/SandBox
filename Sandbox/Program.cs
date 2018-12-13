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

            Object[] compcomponentes = swAsm.GetComponents(false);

            var totalComp = compcomponentes.Length;
            var listaNomesComInstancias =new List<string>();

            foreach (var comp in compcomponentes)
            {
                swComp = (Component2)comp;
                listaNomesComInstancias.Add(swComp.Name2);                
            }

            foreach (var nome in listaNomesComInstancias)
            {
                Component2 compRet = swAsm.GetComponentByName(nome);
                swFeat = compRet.FeatureByName("cs_1");
                if (swFeat!=null)
                {
                    swFeat.Select(true);


                }
                //compRet.Select(false);
            }
            ReadKey();
        }
    }
}
