using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Steganography
{
    static readonly byte[] artifact = Encoding.UTF8.GetBytes("luNa");
    public static bool HideText(Bitmap sourceImage, string fileOut, byte[] plaintext)
    {
        Bitmap imageIn = new Bitmap(sourceImage);
        int countBajtsToHide = artifact.Length + 4 + plaintext.Length;
        int countBitsToHide = countBajtsToHide * 8;
        int countPixelsToHide = (countBitsToHide / 3) + (countBitsToHide % 3 > 0 ? 1 : 0);
        if (countPixelsToHide > sourceImage.Width * sourceImage.Height)
        {
            MessageBox.Show("Obrazek jest zamały na ten tekst.");
            return false;
        }
        byte[] textToBeEncoded = artifact.Concat(BitConverter.GetBytes(plaintext.Length)).Concat(plaintext).ToArray();

        for (int i = 0; i < countBitsToHide; i++)
        {
            int numberBajt = i / 8;
            int positionInBajt = i % 8;

            byte bajt = textToBeEncoded[numberBajt];
            string bits = Convert.ToString(bajt, 2).PadLeft(8, '0');
            int bit = bits[positionInBajt] - '0';

            int numberPixel = i / 3;
            int positionInPixel = i % 3;

            int pixelWidth = numberPixel % sourceImage.Width;
            int pixelHeight = numberPixel / sourceImage.Width;

            Color pixel = imageIn.GetPixel(pixelWidth, pixelHeight);
            byte pixelR = pixel.R;
            byte pixelG = pixel.G;
            byte pixelB = pixel.B;

            switch (positionInPixel)
            {
                case 0:
                    pixelR = (byte)((pixel.R & 0b11111110) | bit);
                    break;
                case 1:
                    pixelG = (byte)((pixel.G & 0b11111110) | bit);
                    break;
                case 2:
                    pixelB = (byte)((pixel.B & 0b11111110) | bit);
                    break;
            }
            Color newPixel = Color.FromArgb(pixel.A, pixelR, pixelG, pixelB);
            imageIn.SetPixel(pixelWidth, pixelHeight, newPixel);
        }
        imageIn.Save(fileOut);
        return true;
    }
    public static byte[] RevealText(Bitmap sourceImage)
    {
        byte[] artifactFound = PartOfImage(sourceImage, 0, artifact.Length);
        if (!artifactFound.SequenceEqual(artifact)) return Encoding.UTF8.GetBytes("W tym obrazie brak tekstu wstawionego przez program Steganografia");

        byte[] legthText = PartOfImage(sourceImage, artifact.Length, 4);
        int countBajtsText = BitConverter.ToInt32(legthText, 0);

        byte[] encryptedData = PartOfImage(sourceImage, (artifact.Length + legthText.Length), countBajtsText);
        return encryptedData;
    }

    public static byte[] PartOfImage(Bitmap sourceImage, int fromBajt, int countBajts)
    {
        byte[] partImage = new byte[countBajts];
        byte bajt = 0;
        for (int i = (fromBajt * 8); i < ((fromBajt + countBajts) * 8); i++)
        {
            int numberPixel = i / 3;
            int positionInPixel = i % 3;

            int pixelWidth = numberPixel % sourceImage.Width;
            int pixelHeight = numberPixel / sourceImage.Width;

            Color pixel = sourceImage.GetPixel(pixelWidth, pixelHeight);
            switch (positionInPixel)
            {
                case 0:
                    bajt = (byte) ((bajt << 1) | (pixel.R & 1));
                    break;
                case 1:
                    bajt = (byte) ((bajt << 1) | (pixel.G & 1));
                    break;
                case 2:
                    bajt = (byte) ((bajt << 1) | (pixel.B & 1));
                    break;
            }
            if (i % 8 == 7)
            {
                partImage[(i / 8) - fromBajt] = bajt;
                bajt = 0;
            }
        }
        return partImage;
    }
}

