using System.Collections.Generic;

// SERVICE LOCATOR PATTERN
// stores and provides access to other services
public static class ServiceLocator
{
    private static Dictionary<System.Type, IService> lookUp = new();

    public static void Register<T>(T thing) where T : IService
    {
        lookUp[typeof(T)] = thing;
    }

    // grabs the service based on its type, other scripts access services without needing reference directly
    public static T Get<T>() where T : IService
    {
        return (T)lookUp[typeof(T)]; 
    }

    public static void ClearAll()
    {
        lookUp.Clear();
    }
}
