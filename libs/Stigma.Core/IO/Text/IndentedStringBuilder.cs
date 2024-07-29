using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stigma.Core.IO.Text;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class IndentedStringBuilder
{
    private readonly StringBuilder _builder;

    private int _indentationLevel;

    public int Length =>
        _builder.Length;

    public IndentedStringBuilder()
    {
        _builder = new StringBuilder();
    }

    public IndentedStringBuilder Reset()
    {
        _builder.Clear();
        _indentationLevel = 0;
        return this;
    }

    public IndentedStringBuilder Indent()
    {
        _indentationLevel++;
        return this;
    }

    public IndentedStringBuilder UnIndent()
    {
        if (_indentationLevel > 0)
            _indentationLevel--;
        return this;
    }

    public IndentedStringBuilder Remove(int startIndex, int length)
    {
        _builder.Remove(startIndex, length);
        return this;
    }

    public IndentedStringBuilder Insert(int index, char value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IndentedStringBuilder Insert(int index, string value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IndentedStringBuilder Insert(int index, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object[] args)
    {
        _builder.Insert(index, string.Format(format, args));
        return this;
    }

    public IndentedStringBuilder InsertIndented(int index, char value)
    {
        _builder
            .Insert(index, new string('\t', _indentationLevel))
            .Insert(index + _indentationLevel, value);
        return this;
    }

    public IndentedStringBuilder InsertIndented(int index, string value)
    {
        _builder
            .Insert(index, new string('\t', _indentationLevel))
            .Insert(index + _indentationLevel, value);
        return this;
    }

    public IndentedStringBuilder InsertIndented(int index, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object[] args)
    {
        _builder
            .Insert(index, new string('\t', _indentationLevel))
            .Insert(index + _indentationLevel, string.Format(format, args));
        return this;
    }

    public IndentedStringBuilder Append(char value)
    {
        _builder.Append(value);
        return this;
    }

    public IndentedStringBuilder AppendIndented(char value)
    {
        _builder
            .Append(new string('\t', _indentationLevel))
            .Append(value);
        return this;
    }

    public IndentedStringBuilder Append(string value)
    {
        _builder.Append(value);
        return this;
    }

    public IndentedStringBuilder Append([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object[] args)
    {
        _builder.AppendFormat(format, args);
        return this;
    }

    public IndentedStringBuilder AppendIndented(string value)
    {
        _builder
            .Append(new string('\t', _indentationLevel))
            .Append(value);
        return this;
    }

    public IndentedStringBuilder AppendIndented([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object[] args)
    {
        _builder
            .Append(new string('\t', _indentationLevel))
            .AppendFormat(format, args);
        return this;
    }

    public IndentedStringBuilder AppendLine()
    {
        _builder.AppendLine();
        return this;
    }

    public IndentedStringBuilder AppendLine(char value)
    {
        _builder
            .Append(value)
            .AppendLine();
        return this;
    }

    public IndentedStringBuilder AppendLine(string value)
    {
        _builder
            .Append(value)
            .AppendLine();
        return this;
    }

    public IndentedStringBuilder AppendLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object[] args)
    {
        _builder
            .AppendFormat(format, args)
            .AppendLine();
        return this;
    }

    public IndentedStringBuilder AppendLineIndented(char value)
    {
        _builder
            .Append(new string('\t', _indentationLevel))
            .Append(value)
            .AppendLine();
        return this;
    }

    public IndentedStringBuilder AppendLineIndented(string value)
    {
        _builder
            .Append(new string('\t', _indentationLevel))
            .Append(value)
            .AppendLine();
        return this;
    }

    public IndentedStringBuilder AppendLineIndented([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object[] args)
    {
        _builder
            .Append(new string('\t', _indentationLevel))
            .AppendFormat(format, args)
            .AppendLine();
        return this;
    }

    public override string ToString()
    {
        return _builder.ToString();
    }
}