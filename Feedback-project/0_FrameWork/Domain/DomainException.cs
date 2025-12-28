using System;
using System.Collections.Generic;
using System.Text;

namespace _0_FrameWork.Domain;

public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }

}
