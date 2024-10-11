using System;
using System.Collections;
using System.Collections.Generic;

class MapEnumerator : IEnumerator
{
    List<Tale> map;
    int position = -1;

    public MapEnumerator(List<Tale> map)
    {
        this.map = map;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Tale Current
    {
        get
        {
            if (position < 0 || position >= map.Count)
                throw new InvalidOperationException();
            return map[position];
        }
    }

    public bool MoveNext()
    {
        if (position < map.Count - 1)
        {
            position++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        position = -1;
    }
}
