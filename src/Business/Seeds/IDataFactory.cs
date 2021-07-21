namespace Business.Seeds
{
    using System.Collections.Generic;

    public interface IDataFactory
    {
        public IEnumerable<TModel> Make<TModel>(string path);
    }
}
