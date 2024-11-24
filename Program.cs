using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"D:\ImpledgeTask\Input_02.txt";
        List<string> words = LoadWordsFromFile(filePath);
        if (words == null || words.Count == 0) return;
        FindLongestCompoundWords(words);
    }
    static List<string> LoadWordsFromFile(string filePath)
    {
        List<string> words = new List<string>();
        try
        {
            if (File.Exists(filePath))
            {
                words.AddRange(File.ReadLines(filePath));
            }
            else
            {
                Console.WriteLine("File does not exist at the specified path.");
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            
        }
        return words;
    }
    static void FindLongestCompoundWords(List<string> words)
    {
        HashSet<string> wordDict = new HashSet<string>(words);
        string longestCompound = string.Empty;
        string secondLongestCompound = string.Empty;

        Stopwatch stopwatch = Stopwatch.StartNew();

        foreach (var word in words)
        {
            if (IsCompoundWord(word, wordDict, new HashSet<string>()))
            {
                if (word.Length > longestCompound.Length)
                {
                    secondLongestCompound = longestCompound;
                    longestCompound = word;
                }
                else if (word.Length > secondLongestCompound.Length)
                {
                    secondLongestCompound = word;
                }
            }
        }

        stopwatch.Stop();
        Console.WriteLine("Longest Compound Word: " + longestCompound);
        Console.WriteLine("Second Longest Compound Word: " + secondLongestCompound);
        Console.WriteLine($"Time Taken: {stopwatch.ElapsedMilliseconds} ms");
    }
    static bool IsCompoundWord(string word, HashSet<string> wordDict, HashSet<string> visited)
    {
        if (visited.Contains(word)) return false;
        visited.Add(word);

        for (int i = 1; i < word.Length; i++)
        {
            string prefix = word.Substring(0, i);
            string suffix = word.Substring(i);

            if (wordDict.Contains(prefix) &&
                (wordDict.Contains(suffix) || IsCompoundWord(suffix, wordDict, visited)))
            {
                return true;
            }
        }

        return false;
    }
}
