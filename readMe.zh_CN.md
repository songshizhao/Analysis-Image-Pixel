# Analysis-Image-Pixel
## 这是什么?  
使用Nuget插件AnalysisImagePixel的一个示例  
AnalysisImagePixel插件是基于.net standard框架开发的, 因此可用于UWP/Net Framework(4.6.x+)框架的APP
## 'AnalysisImagePixel'插件能干什么
将图片转换为卡通风格，忽略面部细节和增强对比度。  
下面是一些效果图:  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/1.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/1.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/2.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/2.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/3.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/3.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/4.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/4.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/5.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/5.1.jpg)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/6.1.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/6.png)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/7.jpg)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/7.1.png)  
![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/8.png)![image](https://raw.githubusercontent.com/songshizhao/Analysis-Image-Pixel/master/CropImage/CropImage/samples/8.1.png)  
## 如何使用
### 安装Nuget插件 
PM->Install-Package AnalysisImagePixel  
使用过程就是读取图片像素,然后调用返回像素结果。   
### 示例代码:
``` csharp
var pixels = await bitmapDecoder.GetPixelDataAsync();
//----------------------------------------------------------
MainFunction main = new MainFunction();
main.MsgReporter = this;// optional
var resultPixels=await main.Run(pixels.DetachPixelData(), (int)bitmapDecoder.PixelWidth, (int)bitmapDecoder.PixelHeight);
```
### 示例代码full(under UWP):
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
### 详细信息
[完整代码](https://github.com/songshizhao/Image-Edge-Detection/blob/master/CropImage/CropImage/MainPage.xaml.cs "how to use")



