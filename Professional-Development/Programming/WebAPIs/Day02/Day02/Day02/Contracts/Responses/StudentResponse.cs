namespace Day01.Contracts.Responses;

public class StudentResponse
{
    public int StId { get; set; }

    public string? StFname { get; set; }

    public string? StLname { get; set; }

    public string? StAddress { get; set; }

    public int? StAge { get; set; }

    public string? DeptName { get; set; }

    public string? SupervisorName { get; set; }
}
