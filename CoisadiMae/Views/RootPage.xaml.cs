using Xamarin.Forms;

namespace CoisadiMae.Views
{
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
        }
        public bool IsPresentedAfterNavigation
        {
            get
            {
                return false;
            }
        }
    }
}