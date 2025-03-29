namespace OptraxMVC.Models.Formatters
{
    public interface IPhoneFormatter
    {
        string Format(string num);
        string Normalize(string phoneNumber);
    }

    public class PhoneFormatter : IPhoneFormatter
    {
        public string Format(string num)
        {
            if (string.IsNullOrWhiteSpace(num))
                return "";

            var digits = new string([.. num.Where(char.IsDigit)]);

            if (digits.Length == 10)
            {
                return $"({digits[..3]}) {digits.Substring(3, 3)}-{digits.Substring(6, 4)}";
            }
            else if (digits.Length == 7)
            {
                return $"{digits[..3]}-{digits.Substring(3, 4)}";
            }

            return num;
        }
        public string Normalize(string num)
        {
            if (string.IsNullOrWhiteSpace(num))
                return "";

            return new string([.. num.Where(char.IsDigit)]);
        }
    }

}
