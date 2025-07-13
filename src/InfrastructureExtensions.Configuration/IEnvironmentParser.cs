namespace InfrastructureExtensions.Configuration;

public interface IEnvironmentParser
{
    object Parse(string value);
}