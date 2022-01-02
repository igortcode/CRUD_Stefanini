using System;

namespace Business.Exceptions
{
    public class EntityException : Exception
    {
        public EntityException(string message) : base(message)
        {
        }
    }
}
