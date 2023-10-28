using Seljmov.CS;

var random = new Random();
var number = (int) Math.Pow(2, 10);

var array1 = Enumerable.Range(0, number).Select(_ => random.Next(-number, number)).ToArray();
var start1 = DateTime.Now;
Console.WriteLine("Start own");
Sort.MergeSort(array1);
Console.WriteLine($"End. Time -> {(DateTime.Now - start1).TotalMilliseconds} ms");