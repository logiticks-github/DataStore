using DataStore.Models;
using Mobility.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;


using Xamarin.Forms;

[assembly: Dependency(typeof(DataStore.Data.MockDataStore))]
namespace DataStore.Data
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;
        string fileName = "DataStore.Data.Data.PCLTextResource.txt";

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;
            string text = "";
            Stream stream = default(Stream);
            try
            {
                var assembly = typeof(MockDataStore).GetTypeInfo().Assembly;
                stream = assembly.GetManifestResourceStream(fileName);

                using (var reader = new System.IO.StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
                DataResult data = JsonConvert.DeserializeObject<DataResult>(text);

                items = new List<Item>();
                foreach (Item item in data.Collection)
                {
                    items.Add(item);
                }
            }
            catch (Exception ex)
            {
                text = string.Empty;
            }
            finally
            {
                stream.Dispose();
            }
            isInitialized = true;
        }
    }
}
