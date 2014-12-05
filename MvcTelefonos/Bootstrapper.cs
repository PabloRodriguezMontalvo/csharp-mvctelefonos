using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MvcTelefonos.Models;
using MvcTelefonos.Servicios;
using Unity.Mvc4;

namespace MvcTelefonos
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
   
        container.RegisterType<IServicios<Dispositivo>,Servicios<Dispositivo>>(
            new InjectionConstructor("http://webapitelefonos.azurewebsites.net/api/Dispositivo"));


        container.RegisterType<IServicios<Subastas>, Servicios<Subastas>>(
            new InjectionConstructor("http://webapitelefonos.azurewebsites.net/api/Subasta"));


        container.RegisterType<IServicios<Pujas>, Servicios<Pujas>>(
            new InjectionConstructor("http://webapitelefonos.azurewebsites.net/api/Pujas"));
    }
  }
}