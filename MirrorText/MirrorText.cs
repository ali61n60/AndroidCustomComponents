using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomComponents.MirrorText
{
    public class MirrorText : TextView
    {
        private Paint _mainPaint;
        private Paint _mirrorPaint;
        public MirrorText(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            init();
        }

        public MirrorText(Context context) : base(context)
        {
            init();
        }

        public MirrorText(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            init();
        }

        public MirrorText(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            init();
        }

        private void init()
        {
            _mainPaint = new Paint(PaintFlags.AntiAlias)
            {
                StrokeWidth = 2,
                TextSize = 44
            };
            _mirrorPaint = new Paint(PaintFlags.AntiAlias)
            {
                StrokeWidth = 2,
                TextSize = 100,
                Color = Color.Brown
                
            };
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            SetMeasuredDimension(MeasuredWidth,MeasuredHeight*2);
        }

        
        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Color.Blue);
            int  cx = Width / 2;
            int cy = Height / 2;
            
            base.OnDraw(canvas);
            
            canvas.Save();
            canvas.Translate(0,10);
            canvas.Scale(1f, -1f, cx, cy);
            base.OnDraw(canvas);
            canvas.Restore();
        }
    }
}