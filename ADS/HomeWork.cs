using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS
{
    abstract class HomeWork
    {
        protected readonly string _lession;
        protected readonly string _name;
        protected readonly string _description;

        public HomeWork(string lession, string name, string description)
        {
            _lession = lession;
            _name = name;
            _description = description;
        }

        public virtual string GetLession()
        {
            return _lession;
        }

        public virtual string GetName()
        {
            return _name;
        }

        public virtual string GetDescription()
        {
            return _description;
        }

        public abstract void Run();

    }
}
