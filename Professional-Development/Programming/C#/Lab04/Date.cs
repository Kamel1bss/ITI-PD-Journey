namespace Lab04;

internal class Date
{
    int day;
    int month;
    int year;
    public Date(int _year) : this(_year, 1, 1) { }
    public Date(int _year, int _month) : this(_year, _month, 1) { }
    public Date(int _year = 1990, int _month = 1, int _day = 1) 
    {
        day = _day;
        month = _month;
        year = _year;
    }
    public override string ToString()
    {
        if (day <= 9)
        {
            if (month <= 9)
                return $"0{day}/0{month}/{year}";
            else
                return $"0{day}/{month}/{year}";
        }
        else
        {
            if (month <= 9)
                return $"{day}/0{month}/{year}";
            else
                return $"{day}/{month}/{year}";
        }
    }
}
