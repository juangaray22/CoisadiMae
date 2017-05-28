using Xamarin.Forms;

namespace CoisadiMae.Views
{
    public partial class BasePageNavigation : NavigationPage
    {
        public BasePageNavigation(Page page) : base(page)
        {
            InitializeComponent();
        }
    }
}