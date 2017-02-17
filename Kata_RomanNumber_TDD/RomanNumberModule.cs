using Autofac;

namespace Kata_RomanNumber_TDD
{
    public class RomanNumberModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Converter>().As<IConverter>();
            builder.RegisterType<RomanToArabianNumberDecodingData>().As<IDecodingReferential<string, int>>();
            builder.RegisterType<RomanToArabianReferentialFactory>().As<IFactory<IDecodingReferential<string, int>>>();
            builder.RegisterType<ArabianToRomanNumberDecodingData>().As<IDecodingReferential<int, string>>();
            builder.RegisterType<ArabianToRomanReferentialFactory>().As<IFactory<IDecodingReferential<int, string>>>();
            builder.RegisterType<DecoderFactory<int, string>>().As<IFactory<int, IDecoder<int, string>>>();
            builder.RegisterType<DecoderFactory<string, int>>().As<IFactory<string, IDecoder<string, int>>>();
            builder.RegisterType<ArabianToRomanNumberDecoder>().As<IDecoder<int, string>>();
            builder.RegisterType<RomanToArabianNumberDecoder>().As<IDecoder<string, int>>();
            builder.RegisterType<RomanToArabianDecoderFactory>().As<IFactory<IDecodingReferential<string, int>, string, IDecoder<string, int>>>();
            builder.RegisterType<ArabianToRomanDecoderFactory>().As<IFactory<IDecodingReferential<int, string>, int, IDecoder<int, string>>>();
            builder.RegisterType<RomanToArabianNumberConverter>().UsingConstructor(typeof(IFactory<string, IDecoder<string, int>>), typeof(IConverter));
            builder.RegisterType<ArabianToRomanNumberConverter>().UsingConstructor(typeof(IFactory<int, IDecoder<int, string>>), typeof(IConverter));
        }
    }
}
