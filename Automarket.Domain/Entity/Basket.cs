namespace Automarket.Domain.Entity
{
    public class Basket
    {
        public long Id { get; set; }
        
        public User User { get; set; }
        
        public long UserId { get; set; }
        
        public List<Order> Orders { get; set; }
    }
}