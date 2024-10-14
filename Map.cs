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
        map[0] = new StartTale("Start");
        map[1] = new TaleWithHouse("Mediterranean", 60, 2, 10, 30, 90, 160, 250, 50);
        map[2] = new CommunityChestTale();
        map[3] = new TaleWithHouse("Baltic", 60, 4, 20, 60, 180, 320, 450, 50);
        map[4] = new TaxTale("Income Tax", 200);
        map[5] = new RailroadTale();
        map[6] = new TaleWithHouse("Oriental", 100, 6, 30, 90, 270, 400, 550, 50);
        map[7] = new ChanceTale();
        map[8] = new TaleWithHouse("Euston", 100, 6, 30, 90, 270, 400, 550, 50);
        map[9] = new TaleWithHouse("Pentonville", 120, 8, 40, 100, 300, 450, 600, 50);
        map[10] = new JailTale("Jale");
        map[11] = new TaleWithHouse("Pall", 140, 10, 50, 150, 450, 625, 750, 100);
        map[12] = new UtilityTale("ECompany");
        map[13] = new TaleWithHouse("Whitehall", 140, 10, 50, 150, 450, 625, 750, 100);
        map[14] = new TaleWithHouse("Virginia ", 160, 12, 60, 180, 500, 700, 900, 100);
        map[15] = new RailroadTale();
        map[16] = new TaleWithHouse("St. James", 180, 14, 70, 200, 550, 750, 950, 100);
        map[17] = new CommunityChestTale();
        map[18] = new TaleWithHouse("Tennessee", 180, 14, 70, 200, 550, 750, 950, 100);
        map[19] = new TaleWithHouse("New York", 200, 16, 80, 220, 600, 800, 1000, 100);
        map[20] = new ParkingTale("Parking");
        map[21] = new TaleWithHouse("Kentucky", 220, 18, 90, 250, 700, 875, 1050, 150);
        map[22] = new ChanceTale()
        map[23] = new TaleWithHouse("Indiana", 220, 18, 90, 250, 700, 875, 1050, 150);
        map[24] = new TaleWithHouse("Illinois", 240, 20, 100, 300, 750, 925, 1100, 150);
        map[25] = new RailroadTale();
        map[26] = new TaleWithHouse("Atlantic", 260, 22, 110, 330, 800, 975, 1150, 150);
        map[27] = new TaleWithHouse("Ventnor", 260, 22, 110, 330, 800, 975, 1150, 150);
        map[28] = new UtilityTale("WaterWokrs");
        map[29] = new TaleWithHouse("Marvin", 280, 24, 120, 360, 850, 1025, 1200, 150);
        map[30] = new JailTale("Jale");
        map[31] = new TaleWithHouse("Pacific", 300, 26, 130, 390, 900, 1100, 1275, 200);
        map[32] = new TaleWithHouse("Carolina", 300, 26, 130, 390, 900, 1100, 1275, 200);
        map[33] = new CommunityChestTale();
        map[34] = new TaleWithHouse("Pennsylvania", 320, 28, 150, 450, 1000, 1200, 1400, 200);
        map[35] = new RailroadTale();
        map[36] = new ChanceTale();
        map[37] = new TaleWithHouse("Park", 350, 35, 175, 500, 1100, 1300, 1500, 200);
        map[38] = new TaxTale("Luxury Tax", 100);
        map[39] = new TaleWithHouse("Boardwalk", 400, 50, 200, 600, 1400, 1700, 2000, 200);
    }
}