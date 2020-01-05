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
    public partial class ScanPrompt : ContentPage
    {
        //instantiates a new NFC tag object
        private readonly INfcForms device;
        public ScanPrompt()
        {
            InitializeComponent();
            DependencyService.Get<IOrientationHandler>().ForcePortrait();

            //activates the physical NFC service of the device
            device = DependencyService.Get<INfcForms>();
            device.NewTag += HandleNewTag;
            uxBlankNDEFButton.Clicked += uxBlankNDEFButton_Clicked;

            //displays a display alert in the case of an unsupported tag being scanned. subscribes from the NDEFHandler class
            MessagingCenter.Subscribe<NdefMessage>(this, "RecordIncompatible", async (sender) =>
            {
                await DisplayAlert("Error", "Incompatible NDEF record, ensure that your tag's NDEF record is formatted as plain text", "OK");
            });
        }

        private void uxBlankNDEFButton_Clicked(object sender, EventArgs e)
        {
            //pushes to NDEF read with blank input
            Navigation.PushAsync(new Pages.NDEFRead(""));
        }

        //shows contents of a new tag
        private void HandleNewTag(object sender, NfcFormsTag e)
        {
            //ensures that event is only called on this scanprompt page
            if(Navigation.NavigationStack.Count == 1)
            {
                //pushes to NDEF read page with converted string representation of a scanned record
                Navigation.PushAsync(new Pages.NDEFRead(Utilities.NDEFHandler.readNDEFPlainText(e.NdefMessage)));
            }
        }
    }
}