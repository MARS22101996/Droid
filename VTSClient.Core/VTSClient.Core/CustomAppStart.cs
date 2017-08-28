using MvvmCross.Core.ViewModels;
using VTSClient.Core.ViewModels;

namespace VTSClient.Core
{
	public class CustomAppStart
		: MvxNavigatingObject
		, IMvxAppStart
	{
		public void Start(object hint = null)
		{
			//ShowViewModel<DetailViewModel>();
			//ShowViewModel<LoginPageViewModel>();
			//ShowViewModel<VacationViewModel>();
			ShowViewModel<MenuViewModel>();
		}
	}
}
