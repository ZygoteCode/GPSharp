using PeterO.Cbor;
using Ionic.Zlib;
using Com.AugustCellars.COSE;
using System.Text;
using System.Drawing;
using System.IO;
using ZXing;

public class GPSharp
{
    public static string GetJSON(string qrContent)
    {
        if (qrContent == null)
        {
            return null;
        }

        if (!qrContent.StartsWith("HC1:"))
        {
            return null;
        }

        try
        {
            qrContent = qrContent.Substring(4);

            if (qrContent.Replace(" ", "").Replace('\t'.ToString(), "") == "")
            {
                return null;
            }

            return CBORObject.DecodeFromBytes(Message.DecodeFromBytes(ZlibStream.UncompressBuffer(Base45Sharp.Decode(qrContent))).GetContent()).ToJSONString();
        }
        catch
        {
            return null;
        }
    }

    public static string GetJSON(byte[] qrContent)
    {
        if (qrContent == null)
        {
            return null;
        }

        return GetJSON(Encoding.Unicode.GetString(qrContent));
    }

    public static string GetJSON(Bitmap bitmap)
    {
        if (bitmap == null)
        {
            return null;
        }

        return GetJSON(new BarcodeReader().Decode(bitmap).Text);
    }

    public static string GetJSON(Stream stream)
    {
        if (stream == null)
        {
            return null;
        }

        return GetJSON(new BarcodeReader().Decode(new Bitmap(stream)).Text);
    }

    public static string GetJSON(Image image)
    {
        if (image == null)
        {
            return null;
        }

        return GetJSON(new Bitmap(image));
    }

    public static string GetJSONFromString(string str)
    {
        return GetJSON(str);
    }

    public static string GetJSONFromBytes(byte[] byteArray)
    {
        return GetJSON(byteArray);
    }

    public static string GetJSONFromBitmap(Bitmap bitmap)
    {
        return GetJSON(bitmap);
    }

    public static string GetJSONFromStream(Stream stream)
    {
        return GetJSON(stream);
    }

    public static string GetJSONFromImage(Image image)
    {
        return GetJSON(image);
    }

    public static GreenPass GetGreenPassFromJSON(string json)
    {
        try
        {
            return new GreenPass(json);
        }
        catch
        {
            return null;
        }
    }

    public static GreenPass GetGreenPass(string qrContent)
    {
        try
        {
            return GetGreenPassFromJSON(GetJSON(qrContent));
        }
        catch
        {
            return null;
        }
    }

    public static GreenPass GetGreenPass(byte[] qrContent)
    {
        try
        {
            return GetGreenPassFromJSON(GetJSON(qrContent));
        }
        catch
        {
            return null;
        }
    }

    public static GreenPass GetGreenPass(Bitmap bitmap)
    {
        try
        {
            return GetGreenPassFromJSON(GetJSON(bitmap));
        }
        catch
        {
            return null;
        }
    }

    public static GreenPass GetGreenPass(Stream stream)
    {
        try
        {
            return GetGreenPassFromJSON(GetJSON(stream));
        }
        catch
        {
            return null;
        }
    }

    public static GreenPass GetGreenPass(Image image)
    {
        try
        {
            return GetGreenPassFromJSON(GetJSON(image));
        }
        catch
        {
            return null;
        }
    }

    public static GreenPass GetGreenPassFromString(string str)
    {
        return GetGreenPass(str);
    }

    public static GreenPass GetGreenPassFromBytes(byte[] byteArray)
    {
        return GetGreenPass(byteArray);
    }

    public static GreenPass GetGreenPassFromBitmap(Bitmap bitmap)
    {
        return GetGreenPass(bitmap);
    }

    public static GreenPass GetGreenPassFromStream(Stream stream)
    {
        return GetGreenPass(stream);
    }

    public static GreenPass GetGreenPassFromImage(Image image)
    {
        return GetGreenPass(image);
    }
}