using SampleCode.IOC.Test.DependencyResolution;
using StructureMap;

namespace SampleCode.IOC.Test
{
    public static class TestBootstrapper
    {
        public static void TestServiceStructureMap()
        {
            ObjectFactory.Container.Dispose();
            ObjectFactory.Initialize(o => o.AddRegistry(new StructureMapRepositoryTestRegistry()));
            ObjectFactory.Initialize(o => o.AddRegistry(new StructureMapServiceTestRegistry()));
            ObjectFactory.Container.AssertConfigurationIsValid();
        }

        public static void TestRepositoryStructureMap()
        {
            ObjectFactory.Container.Dispose();
            ObjectFactory.Initialize(o => o.AddRegistry(new StructureMapRepositoryTestRegistry()));
            ObjectFactory.Container.AssertConfigurationIsValid();
        }
    }
}
