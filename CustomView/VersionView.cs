using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomComponents.CustomView
{ 
    public class VersionView:TextView
    {
        public VersionView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            setVersion();
        }

        public VersionView(Context context) : base(context)
        {
            setVersion();
        }

        public VersionView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            setVersion();
        }

        public VersionView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            setVersion();
        }

        private void setVersion()
        {
            PackageInfo packageInfo =Context.PackageManager.GetPackageInfo(Context.PackageName, PackageInfoFlags.Activities);
            Text = packageInfo.VersionName;
        }
    }
}