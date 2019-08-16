using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using V4 = Android.Support.V4.App;

namespace project
{
    public class TabAdapter : FragmentStatePagerAdapter
    {
        private static List<V4.Fragment> mFragmentList = new List<V4.Fragment>();
        private static List<string> mFragmentTitleList = new List<string>();
        public TabAdapter(V4.FragmentManager fm) : base(fm) { }

        public void AddFragment(V4.Fragment fragment, string title)
        {
            mFragmentList.Add(fragment);
            mFragmentTitleList.Add(title);
        }

        public void RemoveFragment()
        {
            mFragmentList.Clear();
            mFragmentTitleList.Clear();
        }

        public override V4.Fragment GetItem(int position)
        {
            return mFragmentList[position];
        }
        public override int Count
        {
            get
            {
                return mFragmentList.Count;
            }
        }
        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(mFragmentTitleList[position]);
        }
        
    }
}