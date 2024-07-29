namespace Stigma.Tools.ProtocolBuilder.Storages.Keywords;

public interface IKeywordStorage
{
    string GetMethod(string as3, string method, string replaceWith);

    string GetType(string method, string prefix);
}