using Godot;
using System;

namespace Entity {
	public partial class player : Node
	{
		[Export]
		private int hitPoints = 100;
		[Export]
		private int moveSpeed = 1;
		private bool inputsEnabled = true;
		private Vector2 direction = new();


		public override void _Ready()
		{}


		public override void _Process(double delta)
		{}


		private Vector2 UpdateDirection(float x, float y)
		{
			return direction;
		}


		public override void _Input(InputEvent @event)
		{
			if (inputsEnabled)
			{
				// Actions
				if (@event.IsActionPressed("shoot"))
				{
					GD.Print(direction);
				}

				// Movement
				if (@event.IsActionPressed("left"))
				{
					direction.X = -1;
				}

				if (@event.IsActionPressed("right"))
				{
					direction.X = 1;
				}

				if (@event.IsActionPressed("up"))
				{
					direction.Y = -1;
				}
				
				if (@event.IsActionPressed("down"))
				{
					direction.Y	= 1;
				}
			}
		}
	}
}