# Image-Edge-Detection
## 这是什么?  
使用Nuget插件AnalysisImagePixel的一个示例  
AnalysisImagePixel插件是基于.net standard框架开发的, 因此可用于UWP/Net Framework(4.6.x+)框架的APP
## 'AnalysisImagePixel'插件能干什么
检测图片边缘,向边缘包围的闭合区域填充颜色(可选)  
下面是一些效果图:  
![example](https://www.songshizhao.com/editor/attached/image/20200105/20200105152045_0262.png)  
![example](https://www.songshizhao.com/editor/attached/image/20200105/20200105152104_3705.png)  
## 如何使用
### 安装Nuget插件 
PM->Install-Package AnalysisImagePixel  
使用过程就是读取图片像素,然后调用返回像素结果    
### 示例代码:
``` csharp
// **************use some option**********************
ImagePixels._threshold = EdgeDetectionThreshold;
ImagePixels._useEdgeColor = CoverEdgeColor;
ImagePixels.egdeColor_r = Convert.ToByte(_PickedColor.R);
ImagePixels.egdeColor_g = Convert.ToByte(_PickedColor.G);
ImagePixels.egdeColor_b = Convert.ToByte(_PickedColor.B);
ImagePixels.egdeColor_a = Convert.ToByte(_PickedColor.A);
//ImagePixels._fillOption = FillOption.RandomColor;
// **************get the result**************
var resultPixels =ImagePixels.AnsysPixel(pixels.DetachPixelData(), (int)bitmapDecoder.PixelWidth, (int)bitmapDecoder.PixelHeight);
```
### 详细信息
[完整代码](https://github.com/songshizhao/Image-Edge-Detection/blob/master/CropImage/CropImage/MainPage.xaml.cs "how to use")



