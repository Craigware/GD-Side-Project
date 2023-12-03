using Godot;
using System;
using System.Collections.Generic;
using System.Linq;


public partial class background : Node
{
    [Export(PropertyHint.Range, "0,1")]
    public float parallaxSpeed = 1;
    [Export]
    private Godot.Collections.Array<Texture2D> backgroundLayers = new();
    private List<Godot.Collections.Array<Sprite2D>> layers;


    public override void _Ready()
    {
        layers = Tex2DsToSprites(backgroundLayers);
    }


    public override void _PhysicsProcess(double delta)
    {
        MoveBackgroundLayers(layers, parallaxSpeed, delta);
    }


    private void MoveBackgroundLayers(List<Godot.Collections.Array<Sprite2D>> _layers, float _parallaxSpeed, double delta)
    {
        for (int i = 0; i < _layers.Count; i++)
        {
            double speed = Math.Round(i * _parallaxSpeed);
            for (int q = 0; q < _layers[i].Count; q++) { MoveBackgroundLayer(_layers[i][q], -1, speed); }
        }
    }


    private void MoveBackgroundLayer(Sprite2D _layer, float _dir, double _speed)
    {
        //_layer goes offscreen and needs to be put to front
        if (Math.Abs(_layer.Position.X) >= _layer.Texture.GetWidth())
        {
            _layer.Position = new Vector2(_layer.Texture.GetWidth(), 0);
        }
        float x = Convert.ToSingle(_dir * _speed);
        Vector2 _movement = new(x,0);
        _layer.Position += _movement;
    }


    // background layers lower in index appear behind those higher
    private List<Godot.Collections.Array<Sprite2D>> Tex2DsToSprites(Godot.Collections.Array<Texture2D> _textures)
    {
        List<Godot.Collections.Array<Sprite2D>> _layers = new();
        
        for (int i = 0; i < _textures.Count; i++)
        {
            Godot.Collections.Array<Sprite2D> _layerImages = new();

            Sprite2D _layer = new(){
                Texture=_textures[i],
                Centered=false,
                ZIndex=i
            };


            Sprite2D _layerClone = (Sprite2D)_layer.Duplicate();
            _layerClone.Position = new Vector2(_layerClone.Texture.GetWidth(), 0);

            _layerImages.Add(_layer);
            _layerImages.Add(_layerClone);
            
            this.AddChild(_layer);
            this.AddChild(_layerClone);

            _layers.Add(_layerImages);
        }

        return _layers;
    }
}
