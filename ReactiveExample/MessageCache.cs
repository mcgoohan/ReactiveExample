using System;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace ReactiveExample
{
    public class Message
    {
        public Message(string id)
        {
            MessageId = id;
        }
        
        public string MessageId { get; set; }
    }
    
    
    class MessageCache
    {
        public IObservable<Message> AddItem(string messageId)
        {
            var subject = new Subject<Message>();
            Task.Run(() => DoStuff(subject));
            return subject;
        }

        private void DoStuff(Subject<Message> subject)
        {
            try
            {
                foreach (var n in Enumerable.Range(1, 10))
                {
                    Thread.Sleep(1000);
                    subject.OnNext(new Message(n.ToString()));
                }
                subject.OnCompleted();
            }
            catch (Exception exception)
            {
                subject.OnError(exception);
            }
            finally
            {
                subject.Dispose();
            }
        }
    }
}