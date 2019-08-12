using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using project.Database;

namespace project
{
    public class Photo
    {
        public int mFid { get; set; }
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
        public string mDescription { get; set; }
        public int mCatID { get; set; }
        public int mPrice { get; set; }
    }
    public class PhotoAlbum
    {
        static Photo[] listPhoto =
        {
            new Photo() {mFid = 1, mPhotoID = Resource.Drawable.caesar_salad, mCaption = "Caesar Salad", mDescription = "Delicious", mCatID=1, mPrice = 10},
            new Photo() {mFid = 2, mPhotoID = Resource.Drawable.chicken_mcnuggets, mCaption = "Chicken Nuggets", mDescription = "Fried", mCatID=1, mPrice = 5},
            new Photo() {mFid = 3, mPhotoID = Resource.Drawable.chicken_mcwrap, mCaption = "Chicken Wrap", mDescription = "Mouth Watering", mCatID=1, mPrice = 15},
            new Photo() {mFid = 4, mPhotoID = Resource.Drawable.fish_and_chips, mCaption = "Fish_and Chips", mDescription = "Crispy", mCatID=1, mPrice = 8},
            new Photo() {mFid = 5, mPhotoID = Resource.Drawable.egg_cheese_mcgriddles, mCaption = "Egg Cheese Griddles", mDescription = "Smoked", mCatID=1, mPrice = 12},
            new Photo() {mFid = 6, mPhotoID = Resource.Drawable.cashew_salad, mCaption = "Cashew Salad", mDescription = "Tasty", mCatID=1, mPrice = 12},
            new Photo() {mFid = 7, mPhotoID = Resource.Drawable.hashbrowns, mCaption = "Hashbrowns", mDescription = "Crunchy", mCatID=1, mPrice = 7},
            new Photo() {mFid = 8, mPhotoID = Resource.Drawable.egg_mcmuffin, mCaption = "Egg Muffin", mDescription = "Protien Rich", mCatID=1, mPrice = 5},
            new Photo() {mFid = 9, mPhotoID = Resource.Drawable.egg_blt_bagel, mCaption = "Egg Bagel", mDescription = "Baked", mCatID=1, mPrice = 5},
            new Photo() {mFid = 10, mPhotoID = Resource.Drawable.egg_mcmuffin1, mCaption = "Jumbo Egg Muffin", mDescription = "Extra Eggy", mCatID=1, mPrice = 10},
        };

        private Photo[] photos;
        Random random;
        public PhotoAlbum()
        {
            DatabaseL db = new DatabaseL();
            var query = db.selectallFood();
            var query1 = query.Where(x => x.mCatID == 1);
            photos = query1.ToArray();
            //this.photos = listPhoto;
            random = new Random();
        }
        public int numPhoto
        {
            get
            {
                return photos.Length;
            }
        }
        public Photo this[int i]
        {
            get { return photos[i]; }
        }
    }
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public PhotoViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.textView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}