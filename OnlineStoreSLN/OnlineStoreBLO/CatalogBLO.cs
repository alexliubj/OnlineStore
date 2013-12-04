using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineStoreDAL.Models;
using OnlineStoreDAL;
using System.Data;

namespace OnlineStoreBLO
{
    public static class CatalogBLO
    {
        static CatalogBLO() { }
        // Retrieve the list of departments 
        public static DataTable GetDepartments() { return CatalogDAO.GetDepartments(); }

        // get department details
        public static DepartmentDetails GetDepartmentDetails(string departmentId) { return CatalogDAO.GetDepartmentDetails(departmentId); }

        // Get category details
        public static CategoryDetails GetCategoryDetails(string categoryId) { return CatalogDAO.GetCategoryDetails(categoryId); }

        // Get product details
        public static ProductDetails GetProductDetails(string productId) { return CatalogDAO.GetProductDetails(productId); }

        // retrieve the list of categories in a department
        public static DataTable GetCategoriesInDepartment(string departmentId) { return CatalogDAO.GetCategoriesInDepartment(departmentId); }

        // Retrieve the list of products on catalog promotion
        public static DataTable GetProductsOnCatalogPromotion(string pageNumber, out int howManyPages) { return CatalogDAO.GetProductsOnCatalogPromotion(pageNumber, out howManyPages); }

        // retrieve the list of products featured for a department
        public static DataTable GetProductsOnDepartmentPromotion(string departmentId, string pageNumber, out int howManyPages, int ord) { return CatalogDAO.GetProductsOnDepartmentPromotion(departmentId, pageNumber, out howManyPages, ord); }

        // retrieve the list of products in a category
        public static DataTable GetProductsInCategory(string categoryId, string pageNumber, out int howManyPages, int odb) { return CatalogDAO.GetProductsInCategory(categoryId, pageNumber, out howManyPages, odb); }

        // Search the product catalog
        public static DataTable Search(string searchString, string allWords, string pageNumber, out int howManyPages) { return CatalogDAO.Search(searchString,allWords, pageNumber, out howManyPages); }

        // Update department details
        public static bool UpdateDepartment(string id, string name, string description) { return CatalogDAO.UpdateDepartment(id, name, description); }

        // Delete department
        public static bool DeleteDepartment(string id) { return CatalogDAO.DeleteDepartment(id); }

        // Add a new department
        public static bool AddDepartment(string name, string description) { return CatalogDAO.AddDepartment(name, description); }

        // Create a new Category
        public static bool CreateCategory(string departmentId, string name, string description) { return CatalogDAO.CreateCategory(departmentId, name, description); }

        // Update category details
        public static bool UpdateCategory(string id, string name, string description) { return CatalogDAO.UpdateCategory(id, name, description); }

        // Delete Category
        public static bool DeleteCategory(string id) { return DeleteCategory(id); }

        // retrieve the list of products in a category
        public static DataTable GetAllProductsInCategory(string categoryId) { return CatalogDAO.GetAllProductsInCategory(categoryId); }

        // Create a new product
        public static bool CreateProduct(string categoryId, string name, string description, string price, string image1FileName, string image2FileName, string onDepartmentPromotion, string onCatalogPromotion)
        {
            return CatalogDAO.CreateProduct(categoryId, name, description, price, image1FileName, image2FileName, onDepartmentPromotion, onCatalogPromotion);
        }

        // Update an existing product
        public static bool UpdateProduct(string productId, string name, string description, string price, string image1FileName, string image2FileName, string onDepartmentPromotion, string onCatalogPromotion)
        {
            return CatalogDAO.UpdateProduct
                (productId, name, description, price, image1FileName, image2FileName, onDepartmentPromotion, onCatalogPromotion);
        }

        // get categories that contain a specified product
        public static DataTable GetCategoriesWithProduct(string productId) { return CatalogDAO.GetCategoriesWithProduct(productId); }

        // get categories that do not contain a specified product
        public static DataTable GetCategoriesWithoutProduct(string productId) { return CatalogDAO.GetCategoriesWithoutProduct(productId); }

        // assign a product to a new category
        public static bool AssignProductToCategory(string productId, string categoryId) { return CatalogDAO.AssignProductToCategory(productId, categoryId); }

        // move product to a new category
        public static bool MoveProductToCategory(string productId, string oldCategoryId, string newCategoryId) { return CatalogDAO.MoveProductToCategory(productId, oldCategoryId, newCategoryId); }

        // removes a product from a category 
        public static bool RemoveProductFromCategory(string productId, string categoryId) { return CatalogDAO.RemoveProductFromCategory(productId, categoryId); }

        // deletes a product from the product catalog
        public static bool DeleteProduct(string productId) { return CatalogDAO.DeleteProduct(productId); }

        // gets product recommendations
        public static DataTable GetRecommendations(string productId) { return CatalogDAO.GetRecommendations(productId); }
    }
}
