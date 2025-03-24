namespace OptraxDAL.Models
{
    public readonly struct ColorRgba
    {
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
        public byte A { get; }

        public ColorRgba(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public ColorRgba(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentException("Color string is empty.");
            }

            color = color.Trim();

            if (color.StartsWith('#'))
            {
                var hex = color.TrimStart('#');

                if (hex.Length == 6)
                {
                    hex += "FF";
                }

                if (hex.Length != 8)
                {
                    throw new ArgumentException("Hex color must be 6 or 8 characters.");

                }
                R = Convert.ToByte(hex.Substring(0, 2), 16);
                G = Convert.ToByte(hex.Substring(2, 2), 16);
                B = Convert.ToByte(hex.Substring(4, 2), 16);
                A = Convert.ToByte(hex.Substring(6, 2), 16);
            }
            else if (color.StartsWith("rgb", StringComparison.OrdinalIgnoreCase))
            {
                bool isRgba = color.StartsWith("rgba", StringComparison.OrdinalIgnoreCase);

                var parts = color.Replace("rgba(", "").Replace("rgb(", "").Replace(")", "").Trim().Split(',');

                if ((isRgba && parts.Length != 4) || (!isRgba && parts.Length != 3))
                {
                    throw new ArgumentException("Invalid rgb/rgba color format.");
                }

                R = byte.Parse(parts[0].Trim());
                G = byte.Parse(parts[1].Trim());
                B = byte.Parse(parts[2].Trim());

                if (isRgba)
                {
                    float alpha = float.Parse(parts[3].Trim(), System.Globalization.CultureInfo.InvariantCulture);
                    A = (byte)Math.Round(alpha * 255);
                }
                else
                {
                    A = 255;
                }
            }
            else
            {
                throw new ArgumentException("Unrecognized color format.");
            }
        }

        public static ColorRgba FromBytes(byte[] data)
        {
            if (data is not [var r, var g, var b, var a])
            {
                throw new ArgumentException("Color data must be 4 bytes.");
            }
            return new ColorRgba(r, g, b, a);
        }

        public byte[] ToBytes() => [R, G, B, A];

        public override string ToString() => A < 255 ? $"rgba({R}, {G}, {B}, {A / 255f:0.##})" : $"rgb({R}, {G}, {B})";

        public string ToHex() => $"#{R:X2}{G:X2}{B:X2}{A:X2}";
    }
}
