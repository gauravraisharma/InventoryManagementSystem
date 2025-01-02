namespace IMS.Shared.Constants
{
    public static class ApiEndpoints
    {
        private static string _baseUrl;

        public static void Initialize(string baseUrl)
        {
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl), "Base URL cannot be null");
        }

        public static class Category
        {
            public static string GetAllCategories => $"{_baseUrl}api/Category";
        }

        public static class Department
        {
            public static string GetAllDepartments => $"{_baseUrl}api/Department";
        }

        public static class Product
        {
            public static string GetAllDepartments => $"{_baseUrl}api/Product";
            public static string GetById => $"{_baseUrl}api/Products/GetProductById";
            public static string SaveProducts => $"{_baseUrl}api/Products/add-edit";
            public static string UpdateProducts => $"{_baseUrl}api/Products/add-edit";
            public static string DeleteById => $"{_baseUrl}api/Products/DeleteProductById";
            public static string Get => $"{_baseUrl}api/Products";
        }

        public static class Auth
        {
            public static string Login => $"{_baseUrl}api/auth/Login";
            public static string Register => $"{_baseUrl}api/auth/register";
            public static string GetAllUsers => $"{_baseUrl}api/auth/getAllUsers";
            public static string GetUserById => $"{_baseUrl}api/auth/GetUserById";
            public static string UpdateUserProfile => $"{_baseUrl}api/auth/UpdateProfile";
        }

        public static class Cart
        {
            public static string AddToCart => $"{_baseUrl}api/Cart/AddToCart";
            public static string GetCartItems => $"{_baseUrl}api/Cart/GetCartItems";
            public static string UpdateCart => $"{_baseUrl}api/Cart/EditCart";
            public static string DeleteCartItem => $"{_baseUrl}api/Cart/DeleteCartItem";
            public static string DeleteAllCartItemsByUserId => $"{_baseUrl}api/Cart/DeleteAllCartItemsByUserId";
        }

        public static class Order
        {
            public static string SaveOrder => $"{_baseUrl}api/orders/AddOrder";
            public static string GetAllOrders => $"{_baseUrl}api/orders/GetAllOrders";
            public static string GetAllUserOrders => $"{_baseUrl}api/orders/GetUserOrderById";
            public static string GetOrderById => $"{_baseUrl}api/orders/GetOrderById";
            public static string CreateStripeCheckoutSession => $"{_baseUrl}api/orders/CreateStripeCheckoutSession";
        }

        public static class TwoFactor
        {
            public static string SendCode => $"{_baseUrl}api/TwoFactorAuth/generate";
            public static string SendCodeForProfile => $"{_baseUrl}api/TwoFactorAuth/generateCodeForProfile";
            public static string ValidateCode => $"{_baseUrl}api/TwoFactorAuth/validate";
        }
    }
}
