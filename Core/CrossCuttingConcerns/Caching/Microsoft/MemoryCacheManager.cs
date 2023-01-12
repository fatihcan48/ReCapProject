using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        // Microsoft içerisindeki cache için hazır kütüphaneyi kullanıyoruz.
        // Burada hazır bir sistem için yeniden kendi metodlarımızı kullanmamızın nedeni, ilerde cache sisteminin 
        // değişmesine karşı yapımızı korumuş oluyoruz. ICacheManager sayesinde... (Adapter Pattern)

        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();   // ServiceTool sayesinde istediğimiz serviceleri ekleyip, çalıştırabiliyoruz.
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
  
            return _memoryCache.Get<T>(key);
            
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);     // Sadece bool dönmesi için out devre dışı bıraktık.
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)   // Çalışma anında bellekten silme...(Reflection)
        {
            var coherentState = typeof(MemoryCache).GetField("_coherentState", BindingFlags.NonPublic | BindingFlags.Instance);
            var coherentStateValue = coherentState.GetValue(_memoryCache);
            var entriesCollection = coherentStateValue.GetType().GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);

            var entriesCollectionValue = entriesCollection.GetValue(coherentStateValue) as ICollection;

            var keys = new List<string>();

            if (entriesCollectionValue != null)
            {
                foreach (var item in entriesCollectionValue)
                {
                    var methodInfo = item.GetType().GetProperty("Key");

                    var value = methodInfo.GetValue(item);

                    keys.Add(value.ToString());
                }
            }




            //var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection",
            //    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            //var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            //List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            //foreach (var cacheItem in cacheEntriesCollection)
            //{
            //    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
            //    cacheCollectionValues.Add(cacheItemValue);
            //}

            var regex = new Regex(pattern, RegexOptions.Singleline |  RegexOptions.IgnoreCase);
            var keysToRemove = keys.Where(key => regex.IsMatch(key)).ToList();


              //  keys.Where(d => d.Contains(regex.ToString())).ToList();
            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
