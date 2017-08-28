using Android.Support.V4.App;
using Android.Widget;
using VTSClient.DAL.Enums;

namespace VTSClient.Droid.Settings
{
    public static class VacationTypeSetting
    {
		private static int[] _buttons =
		{
			Resource.Id.buttonInd1,
			Resource.Id.buttonInd2,
			Resource.Id.buttonInd3,
			Resource.Id.buttonInd4,
			Resource.Id.buttonInd5,
			Resource.Id.buttonInd6
		};

		public static int GetPicture(string type)
        {
            switch (type)
            {
                case "Regular":
                    return Resource.Drawable.Icon_Request_Green;
                case "Exceptional":
                    return Resource.Drawable.Icon_Request_Gray;
                case"Sick":
                    return Resource.Drawable.Icon_Request_Plum;
                case "Overtime":
                    return Resource.Drawable.Icon_Request_Blue;
                default:
                    return Resource.Drawable.Icon_Request_Dark;
            }
        }

		public static void SetButtonsColor(FragmentActivity context, int id)
		{
			foreach (var item in _buttons)
			{
				var element = context.FindViewById<ImageView>(item);
				element.SetBackgroundResource(Resource.Drawable.uncheckedButton);
			}

			var indexer = context.FindViewById<ImageView>(_buttons[id]);
			indexer.SetBackgroundResource(Resource.Drawable.checkedButton);
		}
	}
}