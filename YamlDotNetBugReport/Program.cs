using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YamlDotNetBugReport
{
    public static class YamlReader<T>
    {
        public static T Read(string filename)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .IgnoreUnmatchedProperties()
                .Build();

            using StreamReader sr = new(filename);
            var parser = new Parser(sr);
            var mergingParser = new MergingParser(parser);
            return deserializer.Deserialize<T>(mergingParser);
        }
    }

    public class Employee
    {
        public string Name { get; init; } = string.Empty;
        public string Title { get; init; } = string.Empty;
        public int Age { get; init; }
    }

    public class Company
    {
        public Employee[] Employees { get; init; } = Array.Empty<Employee>();
    }

    public class Program
    {
        private static int Main()
        {
            for (int i = 1; i <= 3; i++)
            {
                string yaml = $"example{i}.yaml";

                try
                {
                    Console.WriteLine($"~~~ Trying to parse {yaml} ~~~ ");

                    Company company = YamlReader<Company>.Read(yaml);
                    Console.WriteLine($"Employees: {company.Employees.Length}");
                    foreach (Employee e in company.Employees)
                        Console.WriteLine($"- Name: {e.Name}, Age: {e.Age}, Title: {e.Title}");

                    Console.WriteLine();
                    Console.WriteLine($"~~~ Done with {yaml} ~~~");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed parsing {yaml}! Exception message:");
                    Console.WriteLine(ex.Message);
                }
            }

            return 0;
        }
    }
}