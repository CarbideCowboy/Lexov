using NdefLibrary.Ndef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexov.Utilities
{
    public class NDEFHandler
    {
        public static string readNDEFPlainText(NdefMessage message)
        {
            if(message == null)
            {
                return "Tag is empty";
            }

            NdefTextRecord record = new NdefTextRecord(message.ElementAtOrDefault(0));

            return record.Text;
        }
    }
}
