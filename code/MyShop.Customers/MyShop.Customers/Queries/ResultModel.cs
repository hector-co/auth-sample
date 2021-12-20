namespace MyShop.Customers.Queries
{
    public class ResultModel<TData>
    {
        public TData Data { get; set; }
        public Dictionary<string, object> Meta { get; set; }
        public int? TotalCount { get; set; }
    }
}
