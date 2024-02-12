using WS.Core.Entities.WSAggregate;
using WS.Core.Interfaces;

namespace WS.Core.Entities.ChemicalAggregate;

public class Product : BaseEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategory? ProductCategory { get; set; }
    public List<WarningSentence>? WarningSentences { get; set; }
}