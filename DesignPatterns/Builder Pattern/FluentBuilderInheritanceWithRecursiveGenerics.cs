using System;
namespace DesignPatterns.BuilderPattern
{
    public class FluentBuilderInheritanceWithRecursiveGenerics
    {
        public FluentBuilderInheritanceWithRecursiveGenerics()
        {
        }

        public static void main()
        {
            Person p = Person.New.Called("Jane").WorksAs("Pilot").HasSalary(19999).Build();
            Console.WriteLine(p.ToString());
        }

        public class Person
        {
            public string Name;
            public string Position;
            public int Salary;
            public override string ToString()
            {
                return $"{nameof(Name)} : {Name}, {nameof(Position)} : {Position}, {nameof(Salary)} : {Salary}";
            }

            public class Builder : PersonSalaryBuilder<Builder>
            {

            }

            public static Builder New => new Builder(); //returns new builder
        }

        public abstract class PersonBuilder
        {
            protected Person person = new Person();

            public Person Build()
            {
                return person;
            }
        }

        public class PersonInfoBuilder<T> : PersonBuilder where T : PersonInfoBuilder<T>
        {
            public T Called(string name)
            {
                person.Name = name;
                return (T) this;
            }
        }

        public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>> where T : PersonJobBuilder<T>
        {
            public T WorksAs(string position)
            {
                person.Position = position;
                return (T) this;
            }
        }

        public class PersonSalaryBuilder<T> : PersonJobBuilder<PersonSalaryBuilder<T>> where T : PersonSalaryBuilder<T>
        {
            public T HasSalary(int salary)
            {
                person.Salary = salary;
                return (T) this;
            }
        }
    }//
}

