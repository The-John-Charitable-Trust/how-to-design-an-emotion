using System;

class ColorConcept
{
    public bool IsAdmissible(double wavelengthNm, double luminance, double saturation)
    {
        return wavelengthNm >= 380 && wavelengthNm <= 750
            && luminance >= 0.0 && luminance <= 1.0
            && saturation >= 0.0 && saturation <= 1.0;
    }
}

class ColorInstance
{
    public double WavelengthNm { get; }
    public double Luminance { get; }
    public double Saturation { get; }

    public ColorInstance(double wavelengthNm, double luminance, double saturation)
    {
        WavelengthNm = wavelengthNm;
        Luminance = luminance;
        Saturation = saturation;
    }
}

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Usage: dotnet run -- <wavelengthNm> <luminance> <saturation>");
            return;
        }

        double wavelengthNm = double.Parse(args[0]);
        double luminance = double.Parse(args[1]);
        double saturation = double.Parse(args[2]);

        var concept = new ColorConcept();
        bool isValid = concept.IsAdmissible(wavelengthNm, luminance, saturation);

        Console.WriteLine($"WavelengthNm: {(int)wavelengthNm}");
        Console.WriteLine($"Luminance: {luminance:F2}");
        Console.WriteLine($"Saturation: {saturation:F2}");
        Console.WriteLine($"IsValid(): {isValid}");

        if (!isValid)
        {
            return;
        }

        var instance = new ColorInstance(wavelengthNm, luminance, saturation);
        Console.WriteLine($"Category: {Classify(instance)}");
    }

    static string Classify(ColorInstance color)
    {
        if (color.WavelengthNm >= 450 && color.WavelengthNm < 495)
            return "blue";
        if (color.WavelengthNm >= 495 && color.WavelengthNm < 570)
            return "green";
        if (color.WavelengthNm >= 570 && color.WavelengthNm < 590)
            return "yellow";
        if (color.WavelengthNm >= 590 && color.WavelengthNm < 620)
            return "orange";
        if (color.WavelengthNm >= 620 && color.WavelengthNm <= 750)
            return "red";
        return "violet";
    }
}
