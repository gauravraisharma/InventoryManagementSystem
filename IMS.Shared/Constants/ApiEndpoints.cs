using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.Constants
{
    public class ApiEndpoints
    {
        public static class Products
        {
            public const string Base = "https://localhost:44317/";
            public const string Get = Base + "api/Products";
            public const string Create = Base;
            public const string Update = Base + "/{id}";
            public const string Delete = Base + "/{id}";
            public const string GetById = Base + "api/Products/GetProductById";

           
            //public const string Get = Base + "api/Products";
        }
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
            public const string SaveProducts = Base + "api/Products/add-edit";
            public const string UpdateProducts = Base + "api/Products/add-edit";
        }

        public static class Auth
        {
            public const string Base = "https://localhost:44317/";
            public const string Login = Base + "api/auth/Login";
            public const string Register = Base + "api/auth/register";
        }
    }
}
