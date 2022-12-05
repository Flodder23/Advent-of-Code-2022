# Advent-of-Code-2022
2022's edition of Advent of Code solved in C# (.NET)

Easiest way to run this is probably to create a C# .NET project in Visual Studio and copy the files in.

The `main.cs` file contains the program which gathers all the solutions, runs the latest one and asks if you want it to run all the solutions, as well as providing the abstract `Day` class.

The solution files are in folders labelled with the corresponding day number, and include
-	a `main_xx.cs` file with the main class declaration for that day and any more generic methods used in that day,
-	`input_parse_xx.cs`, `part1_xx` and `part2_xx` files containing the corresponding class methods,
-	 and `input_xx.txt` containing the raw input.

The folder for day 0 is a template folder to allow for easier creation of new days.
This is also included in the array `days` of `Day` objects because it makes day number `x` correspond to `days[x]` instead of `days[x-1]`.