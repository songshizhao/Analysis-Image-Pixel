# Analysis-Image-Pixel
# replaced by https://github.com/songshizhao/AnimeGANv2_Sharp which use AnimeGANv2.onnx&opencvsharp
##  What is it?  
This is an example for Nuget plugin ‘AnalysisImagePixel’
AnalysisImagePixel plugin code is written under .net standard 2.0, so it can be used in App under UWP/.Net Framework(4.6.x+)  
## What can this plugin do?
Convert pictures to cartoon style, ignoring facial details and enhancing contrast.   
and some other simple add-ons  
Here are some effects:    
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/1.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/1.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/2.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/2.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/3.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/3.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/4.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/4.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/5.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/5.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/6.1.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/6.png)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/7.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/7.1.png)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/8.png)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/8.1.png)  
## How to use
### Install the Nuget plug-in 
PM->Install-Package AnalysisImagePixel  
The procedure is to read the picture pixel sits and then call the function to return pixel result     
### Sample code:
``` csharp
var pixels = await bitmapDecoder.GetPixelDataAsync();
//----------------------------------------------------------
MainFunction main = new MainFunction();
main.MsgReporter = this;// optional
var resultPixels=await main.Run(pixels.DetachPixelData(), (int)bitmapDecoder.PixelWidth, (int)bitmapDecoder.PixelHeight);
```
### Sample code full(under UWP):
``` csharp
using (var stream= await file.OpenReadAsync())
{
	_bitmap = new BitmapImage();
	await _bitmap.SetSourceAsync(stream);
	Image1.Source = _bitmap;
	//
	BitmapDecoder bitmapDecoder = await BitmapDecoder.CreateAsync(stream);
	//
	var pixels = await bitmapDecoder.GetPixelDataAsync();
        //----------------------------------------------------------
        MainFunction main = new MainFunction();

        main.MsgReporter = this;// optional

        var resultPixels=await main.Run(pixels.DetachPixelData(), (int)bitmapDecoder.PixelWidth, (int)bitmapDecoder.PixelHeight);
        //
        using (var ms = new InMemoryRandomAccessStream())
	{
		float devicedpi = Windows.Graphics.Display.DisplayInformation.GetForCurrentView().LogicalDpi;
		var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, ms);
		encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore,bitmapDecoder.PixelWidth,bitmapDecoder.PixelHeight, devicedpi, devicedpi, resultPixels);
		await encoder.FlushAsync();

		var _bitmap2 = new BitmapImage();
		await _bitmap2.SetSourceAsync(ms);
		Image2.Source = _bitmap2;

	}
//--
}
```
### Additional features
``` csharp
ImageScale.ScaleImage(byte[] pixels,int width,int height,int desireW,int desireH) //Zoom Image  
ImagePixels.AnsysPixel(byte[] pixels, int width, int height) //Edge detection  
```
#### Progress Reporting Interface  
Because it takes a long time to perform facial detail neglect calculations, IProgressMsg, an interface that provides a progress report, is implemented to report the conversion progress  
### More information
[Full code](https://github.com/songshizhao/Image-Edge-Detection/blob/master/CropImage/CropImage/MainPage.xaml.cs "how to use")
