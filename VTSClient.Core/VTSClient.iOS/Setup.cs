﻿using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using UIKit;
using VTSClient.Core;

namespace VTSClient.iOS
{
	public class Setup : MvxIosSetup
    {
		public Setup(MvxApplicationDelegate appDelegate, UIWindow window)
			: base(appDelegate, window)
		{
		}

		public Setup(MvxApplicationDelegate appDelegate, IMvxIosViewPresenter presenter) : base(appDelegate, presenter)
		{
		}

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}
