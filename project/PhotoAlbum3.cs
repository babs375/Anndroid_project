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

namespace project
{
    //  Cart
    public class Photo3
    {
        public int crtID { get; set; }
        public int mPhotoID { get; set; }
        public string crtItem { get; set; }
        public int crtPrice { get; set; }
        public int usrID { get; set; }
    }
    public class PhotoAlbum3
    {
        static Photo3[] listPhoto =
        {
            new Photo3() {crtID = 1, mPhotoID = Resource.Drawable.cashew_salad, crtItem = "Cart 1", crtPrice = 5, usrID = 1},
            new Photo3() {crtID = 2, mPhotoID = Resource.Drawable.egg_blt_bagel, crtItem = "Cart 2", crtPrice = 15, usrID = 1},
            new Photo3() {crtID = 3, mPhotoID = Resource.Drawable.pomegranate_smoothie, crtItem = "Cart 3", crtPrice = 12, usrID = 2},
        };
        private Photo3[] photos;
        Random random;
        public PhotoAlbum3()
        {
            this.photos = listPhoto;
            random = new Random();
        }
        public int numPhoto
        {
            get
            {
                return photos.Length;
            }
        }
        public Photo3 this[int i]
        {
            get { return photos[i]; }
        }
    }
    public class PhotoViewHolder3 : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public TextView Price { get; set; }
        public TextView Total { get; set; }
        public TextView Amount { get; set; }
        public PhotoViewHolder3(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.itemImageId);
            Caption = itemview.FindViewById<TextView>(Resource.Id.itemName);
            Price = itemview.FindViewById<TextView>(Resource.Id.itemPrice);
            //Amount = itemview.FindViewById<TextView>(Resource.Id.cAmount);
            Total = itemview.FindViewById<TextView>(Resource.Id.total);

            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}