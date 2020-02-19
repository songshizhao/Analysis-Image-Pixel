using AnalysisImagePixel;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            //var c = new Color();

            //int width = 3;int height = 3;

            ////Matrix<Complex32> fx = Matrix<Complex32>.Build.Dense(1, 2);
            ////fx[0, 0] = 1;
            ////fx[0, 1] = -1;
            ////Matrix<Complex32> fy = Matrix<Complex32>.Build.Dense(2, 1);
            ////fy[0, 0] = 1;
            ////fy[1, 0] = -1;

            ////var otfFx = L0Smoothing.psf2otf(fx, width, height);
            ////var otfFy = L0Smoothing.psf2otf(fy, width, height);

            ////var otfFx = L0Smoothing.fft2(fx);
            ////var otfFy = L0Smoothing.fft2(fy);



            //Matrix<Complex32> S = Matrix<Complex32>.Build.Dense(2, 3);
            //S[0, 0] = .1f;
            //S[0, 1] = .7f;
            //S[0, 2] = .2f;
            //S[1, 0] = .4f;
            //S[1, 1] = .5f;
            //S[1, 2] = .6f;


            //Matrix<Complex32> S = Matrix<Complex32>.Build.Dense(2, 2);
            //S[0, 0] = 1;
            //S[0, 1] = 2;
            //S[1, 0] = 3;
            //S[1, 1] = 4;

            //var re = L0Smoothing.Smoothing(S);

            

            //// Console.WriteLine(otfFy.ToString());

            //byte x = 255;
            //byte y = 0;
            //byte z = 100;


            //var x0 = x / 255f;
            //var y0 = y / 255f;
            //var z0 = z / 255f;


            //Console.WriteLine(x0.ToString());
            //Console.WriteLine(y0.ToString());
            //Console.WriteLine(z0.ToString());


            //Console.WriteLine((Math.Floor(x0 * 255)).ToString());
            //Console.WriteLine((Math.Floor(y0 * 255)).ToString());
            //Console.WriteLine((Math.Floor(z0 * 255)).ToString());



            //Convert.ToByte(x);
            //pixels[index + 1] = Convert.ToByte(Math.Floor(RGBA[1][h, w].Real) * 255);
            //pixels[index + 2] = Convert.ToByte(Math.Floor(RGBA[2][h, w].Real) * 255);
            //pixels[index + 3] = Convert.ToByte(Math.Floor(RGBA[3][h, w].Real) * 255);


            Console.Read();
        }
    }
















}
//var matrix1 = Matrix.Build.Dense(4, 4);


//Complex32[] ROWS1 = new Complex32[3] { new Complex32(0, 0), new Complex32(-1, 0), new Complex32(0, 0) };
//Complex32[] ROWS2 = new Complex32[3] { new Complex32(-1, 0), new Complex32(4, 0), new Complex32(-1, 0) };
//Complex32[] ROWS3 = new Complex32[3] { new Complex32(0, 0), new Complex32(-1, 0), new Complex32(0, 0) };



////Complex32[] ROWS1 = new Complex32[3] { new Complex32(4, 0), new Complex32(-1, 0), new Complex32(-1, 0) };
////Complex32[] ROWS2 = new Complex32[3] { new Complex32(-1, 0), new Complex32(0, 0), new Complex32(0, 0) };
////Complex32[] ROWS3 = new Complex32[3] { new Complex32(-1, 0), new Complex32(0, 0), new Complex32(0, 0) };
////Complex32[] ROWS4 = new Complex32[4] { new Complex32(0, 0), new Complex32(-1, 0), new Complex32(0, 0), new Complex32(0, 0) };
//Matrix<Complex32> matrix0 = Matrix<Complex32>.Build.DenseOfRowArrays(ROWS1, ROWS2,ROWS3);//.Dense(3, 3);

//


//double[] r1 = new double[3] { 0, -1, 0 };
//double[] r2 = new double[3] { -1, 4, -1 };
//double[] r3 = new double[3] { 0, -1, 0 };
//Matrix<double> matrix1 = Matrix<double>.Build.DenseOfRowArrays(r1, r2, r3);
//var ca=L0Smoothing.Psf2otf(matrix1.ToArray());

//for (int i = 0; i < ca.Length; i++)
//{
//    Console.WriteLine(ca[0,i]);
//}

//MathNet.Numerics.IntegralTransforms.Fourier.Forward2D(matrix0, MathNet.Numerics.IntegralTransforms.FourierOptions.Matlab);

