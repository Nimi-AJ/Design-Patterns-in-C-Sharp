using System;
using System.Text;

namespace DesignPatterns.BuilderPattern
{
    public class Builder
    {
        public Builder()
        {
        }

        public static void main()
        {
            //HtmlElement elem = new(null, null);
            Console.WriteLine("builder");
            HtmlBuilder builder = new HtmlBuilder("div");
            builder.AddChild("p", "paragraph1")
                .AddChild("p", "paragraph2")
                .AddChild("p", "paragraph1");
            Console.WriteLine(builder.ToString());
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

            public override string ToString()
            {
                return ToStringImpl(0);
            }

            private string ToStringImpl(int indent)
            {
                StringBuilder sb = new StringBuilder();
                string i = new string(' ', indentSize * indent);
                sb.AppendLine($"{i}<{Name}>");

                if (!string.IsNullOrWhiteSpace(Text))
                {
                    sb.Append(new String(' ', indentSize * (indent + 1)));
                    sb.AppendLine(Text);
                }

                foreach(HtmlElement e in Elements)
                {
                    sb.Append(e.ToStringImpl(indent + 1));
                }

                sb.AppendLine($"{i}</{Name}>");
                
                return sb.ToString();
            }
        }

        public class HtmlBuilder
        {
            private readonly string rootName;
            private HtmlElement root = new HtmlElement();

            public HtmlBuilder(string rootName)
            {
                this.rootName = rootName;
                root.Name = rootName;
            }

            public HtmlBuilder AddChild(string childName, string childText)
            {
                root.Elements.Add(new HtmlElement(childName, childText));
                return this;
            }

            public override string ToString()
            {
                Console.WriteLine("string");
                return root.ToString();
            }

            public void Clear()
            {
                root = new HtmlElement
                {
                    Name = rootName
                };
            }
        }
    }//
}
