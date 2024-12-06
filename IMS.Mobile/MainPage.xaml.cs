using IMS.Mobile.Service;

namespace IMS.Mobile
{
    public partial class MainPage : ContentPage
    {
        private readonly ProductService _productService;

        public MainPage(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            LoadProducts();
        }

        private async void LoadProducts()
        {
            // Fetch products from the ProductService (API call)
            var products = await _productService.GetProductsAsync();

            // Bind the list of products to the ListView
            ProductListView.ItemsSource = products;
        }

    }
}
