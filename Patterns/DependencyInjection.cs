using System;

namespace Design_Patterns.Patterns
{
    public class DependencyInjection
    {
        private readonly IDependency _dependency;

        public DependencyInjection(IDependency dependency)
        {
            _dependency = dependency;
        }

        public void ToDepend()
        {
            _dependency.BeDependency(_dependency);
        }
    }

    public interface IDependency
    {
        void BeDependency(IDependency dependency);
    }

    public class Dependency : IDependency
    {
        public void BeDependency(IDependency dependency)
        {
            Console.WriteLine("I have a new dependency: " + dependency.ToString());
        }
    }
}