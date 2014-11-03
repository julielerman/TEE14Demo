namespace Shared.Interfaces {
  public interface IHandle<T> where T : IDomainEvent {
    void Handle(T contactUpdatedEvent);
  }
}