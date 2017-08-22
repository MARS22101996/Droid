using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VTSClient.DAL.Enums;
using VTSClient.Droid.Infrastracture;

namespace VTSClient.Droid.Fragments
{
    public class VacationTypeFragment : Android.Support.V4.App.Fragment
    {
        private ImageView _image;
        private TextView _typeName;

        private readonly VacationType _type;

        [Register(".ctor", "()V", "")]
        public VacationTypeFragment():base() { }

        public VacationTypeFragment(string type)
        {
            _type = (VacationType) Enum.Parse(typeof(VacationType), type);
        }
    
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {         
            var view = inflater.Inflate(Resource.Layout.TypeRow, container, false);

            _image = view.FindViewById<ImageView>(Resource.Id.imageView1);

            _image.SetImageResource(VacationTypeSetting.GetPicture(_type));

            _typeName = view.FindViewById<TextView>(Resource.Id.textView1);

            _typeName.Text = _type.ToString();
           
            return view;
        }
    }
}