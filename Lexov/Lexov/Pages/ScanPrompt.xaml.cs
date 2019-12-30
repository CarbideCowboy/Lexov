using Lexov.Utilities;
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
        private readonly INfcForms device;
        public ScanPrompt()
        {
            InitializeComponent();
            DependencyService.Get<IOrientationHandler>().ForcePortrait();

            device = DependencyService.Get<INfcForms>();
            device.NewTag += HandleNewTag;
        }

        private void HandleNewTag(object sender, NfcFormsTag e)
        {
            Navigation.PushAsync(new Pages.NDEFRead(Utilities.NDEFHandler.readNDEFPlainText(e.NdefMessage)));
        }
    }
}