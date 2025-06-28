namespace LocationTrackerApp.Models
{

    public class Point
    {
        public LocationData Location { get; set; }
        public int Count { get; set; } = 1;
        public Color Heat { get; set; }
    }
}

