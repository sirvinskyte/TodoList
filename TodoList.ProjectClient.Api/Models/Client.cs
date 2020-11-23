using System.Collections.Generic;

namespace TodoList.ProjectClient.Api.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Project>? Projects { get; set; }
    }
}
