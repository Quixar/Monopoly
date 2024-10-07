using System;
using System.Collections;

class Map : IEnumerable
{
    List<Tale> map;

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Temp()
    {

        map[0] = new EventTale("Start");
        //map[0].OnTaleStep += (player) => 
    }
}