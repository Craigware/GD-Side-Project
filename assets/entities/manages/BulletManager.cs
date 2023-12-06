using Godot;
using System;

namespace Managers
{
    public partial class BulletManager : Node
    {
        public void AddChildBullet(PackedScene bullet)
        {
            Node _bullet = bullet.Instantiate();
            this.AddChild(_bullet);
        }
    }
}