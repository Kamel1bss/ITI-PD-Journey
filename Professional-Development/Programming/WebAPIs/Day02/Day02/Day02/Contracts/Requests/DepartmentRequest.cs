namespace Day01.Contracts.Requests;

public class DepartmentRequest
{
    public int DeptId { get; set; }
    public string? DeptName { get; set; }
    public string? DeptDesc { get; set; }
    public string? DeptLocation { get; set; }
}
