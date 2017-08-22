using System.Net;
using System.Net.Security;
using Android.Content;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Support.V7.AppCompat;
using VTSClient.Core;

namespace VTSClient.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
			ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => { return true; });
		}

		//protected override MvxAndroidBindingBuilder CreateBindingBuilder()
		//{
		//	return new CalligraphyMvxAndroidBindingBuilder();
		//}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			MvxAppCompatSetupHelper.FillTargetFactories(registry);
			base.FillTargetFactories(registry);
		}
	}
}