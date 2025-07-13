using System.Collections;

namespace InfrastructureExtensions.Core;

public static class LinqExceptionExtensions
{
    public static T ThrowIfEmpty<T>(this T collection, Func<Exception> whenEmptyException)
        where T: ICollection
    {
        if (collection.Count == 0)
            throw whenEmptyException.Invoke();

        return collection;
    }
    
    public static T ThrowIfTrue<T>(this T obj, Func<Exception> whenTrueException, Func<T, bool> conditionHandler)
    {
        if (conditionHandler.Invoke(obj))
            throw whenTrueException.Invoke();
        
        return obj;
    }
    
    public static T ThrowIfFalse<T>(this T obj, Func<Exception> whenFalseException, Func<T, bool> conditionHandler)
    {
        if (!conditionHandler.Invoke(obj))
            throw whenFalseException.Invoke();
        
        return obj;
    }
}