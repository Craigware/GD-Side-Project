using Godot;
using System;

namespace Entity
{
	public partial class Player : Node
	{
        [Export] public Stats stats = new();
        [Export] public Weapon weapon = new();

        private bool inputsEnabled = true;
		private Vector2 direction = new();


		public override void _Ready()
		{
        }


		public override void _Process(double delta)
		{}

		public override void _Input(InputEvent @event)
		{
			if (inputsEnabled)
			{
				// Actions
				if (@event.IsActionPressed("shoot")){ weapon.Shoot(); }

				// Movement
				if (@event.IsActionPressed("left")) { direction.X = -1; }
				if (@event.IsActionPressed("right")) { direction.X = 1; }
				if (@event.IsActionPressed("up")) { direction.Y = -1; }
				if (@event.IsActionPressed("down")) { direction.Y	= 1; }
			}
		}
	}
}