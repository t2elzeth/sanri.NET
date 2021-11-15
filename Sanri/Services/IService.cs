namespace Sanri.Services
{
    public interface IService<T, TPayload>
    {
        public T Execute();

        public T Execute(TPayload payload);
    }
}