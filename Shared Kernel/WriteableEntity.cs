using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Interfaces;

namespace Shared {
  public abstract class WritableEntity : Entity
  {
    protected static ICollection<IDomainEvent> _events;

    protected WritableEntity() {
      ModifiedDate = DateTime.Now;
      CreatedDate = DateTime.Now.Date;
      _events = new List<IDomainEvent>();
    }

    public Byte[] RowVersion { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime ModifiedDate { get; private set; }
    public void SetModifiedDate() {
      ModifiedDate = DateTime.Now;
    }
    public ICollection<IDomainEvent> Events {
      get { return _events.ToList().AsReadOnly(); }
    }
  }


}