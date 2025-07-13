namespace InfrastructureExtensions.Core;

public static class TypeExtensions
{
    public static bool HasGenericTypeDefinition(this Type objectType, Type definitionType)
    {
        var testedTypes = definitionType.IsInterface ? objectType.GetInterfaces() : throw new NotImplementedException();
        
        return testedTypes.Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == definitionType);
    }
    
    public static bool AnyGenericTypeDefinition(this Type objectType, params Type[] definitionTypes)
    {
        var testedTypes =
            definitionTypes.SelectMany(t => t.IsInterface ? t.GetInterfaces() : throw new NotImplementedException());
        
        return testedTypes.Any(i => i.IsGenericType && definitionTypes.Contains(i.GetGenericTypeDefinition()));
    }
}