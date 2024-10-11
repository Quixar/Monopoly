using System;
using System.Collections;
using System.Net.Mail;

class Map : IEnumerable
{
    public List<Tale> map = new List<Tale>();

    public Tale this[int index]
    {
        get
        {
            if(index >= 0 && index < map.Count)
            {
                return map[index];
            }
            throw new ArgumentOutOfRangeException("Invalid index");
        }
    }

    public MapEnumerator GetEnumerator()
    {
        return new MapEnumerator(map);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Temp()
    {

        map[0] = new EventTale("Start");
    }
}