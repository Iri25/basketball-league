using System;
using System.Collections.Generic;
using System.Text;

namespace League.RepositoryException
{
    public class RepositoryException : Exception
    {
        public RepositoryException()
        {
        }

        public RepositoryException(string message) : base(message)
        {
        }
    }
}