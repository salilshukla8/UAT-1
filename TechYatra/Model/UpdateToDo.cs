using System.Net;

namespace TechYatra.Model
{
    public class UpdateToDo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class ErrorResponse
    {
        public int Code { get; set; }

        public String StatusMessage { get; set; }
    }

}
