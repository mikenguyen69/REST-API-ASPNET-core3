using Catalog.Domain.Entities;
using Catalog.Domain.Responses;
using Catalog.Domain.Requests.Item;

namespace Catalog.Domain.Mappers
{
    public interface IItemMapper
    {
        Item Map(AddItemRequest request);
        Item Map(EditItemRequest request);
        ItemResponse Map(Item request);
    }
}