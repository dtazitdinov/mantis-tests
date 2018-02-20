using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace mantis_tests
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Add(AccountData account)
        {
            if (Verify(account))
            {
                return;
            }
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
        }

        public void Delete(AccountData account)
        {

        }

        public bool Verify(AccountData account)
        {
            return false;
        }
    }
}
