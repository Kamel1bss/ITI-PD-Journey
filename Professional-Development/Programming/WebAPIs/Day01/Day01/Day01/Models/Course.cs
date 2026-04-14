namespace Day01.Models;

public class Course
{
    public int Id { get; set; }
    public string Crs_name { get; set; } = string.Empty;
    public string Crs_desc { get; set; } = string.Empty;
    public int? Duration { get; set; }
}
