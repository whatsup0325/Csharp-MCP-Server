using ModelContextProtocol.Server;
using System.ComponentModel;

namespace TestServerWithHosting.Tools;

public class WorkRecord
{
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public string EmployeeName { get; set; }
    public string Description { get; set; }
    public int Hour { get; set; }
}


public static class Data
{
    public static List<WorkRecord> workRecords = new List<WorkRecord>
    {
        new WorkRecord
        {
            Id = "1",
            Date = new DateTime(2025,4,8),
            EmployeeName = "Jason",
            Description = "程式撰寫",
            Hour = 6

        },
        new WorkRecord
        {
            Id = "2",
            Date = new DateTime(2025,4,8),
            EmployeeName = "Jason",
            Description = "內部會議",
            Hour = 2

        }
    };
}

[McpServerToolType]
public sealed class WorkRecordTool
{
    [McpServerTool(Name = "ListWorkRecord"), Description("Return all work record")]
    public static IEnumerable<WorkRecord> ListWorkRecord()
    {
        return Data.workRecords;
        }

    [McpServerTool(Name = "AddWorkRecord"), Description("Add work record")]
    public static void AddWorkRecord(
        [Description("Working Date")] DateTime date,
        [Description("Employee code")] string employee,
        [Description("Job Description")] string description,
        [Description("Total hours spent")] int hour)
    {
        var workRecord = new WorkRecord
        {
            Id = Guid.NewGuid().ToString(),
            Date = date,
            EmployeeName = employee,
            Description = description,
            Hour = hour
        };
        Data.workRecords.Add(workRecord);
    }


}