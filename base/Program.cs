

internal class Program
{
    static void Main(string[] args)
    {
        dynamic a = new {x = 1,y=10};
        DrawPoint(a);
        Console.WriteLine("Hello, World!");
    }
    public class Point
    {
        public int x;
        public int y;
    }
    public static void DrawPoint(dynamic point) => 
        Console.WriteLine($"x:{point.x},y:{point.y}");
}
/*
 每个对象都是某个类的一个实例
 高内聚，低耦合
 */