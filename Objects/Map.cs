using System;
using System.Collections;
using System.Net.Mail;
class Map : IEnumerable
{
    public List<Tale> map;
    public Tale this[int index]
    {
        get
        {
            if(index >= 0 && index < map.Count)
            {
                return map[index % map.Count];
            }
            throw new ArgumentOutOfRangeException("index");
        }
    }
    public Map()
    {
        map = new List<Tale>();
        InitMap();
    }
    public MapEnumerator GetEnumerator()
    {
        return new MapEnumerator(map);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void InitMap()
    {
        map.Add(new StartTale("Start"));
        map.Add(new TaleWithHouse("Mediterranean", 60, 2, 10, 30, 90, 160, 250, 50));
        map.Add(new CommunityChestTale());
        map.Add(new TaleWithHouse("Baltic", 60, 4, 20, 60, 180, 320, 450, 50));
        map.Add(new TaxTale("Income Tax", 200));
        map.Add(new RailroadTale());
        map.Add(new TaleWithHouse("Oriental", 100, 6, 30, 90, 270, 400, 550, 50));
        map.Add(new ChanceTale());
        map.Add(new TaleWithHouse("Euston", 100, 6, 30, 90, 270, 400, 550, 50));
        map.Add(new TaleWithHouse("Pentonville", 120, 8, 40, 100, 300, 450, 600, 50));
        map.Add(new ChanceTale());
        map.Add(new TaleWithHouse("Pall", 140, 10, 50, 150, 450, 625, 750, 100));
        map.Add(new UtilityTale("ECompany"));
        map.Add(new TaleWithHouse("Whitehall", 140, 10, 50, 150, 450, 625, 750, 100));
        map.Add(new TaleWithHouse("Virginia", 160, 12, 60, 180, 500, 700, 900, 100));
        map.Add(new RailroadTale());
        map.Add(new TaleWithHouse("St. James", 180, 14, 70, 200, 550, 750, 950, 100));
        map.Add(new CommunityChestTale());
        map.Add(new TaleWithHouse("Tennessee", 180, 14, 70, 200, 550, 750, 950, 100));
        map.Add(new TaleWithHouse("New York", 200, 16, 80, 220, 600, 800, 1000, 100));
        map.Add(new ChanceTale());
        map.Add(new TaleWithHouse("Kentucky", 220, 18, 90, 250, 700, 875, 1050, 150));
        map.Add(new ChanceTale());
        map.Add(new TaleWithHouse("Indiana", 220, 18, 90, 250, 700, 875, 1050, 150));
        map.Add(new TaleWithHouse("Illinois", 240, 20, 100, 300, 750, 925, 1100, 150));
        map.Add(new RailroadTale());
        map.Add(new TaleWithHouse("Atlantic", 260, 22, 110, 330, 800, 975, 1150, 150));
        map.Add(new TaleWithHouse("Ventnor", 260, 22, 110, 330, 800, 975, 1150, 150));
        map.Add(new UtilityTale("WaterWorks"));
        map.Add(new TaleWithHouse("Marvin", 280, 24, 120, 360, 850, 1025, 1200, 150));
        map.Add(new ChanceTale());
        map.Add(new TaleWithHouse("Pacific", 300, 26, 130, 390, 900, 1100, 1275, 200));
        map.Add(new TaleWithHouse("Carolina", 300, 26, 130, 390, 900, 1100, 1275, 200));
        map.Add(new CommunityChestTale());
        map.Add(new TaleWithHouse("Pennsylvania", 320, 28, 150, 450, 1000, 1200, 1400, 200));
        map.Add(new RailroadTale());
        map.Add(new ChanceTale());
        map.Add(new TaleWithHouse("Park", 350, 35, 175, 500, 1100, 1300, 1500, 200));
        map.Add(new TaxTale("Luxury Tax", 100));
        map.Add(new TaleWithHouse("Boardwalk", 400, 50, 200, 600, 1400, 1700, 2000, 200));
    }
}