namespace Seeds
{
    using System.Collections.Generic;
    using System.IO;
    using Business.Seeds;
    using Newtonsoft.Json;

    public class DataFactory : IDataFactory
    {
        public IEnumerable<TModel> Make<TModel>(string path)
        {
            string fullPath = $"../Seeds/Data/{path}";
            var json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<IEnumerable<TModel>>(json);
        }
    }
}
