using System;

public class DrawModelStubObject
{
	
    [JsonConstructor]
    public DrawModelStubObject(List<Path> paths, Color current_color, float current_line_width)
    {
        Paths = paths;
        CurrentColor = current_color;
        CurrentLineWidth = current_line_width;
    }

    [JsonProperty("path")]
    public List<Path> Paths { get; }

    [JsonProperty("current_color")]
    public Color CurrentColor { get; set; }

    [JsonProperty("current_line_width")]
    public float CurrentLineWidth { get; set; }
}

