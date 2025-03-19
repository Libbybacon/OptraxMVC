namespace OptraxDAL.ViewModels
{
    public class MapObjectVM
    {
        public List<PointVM> Points { get; set; } = [];
        public List<LineVM> Lines { get; set; } = [];
        public List<PolyVM> Polys { get; set; } = [];
    }

    public class PointVM
    {
        public int ID { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public int? LocationID { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string IconPath { get; set; } = default!;
    }

    public class LineVM
    {

    }

    public class PolyVM
    {

    }
}
