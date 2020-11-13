namespace MayaBinance.Domain.SeedWork
{
   

    public interface IModifyAuditedObject<out TModifier> :IMayHaveModifier<TModifier>,
        ICreationAuditedObject<TModifier>
    {

    }
}
