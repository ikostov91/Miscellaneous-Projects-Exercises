using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace OOP_Basics_Vice_City.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> _models;

        public GunRepository()
        {
            this._models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
        {
            get => this._models.AsReadOnly();
        }

        public void Add(IGun model)
        {
            if (!this._models.Contains(model))
            {
                this._models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return this._models.Find(x => x.Name == name);
        }

        public bool Remove(IGun model)
        {
            return this._models.Remove(model);
        }
    }
}
