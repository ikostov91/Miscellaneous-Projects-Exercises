using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace OOP_Basics_Vice_City.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string _name;
        private int _bulletsPerBarrel;
        private int _totalBullers;
        private bool _canFire;

        public Gun()
        {
            this._canFire = true;
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }
                this._name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get { return this._bulletsPerBarrel; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }
                this._bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get { return this._totalBullers; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }
                this._totalBullers = value;
            }
        }

        public bool CanFire => this._canFire;

        public int Fire()
        {
            throw new NotImplementedException();
        }
    }
}
