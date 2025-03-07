namespace EFCore_Day_2_Fluent_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }  
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
