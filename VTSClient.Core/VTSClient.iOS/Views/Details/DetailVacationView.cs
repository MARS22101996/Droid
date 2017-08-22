using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;
using VTSClient.DAL.Enums;
using VTSClient.iOS.Infrastructure;

namespace VTSClient.iOS.Views.Details
{
	public partial class DetailVacationView : MvxViewController<DetailViewModel>
	{

		public DetailVacationView() : base("DetailVacationView", null)
		{
		}

		public override  async void ViewDidLoad()
		{
			base.ViewDidLoad();

			SetNavigationBar();

            HideDatePicker();

			ApplyBindings();
		}

		private void SetNavigationBar()
		{
			NavigationItem.BackBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Action);
			NavigationItem.Title = "Request";
			NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White };
		}

		private void HideDatePicker()
		{
			DatePickerToolbar.Hidden = true;
			DatePickerVacation.Hidden = true;
		}
		
		partial void ActionRight(Foundation.NSObject sender)
		{
			Page.CurrentPage -= 1;
		}

		partial void ActionLeft(Foundation.NSObject sender)
		{
			Page.CurrentPage += 1;
		}

		private void ApplyBindings()
		{
			var bindingSet = this.CreateBindingSet<DetailVacationView, DetailViewModel>();

			var saveItem = new UIBarButtonItem(UIBarButtonSystemItem.Save);

			bindingSet.Bind(saveItem).
				To(vm => vm.SaveCommand);

			NavigationItem.RightBarButtonItem = saveItem;

			bindingSet.Bind(StartDay)
			   .For("Title")
			   .To(vm => vm.StartDay);

			bindingSet.Bind(StartMonth)
			   .For("Title")
			   .To(vm => vm.StartMonth);

			bindingSet.Bind(StartYear)
			  .For("Title")
			  .To(vm => vm.StartYear);

			bindingSet.Bind(EndDay)
			  .For("Title")
			  .To(vm => vm.EndDay);

			bindingSet.Bind(EndMonth)
			  .For("Title")
			  .To(vm => vm.EndMonth);

			bindingSet.Bind(EndYear)
			  .For("Title")
			   .To(vm => vm.EndYear);

			bindingSet.Bind(StatusSegment)
			  .For("SelectedSegment")
			   .To(vm => vm.StatusButtonSelectedSegment)
			   .WithConversion("StatusToNumber");

			bindingSet.Bind(TypeText)
				.For("Text")
				.To(vm => vm.TypeText);

			bindingSet.Bind(Page)
				.For("CurrentPage")
				.To(vm => vm.Page);

			bindingSet.Bind(StatusSegment)
			   .For("ValueChanged")
			   .To(vm => vm.ChangeStatusCommand);

			bindingSet.Bind(DoneButton)
		       .To(vm => vm.DoneCommand);

			bindingSet.Bind(DateToolBar)
                .To(vm => vm.CancelCommand);

			bindingSet.Bind(DatePickerVacation)
			   .For("Hidden")
			   .To(vm => vm.IsDatePickerVacation);

			bindingSet.Bind(DatePickerBar)
			   .For("Hidden")
			   .To(vm => vm.IsDatePickerToolbar);

			bindingSet.Bind(DatePickerVacation)
				.For("Date")
				.To(vm => vm.DatePickerVacationDate);

			bindingSet.Bind(StartDay)
				  .To(vm => vm.StartDateCommand);

			bindingSet.Bind(StartMonth)
				.To(vm => vm.StartDateCommand);
			
			bindingSet.Bind(StartYear)
				.To(vm => vm.StartDateCommand);

			bindingSet.Bind(EndDay)
				  .To(vm => vm.EndDateCommand);

			bindingSet.Bind(EndMonth)
				.To(vm => vm.EndDateCommand);

			bindingSet.Bind(EndYear)
				.To(vm => vm.EndDateCommand);

			bindingSet.Bind(Page)
			   .For("ValueChanged")
			   .To(vm => vm.SwipeEventCommand);
            
			bindingSet.Apply();

			var numPage = (int) Page.CurrentPage;

			var vacationType = (VacationType) numPage;

			PageImage.Image = VacationTypeSetting.GetPicture(vacationType.ToString());
		}
	}
}

