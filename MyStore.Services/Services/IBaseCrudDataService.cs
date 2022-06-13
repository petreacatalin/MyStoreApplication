using System.Collections.Generic;

namespace MyStore.Services.Services
{
    public interface IBaseCrudDataService<TDto,TEntity> where TEntity : class 
                                                         where TDto : class
    {
        IEnumerable<TDto> Get();
        void Delete(int? itemId);
        TDto GetById(int itemId);
        TDto Insert(TDto item);
        void Update(TDto item, int itemId);

    }
}