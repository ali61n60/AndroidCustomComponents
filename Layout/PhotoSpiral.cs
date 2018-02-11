using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomComponents.Layout
{
    public class PhotoSpiral:ViewGroup
    {
        public PhotoSpiral(Context context) : base(context)
        {
        }

        public PhotoSpiral(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            MeasureChildren(widthMeasureSpec,heightMeasureSpec);
            View first = GetChildAt(0);
            int size = first.MeasuredWidth + first.MeasuredHeight;
            int width = ResolveSize(size, widthMeasureSpec);
            int height = ResolveSize(size, heightMeasureSpec);
            SetMeasuredDimension(width,height);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            View first = GetChildAt(0);
            int childWidth = first.MeasuredWidth;
            int childHeight = first.MeasuredHeight;
            for (int i = 0; i < ChildCount; i++)
            {
                View child = GetChildAt(i);
                int x = 0;
                int y = 0;
                switch (i)
                {
                    case 1:
                        x = childWidth;
                        y = 0;
                        break;
                    case 2:
                        x = childHeight;
                        y = childWidth;
                        break;
                    case 3:
                        x = 0;
                        y = childHeight;
                        break;
                }
                child.Layout(x,y,x+child.MeasuredWidth,y+child.MeasuredHeight);
            }
        }
    }
}