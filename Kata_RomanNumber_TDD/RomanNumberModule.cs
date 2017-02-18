using Autofac;
using RomanNumberContract;

namespace Kata_RomanNumber_TDD
{
    public class RomanNumberModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RomanToArabianNumberConverter>()
                   .UsingConstructor(typeof(IFactory<string, IDecoder<string, int>>), typeof(IConverter));
            builder.RegisterType<ArabianToRomanNumberConverter>()
                   .UsingConstructor(typeof(IFactory<int, IDecoder<int, string>>), typeof(IConverter), typeof(RomanNumber.RomanNumberBuilder));
            builder.RegisterType<RomanNumber.RomanNumberBuilder>()
                   .AsSelf();
        }
    }
}
