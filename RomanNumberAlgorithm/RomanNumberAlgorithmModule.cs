using Autofac;
using RomanNumberContract;

namespace RomanNumberAlgorithm
{
    public class RomanNumberAlgorithmModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Converter>().As<IConverter>();
        }
    }
}
