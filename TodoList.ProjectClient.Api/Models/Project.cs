namespace TodoList.ProjectClient.Api.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Client? Client { get; set; }
    }
}
