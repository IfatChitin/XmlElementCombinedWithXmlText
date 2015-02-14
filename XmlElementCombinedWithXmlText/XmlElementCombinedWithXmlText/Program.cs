using System;
using System.Collections.ObjectModel;

namespace XmlElementTextAndNewLines
{
    class Program
    {
        static void Main()
        {
            var person = new Person
            {
                Name = "name",
                Children =
                    new Collection<Person>
                    {
                        new Person {Name = "child1", Text = "child1Text"},
                        new Person {Name = "child2", Text = "child2Text"}
                    }
            };

            var personWithoutText = person.Serialize();
            Console.WriteLine("Person without text attribute has new lines:");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(personWithoutText);
            Console.WriteLine();

            person.Text = "text";

            var personWithTextAttribue = person.Serialize();
            Console.WriteLine("Person with text attribute has no new lines:");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(personWithTextAttribue);

            Console.ReadLine();
        }
    }
}

