namespace Introduction_ASP.NET_Core_MVC.Models.Product
{
    public class ProductViewModel
    {
        public ProductViewModel(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
