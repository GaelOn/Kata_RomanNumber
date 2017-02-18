using Autofac;
using RomanNumberContract;

namespace RomanNumberData
{
    public class RomanNumberDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RomanUnitRepository>().As<IRomanNumberRepository>();
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
        }
    }
}
