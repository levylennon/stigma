namespace Stigma.Tools.ProtocolBuilder.Services.Builders;

public interface IBuilder
{
    byte Priority { get; }

    void Build();
}