namespace mintazh2
{
    public class Time : IComparable<Time>
    {
        int hour;
        int minute;
        int second;
        //egészeket tárol
        public int Hour
        {
            get => hour;
            set
            {
                if (value < 0 || value > 3)
                    throw new TimeException("invalid hour");
                hour = value;
            }
        }
        //=> : lambda operátor, amit lambda kifejezésekhez (más néven névtelen függvényekhez) használunk.
        //„úgynevezett, mint” vagy „azt csinálja, hogy”
        // new kulcsszó: új példány/operátor létrehozás
        public int Minute
        {
            get => minute;
            set
            {
                if (value < 0 || value > 59)
                    throw new TimeException("invalid minute");
                minute = value;
            }
        }

        public int Second
        {
            get => second;
            set
            {
                if (value < 0 || value > 59)
                    throw new TimeException("invalid second");
                second = value;
            }
        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
        //public → Ez azt jelenti, hogy a konstruktor mindenhol elérhető (nem privát vagy korlátozott).

        //Time(...) → Ez a konstruktor neve, és ugyanaz, mint az osztály neve, ezért tudjuk, hogy ez nem egy sima metódus, hanem konstruktor.

        //int hour, int minute, int second → Ezek a bemeneti paraméterek, amiket meg kell adni, amikor példányosítunk egy Time objektumot.

        // Hour = hour; → a Hour nevű változóba beleteszi a hour paraméter értékét.

        ///PascalCase: nagy kezdőbetű-->osztályok, metódusok, tulajdonságok, konstruktorok nevei
        //camelCase: kis kezdőbetű-->változók és metódusparaméterek nevei
        public Time(int minute, int second)
        {
            Hour = 0;
            Minute = minute;
            Second = second;
        }
        //public Time(int minute, int second) : this(0, minute, second) { }
        public override string ToString()
        {
            if (hour >= 1)
                return $"{hour.ToString().PadLeft(2, '0')}:{minute.ToString().PadLeft(2, '0')}:{second.ToString().PadLeft(2, '0')} ";
            return $"{minute.ToString().PadLeft(2, '0')}:{second.ToString().PadLeft(2, '0')} ";
        }
        //override: felülírok egy örökölt metódust/tulajdonságot
        //miért kell felülírni? : 
        //Ha egy szülőosztályban (base class) van egy metódus, de a gyerekosztályban máshogy szeretnéd, hogy működjön, akkor azt felülírhatod override-dal.
        public static Time Parse(string time)
        {
            string[] parts = time.Split(':');
            try
            {
                if (parts.Length == 2)
                    return new Time(int.Parse(parts[0]), int.Parse(parts[1]));
                if (parts.Length == 3)
                    return new Time(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            }
            catch(Exception)

            {
                throw new TimeException("nem megfelelő időformátum");
            }
            throw new TimeException("nem idő objektumot kaptunk");
        }        
        //A . osztályok vagy objektumok tulajdonságainak, metódusainak és egyéb tagjainak elérésére szolgál.
        // Split kulcszó: parszolás/szétválasztás
        //A try-blokk: amikor olyan kódot írunk, amely esetleg hibát (kivételeket) okozhat, és szeretnénk kezelni azt.
        // Exception: az objektum típusára vonatkozik

        public override bool Equals(object? obj)
        {
            if (obj is Time other)
                if (hour == other.hour && minute == other.minute && second == other.second)
                    return true;
            return false;
        }

        public int CompareTo(Time? other)
        {
            if (other == null)
                return 1;
            int thisSecond = hour * 3600 + minute * 60 + second;
            int otherSecond= other.hour * 3600 + other.minute * 60 + other.second;

            if (thisSecond > otherSecond)
                return -1;
            else
                return 1;
        }
    }
}
