namespace IssueTracker.Api.DTOsModel
{
    public class CreateProjectDTO
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
    }
}
