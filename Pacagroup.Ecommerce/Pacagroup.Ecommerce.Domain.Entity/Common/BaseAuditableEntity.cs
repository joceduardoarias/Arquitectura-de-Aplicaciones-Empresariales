using Pacagroup.Ecommerce.Domain.Entities;

namespace Pacagroup.Ecommerce.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
