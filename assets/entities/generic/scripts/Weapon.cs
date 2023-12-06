using Godot;
using Managers;
using System;
using System.Text.RegularExpressions;

namespace Entity
{
    [GlobalClass]
    public partial class Weapon : Resource
    {
        [Export] public int FireRate {get; set;}
        [Export] public int Damage {get; set;}
        [Export] public WeaponTypes WeaponType;

        public enum WeaponTypes
        {
            BASIC = 0,
            SPREAD = 1,
            CHARGE = 2,
            BEAM = 3
        }

        public Weapon() : this(1, 25, WeaponTypes.BASIC) {}
        public Weapon(int fireRate, int damage, WeaponTypes weaponType)
        {
            FireRate = fireRate;
            Damage = damage;
            WeaponType = weaponType;
        }
    }
}
