using System;

namespace ReactiveExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var messageCache = new MessageCache();
            
            var observable = messageCache.AddItem("123");

            observable.Subscribe(
                message => Console.WriteLine("Message Expired:  {0}", message.MessageId));
        }
    }
}