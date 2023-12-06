using Godot;
using System;

namespace Entity
{
    public partial class BaseBullet : StaticBody2D
    {
        [Export] private int Speed = 10;

        public override void _Process(double delta)
        {
            Position += new Vector2(Speed, 0);

            if (Position.X > 1280 || Position.X < 0){ this.QueueFree(); }
        }
    }
}