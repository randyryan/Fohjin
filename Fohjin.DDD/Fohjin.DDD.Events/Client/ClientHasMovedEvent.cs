using System;

namespace Fohjin.DDD.Events.Client
{
    [Serializable]
    public class ClientHasMovedEvent : DomainEvent
    {
        public Guid ClientId { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }

        public ClientHasMovedEvent(Guid clientId, string street, string streetNumber, string postalCode, string city)
        {
            ClientId = clientId;
            Street = street;
            StreetNumber = streetNumber;
            PostalCode = postalCode;
            City = city;
        }
    }
}