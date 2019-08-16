using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using project.Database;
using project.Model;

namespace project
{

    public class UserCartObject
    {
        public class CartList
        {
            public int mFid { get; set; }
            public int mPhotoID { get; set; }
            public string mCaption { get; set; }
            public int mPrice { get; set; }
            public int usrID { get; set; }
        }

        private CartList[] crtlst;
        Random random;
        public UserCartObject(int uid)
        {
            try
            {
                DatabaseL db = new DatabaseL();
                var query = db.ListCart(uid);
                crtlst = query.ToArray();
                //this.photos = listPhoto;
                random = new Random();
            }
            catch(Exception ex)
            { }
            
        }

        public int numPhoto
        {
            get
            {
                return crtlst.Length;
            }
        }
        public CartList this[int i]
        {
            get { return crtlst[i]; }
        }
    }
    public class UserCartViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public TextView Price { get; set; }

        public UserCartViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.itemImageId);
            Caption = itemview.FindViewById<TextView>(Resource.Id.itemName);
            Price = itemview.FindViewById<TextView>(Resource.Id.itemPrice);

            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}