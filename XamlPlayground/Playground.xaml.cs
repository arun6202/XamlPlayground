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
<svg width='100%' height='100%' viewBox='0 0 500 200' preserveAspectRatio='none'>
    <rect x='0' y='0' width='500' height='200' style='fill:red;stroke:black;stroke-width:3;opacity:0.5' />
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
