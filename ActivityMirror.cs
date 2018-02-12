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

namespace CustomComponents
{
    [Activity(Label = "ActivityMirror", MainLauncher = true)]
    public class ActivityMirror : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            try
            {
                SetContentView(Resource.Layout.mirror);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this,ex.Message,ToastLength.Long).Show();
            }
            
        }
    }
}