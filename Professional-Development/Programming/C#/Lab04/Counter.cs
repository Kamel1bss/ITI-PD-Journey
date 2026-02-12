namespace Lab04;
internal class Counter
{
    public int instanceId;
    public static int totalObjectsCreated;
    static Counter()
    {
        totalObjectsCreated = 0;
    }
    public Counter()
    {
        totalObjectsCreated++;
        instanceId = totalObjectsCreated;
    }
}
