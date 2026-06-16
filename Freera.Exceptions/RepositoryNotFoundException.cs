namespace Freera.Exceptions
{
    public class RepositoryNotFoundException(Type repoType): Exception($"A repository of type {repoType.FullName} does not exist.")
    {
    }
}
