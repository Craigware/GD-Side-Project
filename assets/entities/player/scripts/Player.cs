using Godot;
using System;

namespace Entity
{
	public partial class Player : CharacterBody2D
	{
        [Export] public Stats stats;
        [Export] public Weapon weapon;

        private bool inputsEnabled = true;
		private Vector2 direction = new();


        public override void _Input(InputEvent @event)
		{
			if (inputsEnabled)
			{
				if (@event.IsActionPressed("shoot")){ weapon.Shoot(this); }
			}
		}


		public override void _Ready()
		{

        }


		public override void _Process(double delta)
		{
            ReadDirectionalInput();
            MovePosition(direction, delta);
        }


        private void MovePosition(Vector2 dir, double delta)
        {   
            double x = dir.X * stats.Speed * delta;
            double y = dir.Y * stats.Speed * delta;
            this.Position += new Vector2((float)x, (float)y);
        }


        private void ReadDirectionalInput(){
            if (Input.IsActionPressed("left")) { UpdateDirection(-1, -2); }
            if (Input.IsActionPressed("right")) { UpdateDirection(1, -2); }
            if (Input.IsActionPressed("left") && Input.IsActionJustPressed("right") || !Input.IsActionPressed("left") && !Input.IsActionPressed("right"))
            { UpdateDirection(0, -2); }


            if (Input.IsActionPressed("down")) { UpdateDirection(-2 ,1); }
            if (Input.IsActionPressed("up")) { UpdateDirection(-2, -1); }
            if (Input.IsActionPressed("down") && Input.IsActionJustPressed("up") || !Input.IsActionPressed("down") && !Input.IsActionPressed("up"))
            { UpdateDirection(-2, 0); }
        }


        public void UpdateDirection(float x, float y)
        {
            if (x == -2) { x = direction.X; }
            if (y == -2) { y = direction.Y; }
            
            // this is a bit off
            if (Math.Abs(x) == 1 && Math.Abs(y) == 1) { x /= 2; y /= 2;} 

            x = Math.Clamp(x, -1, 1);
            y = Math.Clamp(y, -1, 1);
            direction = new Vector2(x, y);
        }
	}
}