using Stigma.Core.IO.Text;
using Stigma.Tools.ProtocolBuilder.Models.Symbols;

namespace Stigma.Tools.ProtocolBuilder.Services.Renderers.Enums;

public sealed class EnumRenderer : IRenderer
{
    public string Render(ClassSymbol classSymbol)
    {
        var builder = new IndentedStringBuilder()
            .AppendLine("namespace {0};", classSymbol.Type.Namespace)
            .AppendLine()
            .AppendLine("public enum {0}", classSymbol.Type.Name)
            .AppendLine('{')
            .Indent();

        foreach (var property in classSymbol.Properties)
            if (property == classSymbol.Properties.Last())
                builder.AppendLineIndented("{0} = {1}", property.Name, property.Value!);
            else
                builder.AppendLineIndented("{0} = {1},", property.Name, property.Value!);

        return builder
            .UnIndent()
            .AppendLine('}')
            .ToString();
    }
}