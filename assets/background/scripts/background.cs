using Godot;
using System;
using System.Linq;


public partial class background : Node
{
    [Export]
    public Godot.Collections.Array<Texture2D> backgroundLayers = new();
    public Godot.Collections.Array<Sprite2D> layers = new();

    public override void _Ready()
    {
        for (int i = 0; i < backgroundLayers.Count; i++)
        {
            Sprite2D _layer = new();
            _layer.Texture = backgroundLayers[i];
            _layer.Centered = false;
            
            layers.Add(_layer);
            this.AddChild(_layer);
        }
    }

    public override void _Process(double delta)
    {
        GD.Print(layers[0].Position);
    }
}
