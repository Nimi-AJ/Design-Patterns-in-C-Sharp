using System;
using System.Text;

namespace DesignPatterns.BuilderPattern
{
    public class LifeWithoutBuilder
    {
        public LifeWithoutBuilder()
        {
        }

        public static void main()
        {
            var hello = "world";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");

            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);
        }
    }
}

