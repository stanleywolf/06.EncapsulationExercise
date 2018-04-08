using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return length; }
        set { length = value; }
    }
    public double Width
    {
        get { return width; }
        set { width = value; }
    }
    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
    public override string ToString()
    {
        var surA = (2 * length * width) + (2 * length * height) + (2 * width * height);
        var latA = (2 * length * height) + (2 * width * height);
        var volume = length * width * height;
        var builder = new StringBuilder();
        builder.AppendLine($"Surface Area - {surA:f2}");
        builder.AppendLine($"Lateral Surface Area - {latA:f2}");
        builder.AppendLine($"Volume - {volume:f2}");
        return builder.ToString();
    }
}