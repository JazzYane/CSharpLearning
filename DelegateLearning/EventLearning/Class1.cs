using System.Windows;
using System.Timers;
using System.Windows.Input;
using System;

namespace SimpleEvent
{
    public class WorkElement : FrameworkElement
    {
        public WorkElement()
        {
            this.MouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseLeftButtonDown);
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 鼠标单击函数内容
            // 获取鼠标点击位置
            Point pt = e.GetPosition((UIElement)sender);
            return;
        }

        private void OnDoubleMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 鼠标双击函数内容
            return;
        }

        private void Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (e.ClickCount == 1)
            {
                // 单击
                var timer = new System.Timers.Timer(200);
                timer.AutoReset = false;
                timer.Elapsed += new ElapsedEventHandler((o, ex) => element.Dispatcher.Invoke(new Action(() =>
                {
                    var timer2 = (System.Timers.Timer)element.Tag;
                    timer2.Stop();
                    timer2.Dispose();
                    // 调用单击函数
                    OnMouseLeftButtonDown(element, e);
                })));
                timer.Start();
                element.Tag = timer;
            }
            if (e.ClickCount > 1)
            {
                // 双击
                var timer = element.Tag as System.Timers.Timer;
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    // 调用双击函数
                    OnDoubleMouseLeftButtonDown(sender, e);
                }
            }
        }
    }


}
