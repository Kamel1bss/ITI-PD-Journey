namespace Lab06;

internal static class Filter
{
    public static class Method
    {
        public static bool isEven(int num) => num % 2 == 0;
        public static bool isOdd(int num) => num % 2 == 1;
        public static bool isGreaterThan5(int num) => num > 5;
        
    }
    public static List<int> Array(List<int> arr, FilterHandler criteria)
    {
        List<int> ans = new List<int>();
        foreach(var num in arr)
            if (criteria(num))
                ans.Add(num);
        return ans;
    }
}
