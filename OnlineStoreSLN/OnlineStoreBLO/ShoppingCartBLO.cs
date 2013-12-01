using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineStoreDAL;
using OnlineStoreDAL.Models;
using System.Data;

namespace OnlineStoreBLO
{
    public static class ShoppingCartBLO
    {
        static ShoppingCartBLO() { }

        // Add a new shopping cart item
        public static bool AddItem(string productId) { return ShoppingCartDAO.AddItem(productId); }

        // Update the quantity of a shopping cart item
        public static bool UpdateItem(string productId, int quantity) { return ShoppingCartDAO.UpdateItem(productId, quantity); }

        // Remove a shopping cart item
        public static bool RemoveItem(string productId) { return ShoppingCartDAO.RemoveItem(productId); }

        // Retrieve shopping cart items
        public static DataTable GetItems() { return ShoppingCartDAO.GetItems(); }

        // Retrieve shopping cart items
        public static decimal GetTotalAmount() { return ShoppingCartDAO.GetTotalAmount(); }

        // Counts old shopping carts
        public static int CountOldCarts(byte days) { return ShoppingCartDAO.CountOldCarts(days); }

        // Deletes old shopping carts
        public static bool DeleteOldCarts(byte days) { return ShoppingCartDAO.DeleteOldCarts(days); }

        // Create a new order from the shopping cart
        public static string CreateOrder(string customerName, string customerEmail, string customerAdderss) { 
            return ShoppingCartDAO.CreateOrder(customerEmail,customerEmail,customerAdderss);
        }

        // gets product recommendations for the shopping cart
        public static DataTable GetRecommendations() { return ShoppingCartDAO.GetRecommendations(); }
    }
}
