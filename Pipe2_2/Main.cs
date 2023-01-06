using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Задание 2.2 Количество труб на активном виде

namespace Pipe2_2
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var fInstances = new FilteredElementCollector(doc, doc.ActiveView.Id)
                           .OfClass(typeof(Pipe))
                           .Cast<Pipe>()
                           .ToList();

            TaskDialog.Show("Pipes count", fInstances.Count.ToString());
            return Result.Succeeded;
        }
    }
}