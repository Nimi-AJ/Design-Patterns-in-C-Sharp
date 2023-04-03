using System;
namespace DesignPatterns.BuilderPattern
{
    public class Builder
    {
        public Builder()
        {
        }

        public static void main()
        {
            HtmlElement elem = new(null, null);
        }

        public class HtmlElement
        {
            public string Name, Text;
            public List<HtmlElement> Elements = new List<HtmlElement>();
            private const int indentSize = 2;

            public HtmlElement()
            {

            }

            public HtmlElement(string? name, string? text)
            {
                Name = name ?? throw new ArgumentException(nameof(name));
                Text = text ?? throw new ArgumentException(nameof(text));
            }


        }
    }
}

