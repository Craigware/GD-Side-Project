using Godot;
using System;

namespace Entity
{
    [GlobalClass]
	public partial class Stats : Resource
	{
        [Export] public int Health {get; set;}
        [Export] public int Speed {get; set;}

        public Stats() : this(100, 1) {}
        public Stats(int health, int speed)
        {
            Health = health;
            Speed = speed;
        }
	}
}
