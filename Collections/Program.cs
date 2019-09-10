using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = new List<string>()
            {
                "apple",
                "antelope",
                "blerg",
                "cantalope",
                "xylophone"
            };
            strings.Add("first");
            strings.Contains("second");

            var wordsBeginningWithA = strings
                .Where(currentString => currentString.StartsWith("a")); /*works like a filter*/

            var firstWord = strings.First(currentString => currentString.StartsWith("a")); /*returns first one in the list; allows null*/
            var firstWordRevised = strings.FirstOrDefault(currentString => currentString.StartsWith("a"));

            var secondWord = strings.Skip(1).Take(1);
            /*or, secondWord = strings.Skip(1).First();*/

            var anyWordsWithX = strings.Any(currentWord => currentWord.StartsWith("x"));

            var allWordsWithX = strings.All(currentWord => currentWord.StartsWith("x"));

            var transformed = strings.Select(item => $"{item} - transformed");
            var transformedAnimals = strings.Select(item => new Animal { Name = item });

            var letterAAnimals = strings
                .Where(currentString => currentString.StartsWith("a"))
                .Select(item => new Animal { Name = item });

            var groupedStrings = strings
                .GroupBy(currentString => currentString.First());

            foreach (var grouping in groupedStrings)
            {
                Console.WriteLine($"I'm looping over the {grouping.Key} group.");
                foreach (var currentString in grouping)
                {
                    Console.WriteLine($"{currentString} is in group {grouping.Key}.");
                }
            }

            strings.OrderBy(currentString => currentString.Last());
            strings.OrderByDescending(currentString => currentString.Last());

            foreach (var currentString in strings)
            {
                Console.WriteLine($"Current string is {currentString}.");
            }

            var alphabetWords = new Dictionary<char,string>(); /*optimized for reading, retrieves quickly*/
            alphabetWords.Add('a', "apple");
            alphabetWords.Add('b', "baby");
            alphabetWords.Add('c', "catastrophe");

            var seven = alphabetWords['c'];
            alphabetWords['c'] = "success";

            foreach (var alphabetWord in alphabetWords) /*each is a key-value pair*/
            {
                Console.WriteLine($"The current key is {alphabetWord.Key} and the value is {alphabetWord.Value}.");
            }

            /*var keyValues = new List<KeyValuePair<char, string>>();*/

            var hashset = new HashSet<Animal>(); /*slower for writes, faster for reads, only adds one value*/
            var animal = new Animal { Age = 12, Color = "golden", Name = "Rex", Type = "dog" };
            var tom = new Animal { Age = 2, Color = "red", Name = "Tom", Type = "cat" };
            var jerry = new Animal { Age = 6, Color = "white", Name = "Jerry", Type = "bird" };
            hashset.Add(animal);
            hashset.Add(animal);
            hashset.Add(animal);
            hashset.Add(animal);
            hashset.Add(tom);
            hashset.Add(jerry);
            hashset.Add(tom); /*ie, 3 values*/
        }
    }

    class Animal
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
    }
}
