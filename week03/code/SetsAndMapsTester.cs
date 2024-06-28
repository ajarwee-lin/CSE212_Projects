using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMapsTester {
    public static void Run() {
        // Problem 1: Find Pairs with Sets
        Console.WriteLine("\n=========== Finding Pairs TESTS ===========");
        DisplayPairs(new[] { "am", "at", "ma", "if", "fi" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "bc", "cd", "de", "ba" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ba", "ac", "ad", "da", "ca" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ac" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "aa", "ba" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "23", "84", "49", "13", "32", "46", "91", "99", "94", "31", "57", "14" });

        // Problem 2: Degree Summary
        Console.WriteLine("\n=========== Census TESTS ===========");
        Console.WriteLine(string.Join(", ", SummarizeDegrees("census.txt")));

        // Problem 3: Anagrams
        Console.WriteLine("\n=========== Anagram TESTS ===========");
        Console.WriteLine(IsAnagram("CAT", "ACT"));
        Console.WriteLine(IsAnagram("DOG", "GOOD"));
        Console.WriteLine(IsAnagram("AABBCCDD", "ABCD"));
        Console.WriteLine(IsAnagram("ABCCD", "ABBCD"));
        Console.WriteLine(IsAnagram("BC", "AD"));
        Console.WriteLine(IsAnagram("Ab", "Ba"));
        Console.WriteLine(IsAnagram("A Decimal Point", "Im a Dot in Place"));
        Console.WriteLine(IsAnagram("tom marvolo riddle", "i am lord voldemort"));
        Console.WriteLine(IsAnagram("Eleven plus Two", "Twelve Plus One"));
        Console.WriteLine(IsAnagram("Eleven plus One", "Twelve Plus One"));

        // Problem 4: Maze
        Console.WriteLine("\n=========== Maze TESTS ===========");
        Dictionary<(int, int), bool[]> map = SetupMazeMap();
        var maze = new Maze(map);
        maze.ShowStatus();
        maze.MoveUp();
        maze.MoveLeft();
        maze.MoveRight();
        maze.MoveRight();
        maze.MoveDown();
        maze.MoveDown();
        maze.MoveDown();
        maze.MoveRight();
        maze.MoveRight();
        maze.MoveUp();
        maze.MoveRight();
        maze.MoveDown();
        maze.MoveLeft();
        maze.MoveDown();
        maze.MoveRight();
        maze.MoveDown();
        maze.MoveDown();
        maze.MoveRight();
        maze.ShowStatus();

        // Problem 5: Earthquake
        Console.WriteLine("\n=========== Earthquake TESTS ===========");
        EarthquakeDailySummary();
    }

    private static void DisplayPairs(string[] words) {
        var set = new HashSet<string>();
        foreach (var word in words) {
            var reversed = new string(word.Reverse().ToArray());
            if (set.Contains(reversed)) {
                Console.WriteLine($"{reversed} & {word}");
            } else {
                set.Add(word);
            }
        }
    }

    private static Dictionary<string, int> SummarizeDegrees(string filename) {
        var degrees = new Dictionary<string, int>();
        try {
            foreach (var line in File.ReadLines(filename)) {
                var fields = line.Split(",");
                var degree = fields[3];
                if (degrees.ContainsKey(degree)) {
                    degrees[degree]++;
                } else {
                    degrees[degree] = 1;
                }
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        return degrees;
    }

    private static bool IsAnagram(string word1, string word2) {
        var dict = new Dictionary<char, int>();
        foreach (var ch in word1.ToLower().Replace(" ", "")) {
            if (dict.ContainsKey(ch)) {
                dict[ch]++;
            } else {
                dict[ch] = 1;
            }
        }
        foreach (var ch in word2.ToLower().Replace(" ", "")) {
            if (!dict.ContainsKey(ch) || dict[ch] == 0) {
                return false;
            } else {
                dict[ch]--;
            }
        }
        return dict.Values.All(x => x == 0);
    }

    private static Dictionary<(int, int), bool[]> SetupMazeMap() {
        Dictionary<(int, int), bool[]> map = new() {
            { (1, 1), new[] { false, true, false, true } },
            { (1, 2), new[] { false, true, true, false } },
            { (1, 3), new[] { false, false, false, false } },
            { (1, 4), new[] { false, true, false, true } },
            { (1, 5), new[] { false, false, true, true } },
            { (1, 6), new[] { false, false, true, false } },
            { (2, 1), new[] { true, false, false, true } },
            { (2, 2), new[] { true, false, true, true } },
            { (2, 3), new[] { false, false, true, true } },
            { (2, 4), new[] { true, true, true, false } },
            { (2, 5), new[] { false, false, false, false } },
            { (2, 6), new[] { false, false, false, false } },
            { (3, 1), new[] { false, false, false, false } },
            { (3, 2), new[] { false, false, false, false } },
            { (3, 3), new[] { false, false, false, false } },
            { (3, 4), new[] { true, true, false, true } },
            { (3, 5), new[] { false, false, true, true } },
            { (3, 6), new[] { false, false, true, false } },
            { (4, 1), new[] { false, true, false, false } },
            { (4, 2), new[] { false, false, false, false } },
            { (4, 3), new[] { false, true, false, true } },
            { (4, 4), new[] { true, true, true, false } },
            { (4, 5), new[] { false, false, false, false } },
            { (4, 6), new[] { false, false, false, false } },
            { (5, 1), new[] { true, true, false, true } },
            { (5, 2), new[] { false, false, true, true } },
            { (5, 3), new[] { true, true, true, true } },
            { (5, 4), new[] { true, false, true, true } },
            { (5, 5), new[] { false, false, true, true } },
            { (5, 6), new[] { false, true, true, false } },
            { (6, 1), new[] { true, false, false, false } },
            { (6, 2), new[] { false, false, false, false } },
            { (6, 3), new[] { true, false, false, false } },
            { (6, 4), new[] { false, false, false, false } },
            { (6, 5), new[] { false, false, false, false } },
            { (6, 6), new[] { true, false, false, false } }
        };
        return map;
    }

    private static void EarthquakeDailySummary() {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        try {
            using var client = new HttpClient();
            using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(jsonStream, options);

            foreach (var feature in featureCollection.Features) {
                Console.WriteLine($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error retrieving earthquake data: {ex.Message}");
        }
    }
}

public class FeatureCollection {
    public List<Feature> Features { get; set; }
}

public class Feature {
    public Properties Properties { get; set; }
}

public class Properties {
    public string Place { get; set; }
    public double Mag { get; set; }
}

public class Maze {
    private Dictionary<(int, int), bool[]> _map;
    private (int, int) _position;

    public Maze(Dictionary<(int, int), bool[]> map) {
        _map = map;
        _position = (1, 1);
    }

    public void MoveUp() {
        if (_map[_position][0]) {
            _position = (_position.Item1 - 1, _position.Item2);
        } else {
            Console.WriteLine("Move Up blocked.");
        }
    }

    public void MoveRight() {
        if (_map[_position][1]) {
            _position = (_position.Item1, _position.Item2 + 1);
        } else {
            Console.WriteLine("Move Right blocked.");
        }
    }

    public void MoveDown() {
        if (_map[_position][2]) {
            _position = (_position.Item1 + 1, _position.Item2);
        } else {
            Console.WriteLine("Move Down blocked.");
        }
    }

    public void MoveLeft() {
        if (_map[_position][3]) {
            _position = (_position.Item1, _position.Item2 - 1);
        } else {
            Console.WriteLine("Move Left blocked.");
        }
    }

    public void ShowStatus() {
        Console.WriteLine($"Current position: {_position.Item1}, {_position.Item2}");
    }
}
