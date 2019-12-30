using Lexov.Utilities;
using NdefLibrary.Ndef;
using Poz1.NFCForms.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lexov.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDEFWrite : ContentPage
    {
        private readonly INfcForms device;
        private NdefMessage ndefMessage;
        public NDEFWrite(NdefMessage NDEFPayload)
        {
            InitializeComponent();
            DependencyService.Get<IOrientationHandler>().ForcePortrait();

            device = DependencyService.Get<INfcForms>();
            device.NewTag += HandleNewTag;

            ndefMessage = NDEFPayload;
        }

        private void HandleNewTag(object sender, NfcFormsTag e)
        {
            device.WriteTag(ndefMessage);
        }
    }
}