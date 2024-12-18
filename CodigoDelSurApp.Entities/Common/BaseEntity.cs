using CodigoDelSurApp.Domain.Common.Interface;

namespace CodigoDelSurApp.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
