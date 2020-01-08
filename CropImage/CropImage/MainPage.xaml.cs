using AnalysisImagePixel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;


namespace CropImage
{
	public sealed partial class MainPage : Page
    {

		public BitmapImage _bitmap { get; set; }


		public MainPage()
        {
            this.InitializeComponent();
        }

		private async void Button_Click(object sender, RoutedEventArgs e)
		{

			progressRing.IsActive = true;
			//
			var picker = new Windows.Storage.Pickers.FileOpenPicker();
			picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
			picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
			picker.FileTypeFilter.Add(".jpg");
			picker.FileTypeFilter.Add(".jpeg");
			picker.FileTypeFilter.Add(".png");
			picker.FileTypeFilter.Add(".bmp");
			Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
			if (file != null)
			{
				using (var stream= await file.OpenReadAsync())
				{
					_bitmap = new BitmapImage();
					await _bitmap.SetSourceAsync(stream);
					Image1.Source = _bitmap;
					//
					BitmapDecoder bitmapDecoder = await BitmapDecoder.CreateAsync(stream);
					//
					var pixels = await bitmapDecoder.GetPixelDataAsync();
					//
					// **************use some option**********************

					ImagePixels._threshold = EdgeDetectionThreshold;

					ImagePixels._useEdgeColor = CoverEdgeColor;
					ImagePixels.egdeColor_r = Convert.ToByte(_PickedColor.R);
					ImagePixels.egdeColor_g = Convert.ToByte(_PickedColor.G);
					ImagePixels.egdeColor_b = Convert.ToByte(_PickedColor.B);
					ImagePixels.egdeColor_a = Convert.ToByte(_PickedColor.A);


					//ImagePixels._fillOption = FillOption.RandomColor;
			

					//
					// **************get the result**************
					//var resultPixels =ImagePixels.AnsysPixel(pixels.DetachPixelData(), (int)bitmapDecoder.PixelWidth, (int)bitmapDecoder.PixelHeight);

					var resultPixels = await ImagePixels.AnsysPixelAsync(pixels.DetachPixelData(), (int)bitmapDecoder.PixelWidth, (int)bitmapDecoder.PixelHeight);

					
					//
					using (var ms = new InMemoryRandomAccessStream())
					{
						float devicedpi = Windows.Graphics.Display.DisplayInformation.GetForCurrentView().LogicalDpi;
						var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, ms);
						encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, bitmapDecoder.PixelWidth, bitmapDecoder.PixelHeight, devicedpi, devicedpi, resultPixels);
						await encoder.FlushAsync();

						var _bitmap2 = new BitmapImage();
						await _bitmap2.SetSourceAsync(ms);
						Image2.Source = _bitmap2;

					}


					//--
				}

			}
			//
			progressRing.IsActive = false;
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

			var cb = sender as ComboBox;
			switch (cb.SelectedIndex)
			{
				case 0:
					ImagePixels._fillOption = FillOption.NoChange;
					break;
				case 1:
					ImagePixels._fillOption = FillOption.Transparent;
					break;
				case 2:
					ImagePixels._fillOption = FillOption.RandomColor;
					break;
				case 3:
					ImagePixels._fillOption = FillOption.avgColor;
					break;

				default:
					break;
			}

		}
	}





	public sealed partial class MainPage :INotifyPropertyChanged
	{
		private double _Threshold=80;
		public double EdgeDetectionThreshold
		{
			get { return _Threshold; }
			set { _Threshold = value; OnPropertyChanged(); }
		}

		private bool _coverEdgeColor;
		public bool CoverEdgeColor
		{
			get { return _coverEdgeColor; }
			set { _coverEdgeColor = value; OnPropertyChanged(); }
		}

		private bool _fillAreaWithRandomColor=true;
		public bool FillAreaWithRandomColor
		{
			get { return _fillAreaWithRandomColor; }
			set { _fillAreaWithRandomColor = value; OnPropertyChanged(); }
		}



		private Color _PickedColor=Colors.Green;

		private void ColorPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
		{
			_PickedColor = colorPicker.Color;
		}

		//----------------
		public event PropertyChangedEventHandler PropertyChanged;
		private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
		{
			if (object.Equals(storage, value)) return false;
			storage = value;
			this.OnPropertyChanged(propertyName);
			return true;
		}
		private void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
