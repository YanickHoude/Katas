﻿namespace CharacterCopyKata;

public class Copier
{
    private IDestination _destination;
    private ISource _source;

    public Copier(ISource source, IDestination destination)
    {
        this._destination = destination;
        this._source = source;
    }

    public void Copy()
    {
        char c = _source.ReadChar();
        while (c != '\n')
        {
            _destination.WriteChar(c);
            c = _source.ReadChar();
        }
        //throw new NotImplementedException();
    }
}

public interface IDestination
{
    void WriteChar(char v);
}

public interface ISource
{
    char ReadChar();
}
