using System.Text.RegularExpressions;
using Stigma.Tools.ProtocolBuilder.Models.Kinds;

namespace Stigma.Tools.ProtocolBuilder.Storages.Regexes;

public interface IRegexStorage
{
    bool IsMatch(RegexKind kind, string input);

    Match Match(RegexKind kind, string input);

    IEnumerable<Match> Matches(RegexKind kind, string input);
}