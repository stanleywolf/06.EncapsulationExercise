using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private const double NON_ZERO = 0;
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return length; }
        set
        {
            if(value <= NON_ZERO)
                throw new ArgumentException("Length cannot be zero or negative.");
            length = value;
        }
    }
    public double Width
    {
        get { return width; }
        set
        {
            if (value <= NON_ZERO)
                throw new ArgumentException("Width cannot be zero or negative.");
            width = value;
        }
    }
    public double Height
    {
        get { return height; }
        set
        {
            if (value <= NON_ZERO)
                throw new ArgumentException("Height cannot be zero or negative.");
            height = value;
        }
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