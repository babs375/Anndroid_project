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
using SQLite;

namespace project.Model
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Oid { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public float Amount { get; set; }
        public int Uid { get; set; }

    }
}