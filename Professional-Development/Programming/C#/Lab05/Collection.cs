namespace Lab05;
internal class Collection
{
    struct Pair
    {
        public string Key;
        public string Value;
    }

    string[] ints;
    Pair[] strs;
    int strsCnt;

    public Collection(int n)
    {
        ints = new string[n];
        strs = new Pair[n];
        strsCnt = 0;
    }

    public string this[int idx]
    {
        set {ints[idx] = value; }
        get { return ints[idx]; }
    }

    string FindByKey(string key)
    {
        string ans = "Not Found";
        for (int i = 0; i < strs.Length; i++)
        {
            if(key == strs[i].Key)
                ans = strs[i].Value;
        }

        return ans;
    }

    void SetByKey(string key, string val)
    {
        if(strsCnt < strs.Length)
        {
            strs[strsCnt].Key = key;
            strs[strsCnt].Value = val;
            strsCnt++;
        }
    }
    public string this[string key]
    {
        set { SetByKey(key, value); }
        get { return FindByKey(key); }
    }
}
