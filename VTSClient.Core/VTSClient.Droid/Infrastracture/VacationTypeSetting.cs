using Android.Support.V4.App;
using Android.Widget;
using VTSClient.DAL.Enums;

namespace VTSClient.Droid.Infrastracture
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

        public static int GetPicture(VacationType type)
        {
            switch (type)
            {
                case VacationType.Regular:
                    return Resource.Drawable.Icon_Request_Green;
                case VacationType.Exceptional:
                    return Resource.Drawable.Icon_Request_Gray;
                case VacationType.Sick:
                    return Resource.Drawable.Icon_Request_Plum;
                case VacationType.Overtime:
                    return Resource.Drawable.Icon_Request_Blue;
                default:
                    return Resource.Drawable.Icon_Request_Dark;
            }
        }

        public static int GetPosition(VacationType type)
        {
            switch (type)
            {
                case VacationType.Regular:
                    return 1;
                case VacationType.Sick:
                    return 2;
                case VacationType.Exceptional:
                    return 3;
                case VacationType.LeaveWithoutPay:
                    return 4;
                case VacationType.Overtime:
                    return 5;
                default:
                    return 0;
            }
        }

        public static VacationType GetType(int position)
        {
            switch (position)
            {
                case 0:
                    return VacationType.Undefined;
                case 1:
                    return VacationType.Regular;
                case 2:
                    return VacationType.Sick;
                case 3:
                    return VacationType.Exceptional;
                case 4:
                    return VacationType.LeaveWithoutPay;
                default:
                    return VacationType.Overtime;
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