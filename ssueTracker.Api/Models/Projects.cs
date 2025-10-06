namespace IssueTracker.Api.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } 
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }  


    }
}
