using Godot;
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

        public void Shoot()
        {
            void ShootBasic()
            {

            }

            switch(WeaponType)
            {
                case WeaponTypes.BASIC:
                    ShootBasic();
                    break;
                // case WeaponTypes.SPREAD:
                //     this ShootSpread();
                //     break;
                // case WeaponTypes.BEAM:
                //     this.ShootBeam();
                //     break;
                // case WeaponTypes.CHARGE:
                //     this.ShootCharge();
                //     break;
                default:
                    GD.Print("How did you manage to have a type that isn't in the enum?");
                    throw new Exception("Error: Weapon Type is not valid.");
            }
        }
    }
}
