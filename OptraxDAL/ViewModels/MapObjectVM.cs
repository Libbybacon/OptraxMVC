namespace OptraxDAL.ViewModels
{
    public class MapObjectVM
    {
    }

    public class PointVM
    {
        public int ID { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImagePath { get; set; } = default!;
        public bool Active { get; set; } = true;
    }
}
