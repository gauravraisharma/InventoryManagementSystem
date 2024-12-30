namespace IMS.Shared.Constants
{
    public class ApiEndpoints
    {
     
        public static class Category
        {
            public const string Base = "https://localhost:44317/";
            public const string GetAllCategories = Base + "api/Category";
        }
        public static class Department
        {
            public const string Base = "https://localhost:44317/";
            public const string GetAllDepartments = Base + "api/Department";
        }
        public static class Product
        {
            public const string Base = "https://localhost:44317/";
            public const string GetAllDepartments = Base + "api/Product";
            public const string GetById = Base + "api/Products/GetProductById";
            public const string SaveProducts = Base + "api/Products/add-edit";
            public const string UpdateProducts = Base + "api/Products/add-edit";
            public const string DeleteById = Base + "api/Products/DeleteProductById";
            public const string Get = Base + "api/Products";
        }

        public static class Auth
        {
            public const string Base = "https://localhost:44317/";
            public const string Login = Base + "api/auth/Login";
            public const string Register = Base + "api/auth/register";
            public const string GetAllUsers = Base + "api/auth/getAllUsers";
        }

        public class Cart
        {
            public const string Base = "https://localhost:44317/";
            public const string AddToCart= Base + "api/Cart/AddToCart";
            public const string GetCartItems = Base + "api/Cart/GetCartItems";
            public const string UpdateCart = Base + "api/Cart/EditCart";
            public const string DeleteCartItem = Base + "api/Cart/DeleteCartItem";
        }
        public static class Order
        {
            public const string Base = "https://localhost:44317/";
            public const string SaveOrder = Base + "api/Orders/AddOrder";
            public const string GetAllOrders = Base + "api/Orders/GetAllOrders";
            public const string CreateStripeCheckoutSession = Base + "api/Orders/CreateStripeCheckoutSession";
        }
        public class TwoFactor
        {
            public const string Base = "https://localhost:44317/";
            public const string SendCode = Base + "api/TwoFactorAuth/generate";
            public const string ValidateCode = Base + "api/TwoFactorAuth/validate";
        }
    }
}
