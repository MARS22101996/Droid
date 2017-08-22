using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using VTSClient.Core.Models;
using VTSClient.iOS.Infrastructure;

namespace VTSClient.iOS.Views.VacationTable
{
    public partial class VacationTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("VacationTableViewCell");

        public static readonly UINib Nib;

		static VacationTableViewCell()
        {
            Nib = UINib.FromName("VacationTableViewCell", NSBundle.MainBundle);
        }

        protected VacationTableViewCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{   
                var set = this.CreateBindingSet<VacationTableViewCell, VacationCoreModel>();
               
				set.Bind(Date).To(m => m.Period);

				set.Bind(Status).To(m => m.VacationStatus);

				set.Bind(Type).To(m => m.VacationType);

				set.Bind(DetailButton).To(m => m.DetailCommand);

				set.Apply();

				var typePicture = Type.Text;

				VacationPicture.Image = VacationTypeSetting.GetPicture(typePicture);
			});
        }		
    }
}
