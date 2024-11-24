
# Overview

The Longest Compound Word Finder is a C# program designed to process a text file containing a list of words, determine compound words from the list, and identify the two longest compound words. This implementation is efficient and robust, handling edge cases like cyclic dependencies in word composition gracefully.


## Design Decisions and Approach

- File Handling: The program reads words from a specified text file. It ensures graceful handling of errors such as missing or unreadable files. 

- HashSet for Fast Lookups: A HashSet is used to store the words, enabling O(1) average-time complexity for lookups.

- Recursive Word Validation: Compound word detection uses recursion to check whether a word can be broken into valid smaller words.
- Optimization with Visited Words: A visited set prevents infinite loops during recursion when dealing with cyclic word dependencies.





## Algorithm
The algorithm employs a recursive backtracking approach:
1.	For each word, it splits the word into a prefix and a suffix at every possible position.
2.	The prefix is checked against the word dictionary (HashSet), and if valid, the suffix is either checked directly or recursively validated.
3.	Results are cached using a visited set to avoid re-evaluating words unnecessarily.



## Steps to execute program
	
-	Install .NET SDK on your system.
-	Ensure the input file exists at the specified path (D:\ImpledgeTask\Input_02.txt) or modify the code to point to a valid file path.

	File Format
- The input file should be a plain text file where each word appears on a new line.

	Build and Run
    ```
    cd folder_name
	dotnet build
    dotnet run	

   ``` 
   View Results

- The program will output the longest and second-longest compound words along with the time taken for processing.





## Key Components
-	Recursive Backtracking: Ensures that each possible word split is evaluated.
-	HashSet for Optimization: Reduces lookup times compared to other data structures.
-	Stopwatch: Measures execution time to monitor performance.


