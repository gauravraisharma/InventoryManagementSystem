using IMS.Mobile.Service;

namespace IMS.Mobile
{
    public partial class App : Application
    {
        public App(ProductService productService)  
        {
            InitializeComponent();

         
            MainPage = new MainPage(productService); 
        }
    }
}
