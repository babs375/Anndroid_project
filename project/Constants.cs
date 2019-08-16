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
    public static class Constants
    {
        public const int SuccessResult = 0;
        public const int FailureResult = 1;
        public const string PackageName = "project.project";
        public const string Receiver = PackageName + ".RECEIVER";
        public const string ResultDataKey = PackageName + ".RESULT_DATA_KEY";
        public const string LocationDataExtra = PackageName + ".LOCATION_DATA_EXTRA";
    }
}