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

namespace CustomComponents.MarkAdView
{
    [Activity(Label = "ActivityMarkAd", MainLauncher = true)]
    public class ActivityMarkAd : Activity
    {
        private MarkAdView markAdView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MarkAd);

            markAdView = FindViewById<MarkAdView>(Resource.Id.markAdView1);
        }

       
    }
}