namespace Lab05;

// indexer is like a property
internal class Gradebook
{
    double[] _grades;
    public Gradebook(int n)
    {
        _grades = new double[n];
    }

    public double this[int idx]
    {
        get 
        { 
            if(idx >= 0 && idx < _grades.Length)
                return _grades[idx];
            return -1;
        }
        set 
        {
            if (idx >= 0 && idx < _grades.Length)
                _grades[idx] = value;
        }
    }

    


}
