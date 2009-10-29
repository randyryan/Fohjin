using System;
using System.Collections.Generic;
using Fohjin.DDD.Domain;
using Fohjin.DDD.Events;

namespace Test.Fohjin.DDD
{
    [Specification]
    public abstract class AggregateRootTestFixture<TAggregateRoot> where TAggregateRoot : IEventProvider, new()
    {
        protected TAggregateRoot AggregateRoot;
        protected Exception CaughtException;
        protected IEnumerable<IDomainEvent> PublishedEvents;
        protected virtual IEnumerable<IDomainEvent> Given()
        {
            return new List<IDomainEvent>();
        }
        protected virtual void Finally() {}
        protected abstract void When();

        [Given]
        public void Setup()
        {
            CaughtException = new ThereWasNoExceptionButOneWasExpectedException();
            AggregateRoot = new TAggregateRoot();
            AggregateRoot.LoadFromHistory(Given());

            try
            {
                When();
                PublishedEvents = AggregateRoot.GetChanges();
            }
            catch (Exception exception)
            {
                CaughtException = exception;
            }
            finally
            {
                Finally();
            }
        }
    }
}