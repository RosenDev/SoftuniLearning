using System;

namespace SIS.WebServer.DependecyContainer
{
    public interface IServiceProvider
    {
        void Add<TSource, TDestination>()
            where TDestination : TSource;
        object CreateInstance(Type type);

        T CreateInstance<T>()
            where T : class, new();

    }
}