using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Interfaces;

namespace Shared {
  public abstract class WritableEntity : Entity {
    protected static ICollection<IDomainEvent> _events;

    protected WritableEntity() {
      CreatedDate = DateTime.Now.Date;
      _events = new List<IDomainEvent>();
    }

    public Byte[] RowVersion { get; private set; }
    protected DateTime CreatedDate { get; set; }
    protected DateTime ModifiedDate { get; set; }

    public ICollection<IDomainEvent> Events {
      get { return _events.ToList().AsReadOnly(); }
    }
  }
}