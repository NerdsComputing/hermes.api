namespace Seeds
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Business.Seeds;
    using Newtonsoft.Json;

    public class DataFactory : IDataFactory
    {
        public IEnumerable<TModel> Make<TModel>(string path)
        {
            var assemblyPath = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = $"{assemblyPath}/Data/{path}";
            var json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<IEnumerable<TModel>>(json);
        }
    }
}
