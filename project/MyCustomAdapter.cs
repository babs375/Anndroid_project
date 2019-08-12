using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace project
{
    //class MyCustomAdapter : BaseAdapter<ItemObject>
    //{
    //    List<ItemObject> itemList;
    //    Activity mycontext;

    //    public MyCustomAdapter(Activity contex, List<ItemObject> itemArray)
    //    {
    //        itemList = itemArray;
    //        mycontext = contex;
    //    }

    //    public override ItemObject this[int position]
    //    {

    //        get { return itemList[position]; }
    //    }

    //    public override int Count
    //    {
    //        get
    //        {
    //            return itemList.Count;
    //        }
    //    }

    //    public override long GetItemId(int position)
    //    {
    //        return position;
    //    }


    //    public override View GetView(int position, View convertView, ViewGroup parent)
    //    {
    //        View myView = convertView;
    //        ItemObject myObj = itemList[position];

    //        if (myView == null)
    //        {
    //            myView = mycontext.LayoutInflater.Inflate(Resource.Layout.CellLayout, null);
    //        }

    //        myView.FindViewById<TextView>(Resource.Id.itemName).Text = myObj.itemName;
    //        myView.FindViewById<TextView>(Resource.Id.itemPrice).Text = myObj.itemPrice.ToString();
    //        myView.FindViewById<ImageView>(Resource.Id.itemImageId).SetImageResource(myObj.itemImage);
    //        return myView;
    //    }
    //}

    //class MyCustomAdapterViewHolder : Java.Lang.Object
    //{
    //    //Your adapter views to re-use
    //    //public TextView Title { get; set; }
    //}
}