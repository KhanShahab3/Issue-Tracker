namespace IssueTracker.Api.DTOsModel
{
    public class CreateCommentsDTO
    {
        public int IssueId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
