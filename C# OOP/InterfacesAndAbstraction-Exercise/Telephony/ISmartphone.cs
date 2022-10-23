using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartphone
    {
        public void Browse(string url);
        public void Call(string number);
    }
}
