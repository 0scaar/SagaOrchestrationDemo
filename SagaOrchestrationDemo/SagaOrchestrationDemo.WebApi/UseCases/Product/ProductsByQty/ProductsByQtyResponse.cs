namespace SagaOrchestrationDemo.WebApi.UseCases.Product.ProductsByQty
{
    public class ProductsByQtyResponse
    {
        public string Name { get; private set; }
        public short Quantity { get; private set; }

        public ProductsByQtyResponse(string name, short quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
