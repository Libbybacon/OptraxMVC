﻿namespace OptraxMVC.Models
{
    public class ResponseVM
    {
        public bool success { get; set; } = false;
        public string msg { get; set; } = string.Empty;
        public string? function { get; set; }
        public object? data { get; set; }
    }
}
