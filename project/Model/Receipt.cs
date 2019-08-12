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

namespace project.Model
{
    public class Receipt
    {
        public List<Order> items;
        public string totalcost;
    }
}