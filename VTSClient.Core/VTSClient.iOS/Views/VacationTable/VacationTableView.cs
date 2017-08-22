using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS.Views.VacationTable
{
    public partial class VacationTableView : MvxViewController<VacationViewModel>
    {
        public VacationTableView() : base("VacationTableView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "All Requests";

			NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White };

			var source = new MvxSimpleTableViewSource(VacationTable, "VacationTableViewCell", VacationTableViewCell.Key);

			VacationTable.RowHeight = 50;

			var set = this.CreateBindingSet<VacationTableView, VacationViewModel>();

			set.Bind(source).To(vm => vm.Vacations);

			var addItem = new UIBarButtonItem(UIBarButtonSystemItem.Add) { Title = "New" };

			set.Bind(addItem).To(vm => vm.AddCommand);

			NavigationItem.RightBarButtonItem =  addItem;

			set.Apply();

			VacationTable.Source = source;

			VacationTable.ReloadData();
        }
    }
}
