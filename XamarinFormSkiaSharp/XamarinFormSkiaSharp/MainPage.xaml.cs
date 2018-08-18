using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace XamarinFormSkiaSharp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            //clear SKCanvas first.
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear();

            if (!(sender is SKCanvasView contaienr))
            {
                return;
            }

            var scale = (float)(e.Info.Width / contaienr.Width);
#if DEBUG
#if !WINDOWS_UWP
            Console.WriteLine("Scale = {0}", scale);
#else
			System.Diagnostics.Debug.WriteLine("Scale = {0}", scale);
#endif
#endif
            canvas.Scale(scale);

            var centerX = (float)contaienr.Width / 2;
            var centerY = (float)contaienr.Height / 2;

            canvas.DrawCircle(centerX, centerY, 100, new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 1,
                Color = SKColors.Blue
            });

            canvas.DrawCircle(centerX, centerY, 80, new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 3,
                Color = SKColors.DarkRed
            });

            canvas.DrawCircle(centerX, centerY, 50, new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.DarkCyan
            });

        }

        private void SKCanvasView_Touch(object sender, SKTouchEventArgs e)
        {
#if DEBUG
#if !WINDOWS_UWP
            Console.WriteLine("Touch Type = {0}", e.ActionType);
#else
			System.Diagnostics.Debug.WriteLine("Touch Type = {0}", e.ActionType);
#endif
#endif
        }
    }
}
