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
    [Register ("MenuTableViewCell")]
    partial class MenuTableViewCell
    {
        [Outlet]
        UIKit.UIButton GoToVacations { get; set; }


        [Outlet]
        UIKit.UIView TypeCell { get; set; }


        [Outlet]
        UIKit.UILabel TypeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (GoToVacations != null) {
                GoToVacations.Dispose ();
                GoToVacations = null;
            }
        }
    }
}