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
    [Activity(Label = "ClockViewActivity", MainLauncher = true)]
    public class ClockViewActivity : Activity
    {
        private Button button;
        private TextView textView;
        private int n = 10;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ShowClock);
            button = FindViewById<Button>(Resource.Id.buttonCuts);
            button.Click += (sender, args) =>
            {
                textView.Text = n.ToString();
                n++;
            };
            textView = FindViewById<TextView>(Resource.Id.textView1);

        }
    }
}