using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace project
{
    public class CustomerFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_tab, null);
            //view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.customers_tab_label);
            //view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.ic_launcher);
            return view;
        }
    }

    public class RestaurentFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_tab, null);
            //view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.restaurents_tab_label);
            //view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.ic_launcher);
            return view;
        }
    }

}