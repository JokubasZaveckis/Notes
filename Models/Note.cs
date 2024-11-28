namespace Notes.Models
{
    public class Note{
        public int ID {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Content {get; set;} = string.Empty;
        public string Category {get; set;} = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}