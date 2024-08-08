using System.Xml;

namespace Characteristics.Expressive.SetupSermon.v2;

public class PackageFetcherTest : IAsyncLifetime
{
    private PackageFetcher fetcher;
    private Dictionary<string, object> downloads;
    private DirectoryInfo tempDir;


    [Fact]
    public void DownloadsAllResources()
    {
        fetcher.Download(downloads, tempDir, new MockConnector());
        Assert.Equal(4, tempDir.GetFiles().Length);
    }

    private DirectoryInfo CreateTempDir(string path)
    {
        var systemTempDir = Path.GetTempPath();
        tempDir = new DirectoryInfo(Path.Combine(systemTempDir, path));
        tempDir.Create();
        return tempDir;
    }

    private Dictionary<string, object> ExtractMissingDownloadsFrom(string path)
    {
        var db = new PresentationStorage();
        PresentationList list = null;
        try
        {
            using (var xml = GetType().Assembly.GetManifestResourceStream(path))
            {
                list = CreatePresentationListFrom(xml);
            }
        }
        catch (Exception e)
        {
            Assert.True(false, "Exception occurred: " + e.Message);
        }

        var downloads = list.GetResourcesMissingFrom(null, db);
        return fetcher.ExtractDownloads(downloads);
    }

    private PresentationList CreatePresentationListFrom(Stream stream)
    {
        var presentations = new PresentationList();
        presentations.Parse(ReadManifestFrom(stream));
        return presentations;
    }

    private XmlElement ReadManifestFrom(Stream stream)
    {
        return XOM.Parse(IO.StreamAsString(stream)).DocumentElement;
    }

    public Task InitializeAsync()
    {
        fetcher = new PackageFetcher();
        tempDir = CreateTempDir("downloads");
        downloads = ExtractMissingDownloadsFrom("/manifest.xml");
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        IO.Delete(tempDir);
        return Task.CompletedTask;
    }
}