﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InvalidIdException : Exception
    {
        public InvalidIdException() 
            : base("Unable to use a negative number"){ }
        public InvalidIdException(string message)
            : base(message) { }
        public InvalidIdException(string message, Exception inner)
            : base(message, inner) { }
    }
}
