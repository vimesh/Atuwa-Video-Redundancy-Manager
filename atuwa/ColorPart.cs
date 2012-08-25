using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
namespace atuwa
{

    class ColorPart
    {
        //int[] previousHSV;
        ResizeBilinear resizeFilter;
        Pixellate pixelateFilter;
        ChannelFiltering redChannelFilter, greenChannelFilter, blueChannelFilter;
        IntRange intRange;
        List<int[, ,]> frameMatrices;
        bool isBreakPoint;
        bool he = false;

        public ColorPart()
        {
            //previousHSV = null;

            resizeFilter = new ResizeBilinear(128, 128);

            pixelateFilter = new Pixellate();
            pixelateFilter.PixelWidth = 32;
            pixelateFilter.PixelHeight = 32;

            redChannelFilter = new ChannelFiltering();
            greenChannelFilter = new ChannelFiltering();
            blueChannelFilter = new ChannelFiltering();
            intRange = new IntRange(0, 0);
            redChannelFilter.Green = intRange; redChannelFilter.Blue = intRange;
            greenChannelFilter.Red = intRange; greenChannelFilter.Blue = intRange;
            blueChannelFilter.Red = intRange; blueChannelFilter.Green = intRange;

            frameMatrices = new List<int[, ,]>();
        }

        public bool generateColorPart(Bitmap sourceImage, ref Bitmap red, ref Bitmap green, ref Bitmap blue)
        {

            Bitmap resizedImage = resizeFilter.Apply(sourceImage);
            Bitmap pixelatedImage = resizedImage;
            pixelateFilter.ApplyInPlace(pixelatedImage);

            int[, ,] frameMatrix = new int[4, 4, 3];
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    frameMatrix[x, y, 0] = pixelatedImage.GetPixel(16 + (32 * x), 16 + (32 * y)).R;
                    frameMatrix[x, y, 1] = pixelatedImage.GetPixel(16 + (32 * x), 16 + (32 * y)).G;
                    frameMatrix[x, y, 2] = pixelatedImage.GetPixel(16 + (32 * x), 16 + (32 * y)).B;
                }
            }

            isBreakPoint = false;
            if (frameMatrices.Count() > 0)
            {
                int[, ,] previousMatrix = frameMatrices.Last();
                int variance = 0;

                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        for (int rgb = 0; rgb < 3; rgb++)
                        {
                            variance += (int)Math.Pow((previousMatrix[x, y, rgb] - frameMatrix[x, y, rgb]), 2);
                        }
                    }
                }
                if (variance > 66000)
                {
                    isBreakPoint = true;
                }
            }
            
            frameMatrices.Add(frameMatrix);

            red = redChannelFilter.Apply(pixelatedImage);
            green = greenChannelFilter.Apply(pixelatedImage);
            blue = blueChannelFilter.Apply(pixelatedImage);

            /*isBreakPoint = false;
            if (previousHSV == null) { previousHSV = new int[3] { 0, 0, 0 }; }
            else
            {
                if (Math.Abs(previousHSV[0] - (int)colorHSB.GetHue()) > 40)
                { breakpoint = true; brush = new SolidBrush(Color.White); redGraphics.FillRectangle(brush, 0, 0, 120, 120); }
            }
            previousHSV[0] = (int)colorHSB.GetHue();
            previousHSV[1] = (int)colorHSB.GetSaturation();
            previousHSV[2] = (int)colorHSB.GetBrightness();*/

            return isBreakPoint;
        }

        public int[, , ,] getColorPart()
        {
            int[, , ,] colorPartTree = new int[7, 4, 4, 3];

            // Fill leaf nodes of colorPartTree
            for (int part = 0; part < 4; part++)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        colorPartTree[3 + part, x, y, 0] = 0;
                        colorPartTree[3 + part, x, y, 1] = 0;
                        colorPartTree[3 + part, x, y, 2] = 0;

                        for (int frame = ((part * frameMatrices.Count()) / 4); frame < (((part + 1) * frameMatrices.Count()) / 4); frame++)
                        {
                            int[, ,] tempFrame = new int[4, 4, 3];
                            tempFrame = frameMatrices.ElementAt(frame);
                            colorPartTree[3 + part, x, y, 0] += tempFrame[x, y, 0];
                            colorPartTree[3 + part, x, y, 1] += tempFrame[x, y, 1];
                            colorPartTree[3 + part, x, y, 2] += tempFrame[x, y, 2];
                        }
                    }
                }
            }

            // Fill non-leaf nodes of colorPartTree
            for (int level = 1; level >= 0; level--)
            {
                for (int node = 0; node <= level; node++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            colorPartTree[(((int)(Math.Pow(2, level))) - 1) + node, x, y, 0] = (int)(colorPartTree[(((((int)(Math.Pow(2, level))) + node) * 2) - 1), x, y, 0] + colorPartTree[(((int)(Math.Pow(2, level))) + node) * 2, x, y, 0]) / 2;
                            colorPartTree[(((int)(Math.Pow(2, level))) - 1) + node, x, y, 1] = (int)(colorPartTree[(((((int)(Math.Pow(2, level))) + node) * 2) - 1), x, y, 1] + colorPartTree[(((int)(Math.Pow(2, level))) + node) * 2, x, y, 1]) / 2;
                            colorPartTree[(((int)(Math.Pow(2, level))) - 1) + node, x, y, 2] = (int)(colorPartTree[(((((int)(Math.Pow(2, level))) + node) * 2) - 1), x, y, 2] + colorPartTree[(((int)(Math.Pow(2, level))) + node) * 2, x, y, 2]) / 2;
                        }
                    }
                }
            }

            // Generate colorPartRankTree
            int[, , ,] colorPartRankedTree = new int[7, 4, 4, 3];

            for (int node = 0; node < 7; node++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        colorPartRankedTree[node, i, j, 0] = 0;
                        colorPartRankedTree[node, i, j, 1] = 0;
                        colorPartRankedTree[node, i, j, 2] = 0;

                        for (int k = 0; k < 4; k++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                                if (colorPartTree[node, i, j, 0] > colorPartTree[node, k, l, 0]) colorPartRankedTree[node, i, j, 0]++;
                                if (colorPartTree[node, i, j, 1] > colorPartTree[node, k, l, 1]) colorPartRankedTree[node, i, j, 1]++;
                                if (colorPartTree[node, i, j, 2] > colorPartTree[node, k, l, 2]) colorPartRankedTree[node, i, j, 2]++;
                            }
                        }
                    }
                }
            }
            frameMatrices.Clear();
            return colorPartRankedTree;
        }
    }
}
