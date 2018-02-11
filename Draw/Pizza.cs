using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomComponents.Draw
{
    public class Pizza:View
    {
        public void SetNumberOfCuts(int numberOfCuts)
        {
            _numberOfCuts = numberOfCuts;
            Invalidate();
            RequestLayout();
        }

        private Paint _defaultPaint;
        private int _numberOfCuts=5;
        private int _pureWidth;
        private int _pureHeight;
        private int _cx;
        private int _cy;
        private float _radius;

        public Pizza(Context context) : base(context)
        {
            initialize(context,null);
        }

        public Pizza(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            initialize(context,attrs);
        }

        private void initialize(Context context, IAttributeSet attrs)
        {
            int strokeWidth = 4;
            Color color = Color.Yellow;
            if (attrs != null)
            {
               TypedArray array= context.ObtainStyledAttributes(attrs, Resource.Styleable.Pizza);
                strokeWidth = array.GetDimensionPixelSize(Resource.Styleable.Pizza_StrokeWidth, strokeWidth);
                color = array.GetColor(Resource.Styleable.Pizza_Color, color);
                _numberOfCuts = array.GetInt(Resource.Styleable.Pizza_NumberOfCuts, _numberOfCuts);

            }
            _defaultPaint = new Paint(PaintFlags.AntiAlias)
            {
                Color = color,
                StrokeWidth = strokeWidth
            };
            _defaultPaint.SetStyle(Paint.Style.Stroke);

        }

       
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            _pureWidth = Width - PaddingLeft - PaddingRight;
            _pureHeight = Height - PaddingTop - PaddingBottom;
            _cx = _pureWidth/2 + PaddingLeft;
            _cy = _pureHeight/2 + PaddingTop;
            float diameter = Math.Min(_pureWidth,_pureHeight) - _defaultPaint.StrokeWidth;
            _radius = diameter / 2;

        }

        protected override void OnDraw(Canvas canvas)
        {
            drawCircle(canvas,_cx,_cy,_radius);
            drawPizzaCuts(canvas,_cx,_cy,_radius);
        }

        private void drawCircle(Canvas canvas,float cx,float cy,float radius)
        {
            canvas.DrawCircle(cx, cy, radius, _defaultPaint);
        }

        private void drawPizzaCuts(Canvas canvas, float cx, float cy, float radius)
        {
            double degree = 360f/_numberOfCuts;
            canvas.Save();
            for (int i = 0; i < _numberOfCuts; i++)
            {
                canvas.Rotate((float)degree, cx, cy);
                canvas.DrawLine(cx, cy, cx, cy - radius, _defaultPaint);
            }
            canvas.Restore();
        }

        
    }
}