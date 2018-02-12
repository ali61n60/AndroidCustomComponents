using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomComponents.ClockView
{
    public class ClockView : TextView
    {
        public ClockView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            startClock();
        }

        public ClockView(Context context) : base(context)
        {
            startClock();
        }

        public ClockView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            startClock();
        }

        public ClockView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            startClock();
        }

        private void startClock()
        {
            Text = "test";
            Timer timer=new Timer(1000);
            timer.Elapsed += (sender, args) =>
            {
                (Context as Activity).RunOnUiThread(() =>
                {
                    Text = DateTime.Now.ToLongTimeString();
                    //RequestLayout();
                    //Invalidate();
                });};
            timer.Start();
        }
    }
}