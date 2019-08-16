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
    public class OrderObjectAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public OrderObject mOrderObject;
        public OrderObjectAdapter(OrderObject odr)
        {
            mOrderObject = odr;
        }
        public override int ItemCount
        {
            get { return mOrderObject.numPhoto; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            OrderViewHolder vh = holder as OrderViewHolder;
            vh.OdrID.Text = mOrderObject[position].Oid.ToString();
            vh.OdrStat.Text = mOrderObject[position].Status;
            vh.OdrAmt.Text = mOrderObject[position].Amount.ToString();
            vh.OdrAdd.Text = mOrderObject[position].Address;

        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.order_layout, parent, false);
            OrderViewHolder vh = new OrderViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}