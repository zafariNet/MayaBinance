namespace MayaBinance.Domain.SeedWork
{



    public interface ICreationAuditedObject<out TCreator> : IMayHaveCreator<TCreator>
    {

    }
}
