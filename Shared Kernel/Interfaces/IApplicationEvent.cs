namespace Shared.Interfaces {
  public interface IApplicationEvent : IDomainEvent {
    string EventType { get; }
  }
}