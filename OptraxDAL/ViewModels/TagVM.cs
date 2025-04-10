namespace OptraxDAL.ViewModels
{
    public class TagVM
    {
        public TagVM() { }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Color { get; set; } = "#FFFFFF";
    }
}
