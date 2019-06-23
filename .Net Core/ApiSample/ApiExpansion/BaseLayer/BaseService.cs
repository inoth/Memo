namespace ApiExpansion.BaseLayer
{
    public class BaseService<H, E>
    where H : IBaseHandler<E>
    where E : class, new()
    {
        protected readonly H handler;
        public BaseService()
        {
            this.handler = (H)ServiceLocator.Instance.GetService(typeof(H));
        }
    }
}