using Seljmov.CS.Algorithms;

var random = new Random();
var number = (int) Math.Pow(2, 3);

var array1 = Enumerable.Range(0, number).Select(_ => random.Next(-number, number)).ToArray();
var array2 = array1.ToList();
var start1 = DateTime.Now;
Console.WriteLine("Start own");
BubbleSort.Do(array1);
Console.WriteLine($"End. Time -> {(DateTime.Now - start1).TotalMilliseconds} ms");

Console.WriteLine($"before ->\t {string.Join(", ", array2)}");
Console.WriteLine($"after ->\t {string.Join(", ", array1)}");