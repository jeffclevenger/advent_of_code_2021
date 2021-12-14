using System;
using System.Collections.Generic;
using System.IO;

class Program
{
  static void Main()
  {
    Input input = new Input("input.txt");
    int[] parsedInput = input.ParseInput();
    Solution solution = new Solution(parsedInput);
    Console.WriteLine(solution.RunSolution(1));
    Console.WriteLine(solution.RunSolution(3));
  }
}


class Solution
{
  private readonly int[] _input;

  public Solution(int[] input)
  {
    _input = input;
  }
  public int RunSolution(int windowSize)
  {
    Window window = new Window(windowSize);
    int count = 0;
    for (int i = 0; i < _input.Length - windowSize; i++)
    {
      if(window.CompAdjacentWindows(_input, i) == -1) count++;
    }
    return count;
  }
}

class Input
{
  private readonly string[] _lines;


  public Input(string filepath)
  {
    _lines = File.ReadAllLines(filepath);
  }

  public int[] ParseInput()
  {
    int[] parsedInput = new int[_lines.Length];
    for (int i = 0; i < _lines.Length; i++)
    {
        parsedInput[i] = int.Parse(_lines[i]);
    }
    return parsedInput;
  }
}

class Window
{
  private readonly int _windowSize;

  public Window(int windowSize)
  {
    _windowSize = windowSize;
  }

  public int SumWindow(int[] list, int startIndex )
  {
    int sum = 0;
    for (int i = 0; i < _windowSize; i++)
    {
        sum += list[startIndex + i];
    }

    return sum;
  }

  public int CompAdjacentWindows(int[] list, int startIndex, int offset = 1)
  {
    int firstWindow = SumWindow(list, startIndex);
    int secondWindow = SumWindow(list, startIndex + offset);
    if(firstWindow < secondWindow)
    {
      return -1;
    }
    else if(firstWindow == secondWindow)
    {
      return 0;
    }
    else
    {
      return 1;
    }
  }
}