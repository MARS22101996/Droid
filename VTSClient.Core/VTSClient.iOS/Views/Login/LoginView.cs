using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS.Views.Login
{
	public partial class LoginView : MvxViewController<LoginPageViewModel>
	{
		public LoginView() : base("LoginView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			NavigationController.NavigationBar.BarTintColor = new UIColor(red: 0.00f, green: 0.76f, blue: 1.00f,
				alpha: 1.0f);

			NavigationController.NavigationBar.TintColor = UIColor.White;

			ApplyBindings();
		}


		private void ApplyBindings()
		{
			var bindingSet = this.CreateBindingSet<LoginView, LoginPageViewModel>();

			bindingSet.Bind(LoginText)
				.For("Text")
				.To(vm => vm.LoginTextValue);

			bindingSet.Bind(PasswordText)
				.For("Text")
				.To(vm => vm.PasswordTextValue);

			bindingSet.Bind(ErrorText)
				.For("Text")
				.To(vm => vm.ErrorTextValue);

			bindingSet.Bind(ErrorText)
				.For("Hidden")
				.To(vm => vm.IsHidden);

			bindingSet.Bind(SigninButton)
				.To(vm => vm.SignInCommand);

			bindingSet.Apply();
		}
	}
}

