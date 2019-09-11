using OOP_Basics_Vice_City.Repositories;
using System;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace OOP_Basics_Vice_City.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string _name;
        private bool _isAlive;
        private int _lifePoints;
        private IRepository<IGun> _gunRepository;

        public Player(string name, int lifePoints)
        {
            this.Name = name;
            this.IsAlive = true;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public bool IsAlive
        {
            get { return this._isAlive; }
            set { this._isAlive = value; }
        }

        public IRepository<IGun> GunRepository
        {
            get { return this._gunRepository; }
            set { this._gunRepository = value; }
        }

        public int LifePoints
        {
            get { return this._lifePoints; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                this._lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            this._lifePoints -= points;
        }
    }
}
