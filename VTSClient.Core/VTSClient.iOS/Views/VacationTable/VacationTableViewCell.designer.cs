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
    [Register ("VacationTableViewCell")]
    partial class VacationTableViewCell
    {
        [Outlet]
        UIKit.UILabel Date { get; set; }


        [Outlet]
        UIKit.UITextView Status { get; set; }


        [Outlet]
        UIKit.UILabel Type { get; set; }


        [Outlet]
        UIKit.UIImageView VacationPicture { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DetailButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Date != null) {
                Date.Dispose ();
                Date = null;
            }

            if (DetailButton != null) {
                DetailButton.Dispose ();
                DetailButton = null;
            }

            if (Status != null) {
                Status.Dispose ();
                Status = null;
            }

            if (Type != null) {
                Type.Dispose ();
                Type = null;
            }

            if (VacationPicture != null) {
                VacationPicture.Dispose ();
                VacationPicture = null;
            }
        }
    }
}