using System;

namespace Shared.Interfaces {
  public interface IDomainEvent {
    DateTime DateTimeEventOccurred { get; }
  }
}