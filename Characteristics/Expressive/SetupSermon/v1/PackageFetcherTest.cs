namespace Characteristics.Expressive.SetupSermon.v1;

using System.Collections.Generic;
using System.IO;
using Xunit;

public class PackageFetcherTest
{
    private PackageFetcher fetcher;
    private Dictionary<string, object> downloads;
    private DirectoryInfo tempDir;

    public PackageFetcherTest()
    {
        string systemTempDir = Path.GetTempPath();
        tempDir = new DirectoryInfo(Path.Combine(systemTempDir, "downloads"));
        tempDir.Create();
        string filename = "/manifest.xml"; // Adjust the path to your manifest file
        using (Stream xml = GetType().Assembly.GetManifestResourceStream(filename))
        {
            var manifest = XOM.Parse(IO.StreamAsString(xml));
            PresentationList presentations = new PresentationList();
            presentations.Parse(manifest.DocumentElement);
            PresentationStorage db = new PresentationStorage();
            List<object> list = presentations.GetResourcesMissingFrom(null, db);
            fetcher = new PackageFetcher();
            downloads = fetcher.ExtractDownloads(list);
        }
    }

    [Fact]
    public void DownloadsAllResources()
    {
        fetcher.Download(downloads, tempDir, new MockConnector());
        Assert.Equal(4, tempDir.GetFiles().Length);
    }
}