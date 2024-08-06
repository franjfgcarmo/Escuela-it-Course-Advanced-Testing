namespace Characteristics.Readable.SplitPersonality.V1;

public class Configuration
{
    public void ProcessArguments(String[] args)
    {
        // TODO Auto-generated method stub
        if (args is [])
            throw new ArgumentException();
    }

    public String GetFileName()
    {
        // TODO Auto-generated method stub
        return null;
    }

    public bool IsDebuggingEnabled()
    {
        // TODO Auto-generated method stub
        return true;
    }

    public bool IsWarningsEnabled()
    {
        // TODO Auto-generated method stub
        return true;
    }

    public bool IsVerbose()
    {
        // TODO Auto-generated method stub
        return true;
    }

    public bool ShouldShowVersion()
    {
        // TODO Auto-generated method stub
        return true;
    }
}