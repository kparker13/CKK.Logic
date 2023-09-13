using CKK.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        protected int id;
        public int Id 
        {
            get { return id; }

            set
            {
                if (value < 0)
                { id = value; }
                throw new InvalidIdException();
                
            }
        }
        public string Name { get; set; }
    }
}
