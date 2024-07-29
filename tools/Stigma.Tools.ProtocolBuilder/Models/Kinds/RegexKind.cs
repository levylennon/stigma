namespace Stigma.Tools.ProtocolBuilder.Models.Kinds;

public enum RegexKind
{
    Metadata,
    Namespace,
    Import,
    EnumProperty,
    PropertyPrimitive,
    PropertyObject,
    PropertyVector,
    PropertyVectorFieldWriteLength,
    PropertyVectorFieldWriteMethod,
    ReadMethodPrimitive,
    ReadVectorMethodObject,
    ReadVectorMethodProtocolManager,
    ReadMethodObjectProtocolManager,
    VarVectorLimitLength,
    ReadFlagMethod,
    ProtocolId,
    ThrowError
}