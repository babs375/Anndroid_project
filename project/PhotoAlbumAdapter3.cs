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
    public class PhotoAlbumAdapter3 : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public PhotoAlbum3 mPhotoAlbum;
        public PhotoAlbumAdapter3(PhotoAlbum3 photoAlbum)
        {
            mPhotoAlbum = photoAlbum;
        }
        public override int ItemCount
        {
            get { return mPhotoAlbum.numPhoto; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder3 vh = holder as PhotoViewHolder3;       
            vh.Image.SetImageResource(mPhotoAlbum[position].mPhotoID);
            vh.Caption.Text = mPhotoAlbum[position].crtItem;
            vh.Price.Text = mPhotoAlbum[position].crtPrice.ToString();
            int tot = 0;
            for(int i=0; i< mPhotoAlbum.numPhoto; i++)
            {
                tot += mPhotoAlbum[i].crtPrice;
            }
            vh.Total.Text = tot.ToString();
            //vh.Total.Text = (tot * 87 / 100).ToString();
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CellLayout, parent, false);
            PhotoViewHolder3 vh = new PhotoViewHolder3(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}