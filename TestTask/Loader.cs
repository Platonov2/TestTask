using Newtonsoft.Json;

namespace TestTask
{
    internal class Loader
    {
        public List<Pallet> LoadDataFromJson(string jsonPath)
        {
            using StreamReader reader = new(jsonPath);
            string json = reader.ReadToEnd();
            List<Pallet> pallets = JsonConvert.DeserializeObject<List<Pallet>>(json);

            return pallets;
        }
    }
}
