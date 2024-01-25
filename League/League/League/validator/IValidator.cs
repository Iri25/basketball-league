using System;
using System.Collections.Generic;
using System.Text;

namespace League.validator
{
    public interface IValidator<E>
    {
        void Validate(E e);
    }
}
