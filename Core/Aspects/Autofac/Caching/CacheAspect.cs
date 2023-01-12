using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 30)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            // methodName ile key değerini oluşturuyoruz. Reflectedtype: namespace+class ismi verir. Ardından metod ismi ekleniyor.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

            var arguments = invocation.Arguments.ToList();   

            // parametre değerleri mevcutsa metod name ile birleştiriyoruz.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            if (_cacheManager.IsAdd(key))    // Cache'de girilen key değerine ait kayıt varmı bakıyoruz.
            {
                invocation.ReturnValue = _cacheManager.Get(key);    // Varsa o kaydı getir.
                return;
            }
            invocation.Proceed();      // Yoksa metodu çalıştır.
            _cacheManager.Add(key, invocation.ReturnValue, _duration);     // Ve cache'e bu işlemi kaydet.
        }
    }
}
