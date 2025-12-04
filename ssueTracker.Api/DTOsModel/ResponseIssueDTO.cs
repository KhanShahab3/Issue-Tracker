namespace IssueTracker.Api.DTOsModel
{
    public class ResponseIssueDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string ProjectName { get; set; }
        public string AssignedUser { get; set; }
       
    }
}
