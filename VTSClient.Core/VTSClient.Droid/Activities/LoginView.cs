using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;
using VTSClient.Core.ViewModels;

namespace VTSClient.Droid.Activities
{
	[Activity(Label = "View for FirstViewModel", Theme = "@style/MyTheme.Login")]
	public class LoginView : MvxActivity<LoginPageViewModel>
	{
		private Button _buttonSignIn;

		private TextView _login, _password, _error;

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();

			SetContentView(Resource.Layout.LoginView);

			_buttonSignIn = FindViewById<Button>(Resource.Id.buttonSignIn);

			_login = FindViewById<TextView>(Resource.Id.login);

			_password = FindViewById<TextView>(Resource.Id.password);

			_error = FindViewById<TextView>(Resource.Id.errorText);

			ApplyBindings();
		}

		private void ApplyBindings()
		{
			var bindingSet = this.CreateBindingSet<LoginView, LoginPageViewModel>();

			bindingSet.Bind(_login)
				.For("Text")
				.To(vm => vm.LoginTextValue);

			bindingSet.Bind(_password)
				.For("Text")
				.To(vm => vm.PasswordTextValue);

			bindingSet.Bind(_error)
				.For("Text")
				.To(vm => vm.ErrorTextValue);

			bindingSet.Bind(_error)
				.For("Hidden")
				.To(vm => vm.IsHidden);

			bindingSet.Bind(_buttonSignIn)
				.To(vm => vm.SignInCommand);

			bindingSet.Apply();
		}
	}
}