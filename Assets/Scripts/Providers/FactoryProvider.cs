public static class FactoryProvider<T> where T : GenericFactory, new()
{
    private static T factory;

    public static T GetFactory()
    {
        if(factory == null)
        {
            factory = new T();
        }

        return factory;
    }
}