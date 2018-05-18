using System;
using System.IO;
using System.Reflection;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using SKSvg = SkiaSharp.Extended.Svg.SKSvg;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground
{
	public partial class Playground : ContentPage
	{

		public Playground()
		{
			InitializeComponent();

			skcv.PaintSurface += CanvasViewOnPaintSurface;


		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			skcv.InvalidateSurface();

		}

		private const string SVGXml = @"<?xml version='1.0' encoding='UTF-8' ?>
<svg xmlns='http://www.w3.org/2000/svg' preserveAspectRatio='none' width='100%' height='100%' viewBox='0 0 1000 700' version='1.1'>
    <path d='m 0,0 1333,0 0,320.53 -72.67,48.42 52.45,37.57 -126.31,52.84 50.13,136.19 -19.98,37.26 -39.47,-11.71 -38.75,40.47 -63.32,-12.07 -30.44,-135.6 -7.94,3.28 24.74,140.95 -38.13,30.26 -44.35,-3.33 -35.83,23.39 -48.93,-13.22 -38.24,-141.48 -10.57,3.68 6.2,148.97 -33.88,20.46 -25.26,-13.85 -22.48,31.49 -27.36,-22.32 -32,24.34 L 680.55,718.6 664.7,564 l -17.08,0.91 -21.88,159.73 -29.17,25.36 -1.72,0 -27.84,-23.02 -23.3,13.88 -21.6,-20.71 -22.31,11.21 -24.13,-23.18 10.14,-155.4 -4.77,-2.2 -33.64,157.63 -29.97,14.21 -8.8,-1.17 -35.21,-20.38 -34.17,10.41 -8.63,-2.79 -32.93,-26.68 24.96,-151.54 -10.66,-2.09 -45.62,140.34 -32.49,15.33 -55.08,-40.36 -38.99,9.07 L 106.82,618.43 153.26,486.06 8.85,428.57 63.93,380.86 0,333.05 z' fill='#d23e2c'/>
</svg>";
		static XDocument GenerateSVG()
		{
			var xDocument = XDocument.Parse(SVGXml);
			return xDocument;

			xDocument.Root.Add(new XElement("rect",
													  new XAttribute("width", "1000"),
													  new XAttribute("height", "1000"),
													  new XAttribute("style", "stroke:black;stroke-width:10;opacity:0.5"),
													  new XAttribute("fill", LayoutBuilder.RandomColor().ToSKColor().ToString())));


			var gElement = new XElement("g", new XAttribute("fill", LayoutBuilder.RandomColor().ToSKColor().ToString()));

			var seed = new Random().Next(1, 40);
			var increment = new Random().Next(1, 40);

			var reset = seed;

			while (seed <= 1000)
			{
				gElement.Add(new XElement("rect",
													 new XAttribute("width", "1"),
													 new XAttribute("height", "1000"),
										  new XAttribute("x", seed.ToString())));
				seed = seed + increment;
			}

			if (new Random().NextDouble() >= 0.5)
			{
				seed = reset;

			}
			else
			{
				seed = new Random().Next(1, 40);
				increment = new Random().Next(1, 40);
			}

			while (seed <= 1000)
			{

				gElement.Add(new XElement("rect",
												  new XAttribute("width", "1000"),
												  new XAttribute("height", "1"),
									  new XAttribute("y", seed.ToString())));

				seed = seed + increment;

			}

			xDocument.Root.Add(gElement);

			return xDocument;


		}

		private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
		{

			using (var reader = GenerateSVG().CreateReader())
			{
				var svg = new SKSvg();
				svg.Load(reader);

				var surface = args.Surface;
				var canvas = surface.Canvas;
				canvas.Clear(SKColors.White);

				canvas.DrawPicture(svg.Picture);

				canvas.Dispose();
			}
		}

	}
}
