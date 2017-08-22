// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views.VacationTable
{
    [Register ("VacationTableView")]
    partial class VacationTableView
    {
        [Outlet]
        UIKit.UITableView VacationTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (VacationTable != null) {
                VacationTable.Dispose ();
                VacationTable = null;
            }
        }
    }
}