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
        //converts NDEF record to string
        public static string readNDEFPlainText(NdefMessage message)
        {
            // tag is disqualified if it contains multiple records or if tag is not of plaintext type 
            if(message.Count > 1 || !(message.ElementAtOrDefault(0).CheckSpecializedType(false) == typeof(NdefTextRecord)))
            {
                MessagingCenter.Send<NdefMessage>(message, "RecordIncompatible");
                return "Error reading tag";
            }
            if(message == null)
            {
                return "Tag is empty";
            }

            //conversion takes place
            NdefTextRecord record = new NdefTextRecord(message.ElementAtOrDefault(0));
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
