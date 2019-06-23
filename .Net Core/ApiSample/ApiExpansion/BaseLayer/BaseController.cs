using Microsoft.AspNetCore.Mvc;

namespace ApiExpansion.BaseLayer
{
    public abstract class BaseController<S, E> : ControllerBase
    where S : IBaseService<E>
    where E : class, new()
    {
        protected readonly S service;

        public BaseController()
        {
            this.service = (S)ServiceLocator.Instance.GetService(typeof(S));
        }
    }
}