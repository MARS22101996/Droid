// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views.Menu
{
    [Register ("MenuView")]
    partial class MenuView
    {
        [Outlet]
        UIKit.UITableView SectionTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (SectionTable != null) {
                SectionTable.Dispose ();
                SectionTable = null;
            }
        }
    }
}