namespace TaskApi.DTOs
{
    public record TaskDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
