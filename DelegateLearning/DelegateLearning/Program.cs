using System;

class Program
{
    // 定义委托，并引用一个方法，这个方法需要获取一个int型参数返回void
    internal delegate void Feedback(int value);
    delegate void MyDel(int value);
    static void Main(string[] args)
    {
        MyDel del;//实例化
        del = new MyDel(PrintHigh);//实例化赋值，相当于给打其tag
        del(5);//执行委托

        StaticDelegateDemo();
        InstanceDelegateDemo();
        Console.ReadKey();
    }

    /// <summary>
    /// 静态调用
    /// </summary>
    private static void StaticDelegateDemo()
    {
        Console.WriteLine("---------委托调用静态方法------------");
        Counter(1, 10, null);
        Counter(1, 10, new Feedback(FeedbackToConsole));


    }
    /// <summary>
    /// 实例调用
    /// </summary>
    private static void InstanceDelegateDemo()
    {
        Console.WriteLine("---------委托调用实例方法------------");
        Program p = new Program();
        Counter(1, 10, null);
        Counter(1, 5, new Feedback(p.InstanceFeedbackToConsole));
    }
    /// <summary>
    /// 静态回调方法
    /// </summary>
    /// <param name="value"></param>
    private static void FeedbackToConsole(int value)
    {
        // 依次打印数字
        Console.WriteLine("Item=" + value);
    }
    /// <summary>
    /// 实例回调方法
    /// </summary>
    /// <param name="value"></param>
    private void InstanceFeedbackToConsole(int value)
    {
        Console.WriteLine("Item=" + value);
    }
    /// <summary>
    /// 使用此方法触发委托回调
    /// </summary>
    /// <param name="from">开始</param>
    /// <param name="to">结束</param>
    /// <param name="fb">委托引用</param>
    private static void Counter(int from, int to, Feedback fb)
    {
        for (int val = from; val <= to; val++)
        {
            // fb不为空，则调用回调方法
            if (fb != null)
            {
                fb(val);
                //fb.Invoke(val);
            }
            //fb?.Invoke(val); 简化版本调用
        }
    }

    static void PrintLow(int value)
    {
        Console.WriteLine("low");    
    }
    static void PrintHigh(int value)
    {
        Console.WriteLine("high");
    }
}