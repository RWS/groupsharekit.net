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
            var charactersToEscape = "\"\\";
            if (!string.IsNullOrEmpty(expression) && !string.IsNullOrEmpty(charactersToEscape))
            {
                var stringBuilder = new StringBuilder();
                for (int i = 0; i < expression.Length; i++)
                {
                    char chr = expression[i];
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
