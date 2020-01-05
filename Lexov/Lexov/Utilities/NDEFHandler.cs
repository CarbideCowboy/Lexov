using NdefLibrary.Ndef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Lexov.Utilities
{
    public class NDEFHandler
    {
        public static string readNDEFPlainText(NdefMessage message)
        {
            if(message.Count > 1 || !(message.ElementAtOrDefault(0).CheckSpecializedType(false) == typeof(NdefTextRecord)))
            {
                MessagingCenter.Send<NdefMessage>(message, "RecordIncompatible");
                return "Error reading tag";
            }
            if(message == null)
            {
                return "Tag is empty";
            }

            NdefTextRecord record = new NdefTextRecord(message.ElementAtOrDefault(0));

            //returns the text of the scanned record
            return record.Text;
        }

        public static NdefMessage makeTextNDEFRecord(string NDEFPayload)
        {
            var ndefRecord = new NdefTextRecord()
            {
                Text = NDEFPayload
            };

            NdefMessage ndefMessage = new NdefMessage();
            ndefMessage.Add(ndefRecord);
            return ndefMessage;
        }
    }
}
