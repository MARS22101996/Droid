using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS.Views.Menu
{
    public partial class MenuTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MenuTableViewCell");

	    private static readonly UINib Nib;

        static MenuTableViewCell()
        {
            Nib = UINib.FromName("MenuTableViewCell", NSBundle.MainBundle);
        }

        protected MenuTableViewCell(IntPtr handle) : base(handle)
        {
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<MenuTableViewCell, SectionViewModel>();

				set.Bind(GoToVacations)
                   .For("Title")
			       .To(vm => vm.NameStatus);

				set.Bind(GoToVacations)
                   .To(vm => vm.GoToVacationsCommand);

				set.Apply();
			});
        }
    }
}
