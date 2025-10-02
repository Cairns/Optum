using VendingMachineEventDriven.Models;

namespace VendingMachineEventDriven.Events
{
    public class ProductSelectedEventArgs : EventArgs
    {
        public Product Product { get; }

        public ProductSelectedEventArgs(Product product)
        {
            Product = product;
        }
    }
}
