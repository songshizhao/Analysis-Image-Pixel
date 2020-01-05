# Image-Edge-Detection
## what is this?  
This is an example using Nuget plugin 'AnalysisImagePixel' 
'AnalysisImagePixel' is developed under .net standard framework, so it can be used in UWP/Net Framework(4.6.x+) applications
## what can 'AnalysisImagePixel' do
detect image edge and fill the empty part with color(optional)
here is some results:
![example](https://www.songshizhao.com/editor/attached/image/20200105/20200105152045_0262.png)  
![example](https://www.songshizhao.com/editor/attached/image/20200105/20200105152104_3705.png)  
## how to use
###install package  
PM->Install-Package AnalysisImagePixel  
just read image pixels and return result pixels  
### example code:
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
### more detail
[full example code](https://github.com/songshizhao/Image-Edge-Detection/blob/master/CropImage/CropImage/MainPage.xaml.cs "how to use")



