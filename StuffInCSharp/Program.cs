using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuffInCSharp
{
    public abstract class User
    {
        protected User(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public class DeletedUser : User
    {
        public DateTime DeletionDate { get; private set; }

        public DeletedUser(ActiveUser user, DateTime deletionDate) : base(user.Name)
        {
            DeletionDate = deletionDate;
        }

        public ActiveUser UndeleteUser()
        {
            return new ActiveUser(this.Name, new List<Subscription>());
        }
    }

    public class ActiveUser : User
    {
        public List<Subscription> Subscriptions { get; private set; }

        public ActiveUser(string name, List<Subscription> subscriptions) : base(name)
        {
            Subscriptions = subscriptions;
        }


        public void AddSubscription(Subscription sub)
        {
            Subscriptions.Add(sub);
        }

        public DeletedUser DeleteUser(DateTime dateTime)
        {
            return new DeletedUser(this, dateTime);
        }
    }

    public class Subscription
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
