using System.Text;

namespace Sdl.Community.GroupShareKit.Helpers
{
    public class ExpressionFieldValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }

        public override string ToString()
        {
            return "\"" + EscapeString(Name) + "\"" + Operator + "\"" + EscapeString(Value) + "\"";
        }

        public static string EscapeString(string expression)
        {
            string str;
            const string charactersToEscape = "\"\\";
            if (!string.IsNullOrEmpty(expression))
            {
                var stringBuilder = new StringBuilder();
                foreach (var chr in expression)
                {
                    if (charactersToEscape.IndexOf(chr) >= 0)
                    {
                        stringBuilder.Append("\\");
                    }

                    stringBuilder.Append(chr);
                }

                str = stringBuilder.ToString();
            }
            else
            {
                str = expression;
            }

            return str;
        }
    }
}
