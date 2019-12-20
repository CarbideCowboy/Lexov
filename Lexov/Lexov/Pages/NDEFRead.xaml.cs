using NdefLibrary.Ndef;
using Poz1.NFCForms.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lexov.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDEFRead : ContentPage
    {
        private readonly INfcForms device;
        public NDEFRead()
        {
            InitializeComponent();

            device = DependencyService.Get<INfcForms>();
            device.NewTag += HandleNewTag;
            uxRefreshButton.Clicked += uxRefreshButton_Clicked;
        }

        private string readNDEFMessage(NdefMessage message)
        {
            if(message == null)
            {
                return "Tag is empty";
            }

            NdefTextRecord record = new NdefTextRecord(message.ElementAtOrDefault(0));

            return record.Text;
        }

        void HandleNewTag(object sender, NfcFormsTag e)
        {
            uxNDEFScroll.IsVisible = true;
            uxNDEFScroll.ScrollToAsync(0,0, false);
            lblNFCIcon.IsVisible = false;
            lblScanMessage.IsVisible = false;
            uxButtonStack.IsVisible = true;

            string readNDEF = readNDEFMessage(e.NdefMessage);
            uxNDEFEditor.Text = readNDEF;
        }

        void uxRefreshButton_Clicked(object sender, EventArgs e)
        {
            uxButtonStack.IsVisible = false;
            uxNDEFScroll.IsVisible = false;
            lblNFCIcon.IsVisible = true;
            lblScanMessage.IsVisible = true;
        }
    }
}