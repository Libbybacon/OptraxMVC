﻿namespace OptraxDAL.ViewModels
{
    public class TagVM
    {
        public TagVM() { }
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Color { get; set; } = "#FFFFFF";
    }
}
