namespace br.com.fiap.alert.Models
{
    public class AlertModel
    {
        public int AlertId { get; set; }
        public string? TypeAlert { get; set; }
        public string? Message { get; set; }
        public string? Coords { get; set; }
        public String? Author { get; set; }
    }
}
