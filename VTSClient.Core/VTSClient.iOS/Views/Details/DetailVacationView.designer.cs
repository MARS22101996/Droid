// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views.Details
{
	[Register ("DetailVacationView")]
	partial class DetailVacationView
	{
		[Outlet]
		UIKit.UIToolbar DatePickerBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIToolbar DatePickerToolbar { get; set; }

		[Outlet]
		UIKit.UIDatePicker DatePickerVacation { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem DateToolBar { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem DoneButton { get; set; }

		[Outlet]
		UIKit.UIButton EndDay { get; set; }

		[Outlet]
		UIKit.UIButton EndMonth { get; set; }

		[Outlet]
		UIKit.UIButton EndYear { get; set; }

		[Outlet]
		UIKit.UIPageControl Page { get; set; }

		[Outlet]
		UIKit.UIImageView PageImage { get; set; }

		[Outlet]
		UIKit.UIButton StartDay { get; set; }

		[Outlet]
		UIKit.UIButton StartMonth { get; set; }

		[Outlet]
		UIKit.UIButton StartYear { get; set; }

		[Outlet]
		UIKit.UISegmentedControl StatusSegment { get; set; }

		[Outlet]
		UIKit.UIView TypeImageView { get; set; }

		[Outlet]
		UIKit.UILabel TypeText { get; set; }

		[Action ("ActionLeft:")]
		partial void ActionLeft (Foundation.NSObject sender);

		[Action ("ActionRight:")]
		partial void ActionRight (Foundation.NSObject sender);

		[Action ("CancelButtonChoose:")]
		partial void CancelButtonChoose (Foundation.NSObject sender);

		[Action ("DoneButtonChoose:")]
		partial void DoneButtonChoose (Foundation.NSObject sender);

		[Action ("UIButtonTLSZ9qY3_TouchUpInside:")]
		partial void UIButtonTLSZ9qY3_TouchUpInside (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (DatePickerBar != null) {
				DatePickerBar.Dispose ();
				DatePickerBar = null;
			}

			if (DatePickerVacation != null) {
				DatePickerVacation.Dispose ();
				DatePickerVacation = null;
			}

			if (DateToolBar != null) {
				DateToolBar.Dispose ();
				DateToolBar = null;
			}

			if (DoneButton != null) {
				DoneButton.Dispose ();
				DoneButton = null;
			}

			if (EndDay != null) {
				EndDay.Dispose ();
				EndDay = null;
			}

			if (EndMonth != null) {
				EndMonth.Dispose ();
				EndMonth = null;
			}

			if (EndYear != null) {
				EndYear.Dispose ();
				EndYear = null;
			}

			if (Page != null) {
				Page.Dispose ();
				Page = null;
			}

			if (PageImage != null) {
				PageImage.Dispose ();
				PageImage = null;
			}

			if (StartDay != null) {
				StartDay.Dispose ();
				StartDay = null;
			}

			if (StartMonth != null) {
				StartMonth.Dispose ();
				StartMonth = null;
			}

			if (StartYear != null) {
				StartYear.Dispose ();
				StartYear = null;
			}

			if (StatusSegment != null) {
				StatusSegment.Dispose ();
				StatusSegment = null;
			}

			if (TypeImageView != null) {
				TypeImageView.Dispose ();
				TypeImageView = null;
			}

			if (TypeText != null) {
				TypeText.Dispose ();
				TypeText = null;
			}

			if (DatePickerToolbar != null) {
				DatePickerToolbar.Dispose ();
				DatePickerToolbar = null;
			}
		}
	}
}
