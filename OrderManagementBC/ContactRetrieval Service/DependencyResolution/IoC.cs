// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Shared.Interfaces;
using StructureMap;
using StructureMap.Graph;

namespace OrderManagement.DataMirroring.DependencyResolution {
  public static class IoC {
    private static IContainer _container;

    public static IContainer Container {
      get {
        if (_container == null) {
          Initialize();
        }
        return _container;
      }
    }

    public static void Initialize() {
      _container = new Container(cfg => cfg.Scan(scan =>
      {
        scan.TheCallingAssembly();
        scan.ConnectImplementationsToTypesClosing(typeof (IHandle<>));
      }));
    }
  }
}