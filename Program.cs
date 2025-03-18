try
{
    StreamReader sr = new StreamReader(@"..\..\..\data_example.dat");
    var line = sr.ReadLine();
    
    while (line != null)
    {
        Console.WriteLine(line);
        line = sr.ReadLine();
    }
}
finally
{
    Console.WriteLine("reading finished");
}