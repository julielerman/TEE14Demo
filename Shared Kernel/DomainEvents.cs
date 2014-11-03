//Altered from Pluralsight Domain-Driven Design Fundamentals Course (bit.ly/PS-DDD)

using System;
using System.Collections.Generic;
using Shared.Interfaces;
using StructureMap;
using StructureMapContainer;

namespace Shared {
  /// <summary>
  ///   http://msdn.microsoft.com/en-gb/magazine/ee236415.aspx#id0400046
  /// </summary>
  public static class DomainEvents {
    [ThreadStatic] private static List<Delegate> actions;

    static DomainEvents() {
      Container = IocContainer.Container;
    }

    public static IContainer Container { get; set; }

    public static void Register<T>(Action<T> callback) where T : IDomainEvent {
      if (actions == null) {
        actions = new List<Delegate>();
      }
      actions.Add(callback);
    }

    public static void ClearCallbacks() {
      actions = null;
    }

    public static void Raise<T>(T args) where T : IDomainEvent {
      foreach (var handler in Container.GetAllInstances<IHandle<T>>()) {
        handler.Handle(args);
      }

      if (actions != null) {
        foreach (Delegate action in actions) {
          if (action is Action<T>) {
            ((Action<T>) action)(args);
          }
        }
      }
    }
  }
}