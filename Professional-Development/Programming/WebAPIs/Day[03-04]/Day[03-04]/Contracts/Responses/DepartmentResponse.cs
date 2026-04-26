namespace Day01.Contracts.Responses;

public class DepartmentResponse
{
    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    public string? DeptDesc { get; set; }

    public string? DeptLocation { get; set; }

    public int StudentsCount { get; set; }
}
