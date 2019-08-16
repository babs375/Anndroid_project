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
    public class UserCartObjectAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public UserCartObject mUserCartObject;
        public UserCartObjectAdapter(UserCartObject usrcrt)
        {
            mUserCartObject = usrcrt;
        }
        public override int ItemCount
        {
            get { return mUserCartObject.numPhoto; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            UserCartViewHolder vh = holder as UserCartViewHolder;
            vh.Image.SetImageResource(mUserCartObject[position].mPhotoID);
            vh.Caption.Text = mUserCartObject[position].mCaption;
            vh.Price.Text = mUserCartObject[position].mPrice.ToString();
            
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CellLayout, parent, false);
            UserCartViewHolder vh = new UserCartViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}