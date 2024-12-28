using Autofac;
using CommandLine;
using TagCloud;
using TagCloud.CloudLayouter;
using TagCloud.CloudLayouter.PointLayouter;
using TagCloud.CloudLayouter.PointLayouter.Generators;
using TagCloud.ImageGenerator;
using TagCloud.ImageSaver;
using TagCloud.WordsFilter;
using TagCloud.WordsReader;
using TagCloud.WordsReader.Readers;

namespace TagCloudClient;

internal static class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<ConsoleOptions>(args)
            .WithParsed(settings =>
            {
                var container = SettingsBuilder.BuildContainer(settings);
                var generator = container.Resolve<CloudGenerator>();
                Console.WriteLine("File saved in " + generator.GenerateTagCloud());
            });
    }
}