// See https://aka.ms/new-console-template for more information
using System;
using DesignPatterns.BuilderPattern;

namespace DesignPatterns
{
    public class Demo1
    {
        //public Demo()
        //{
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            //LifeWithoutBuilder.main();
            Builder.main();
            Console.ReadKey();
        }
    }
}
