using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineStoreDAL.Models;
using OnlineStoreDAL;
using System.Data;

namespace OnlineStoreBLO
{
    public static class OrderBLO
    {
        static OrderBLO() { }
        // Retrieve the recent orders
        public static DataTable GetByRecent(int count) { return OrderDAO.GetByRecent(count); }

        // Retrieve orders that have been placed in a specified period of time
        public static DataTable GetByDate(string startDate, string endDate) { return OrderDAO.GetByDate(startDate, endDate); }

        // Retrieve orders that need to be verified or canceled
        public static DataTable GetUnverifiedUncanceled() { return OrderDAO.GetUnverifiedUncanceled(); }

        // Retrieve orders that need to be shipped/completed
        public static DataTable GetVerifiedUncompleted() { return OrderDAO.GetVerifiedUncompleted(); }

        // Retrieve order information
        public static OrderInfo GetInfo(string orderID) { return OrderDAO.GetInfo(orderID); }

        // Retrieve the order details (the products that are part of that order)
        public static DataTable GetDetails(string orderID) { return OrderDAO.GetDetails(orderID); }

        // Update an order
        public static void Update(OrderInfo orderInfo) { OrderDAO.Update(orderInfo); }

        // Mark an order as verified
        public static void MarkVerified(string orderId) { OrderDAO.MarkVerified(orderId); }

        // Mark an order as completed
        public static void MarkCompleted(string orderId) { OrderDAO.MarkCompleted(orderId); }

        // Mark an order as canceled
        public static void MarkCanceled(string orderId) { OrderDAO.MarkCanceled(orderId); }
    }
}
