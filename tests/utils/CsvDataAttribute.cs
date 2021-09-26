using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;
using System.IO;
using System.Linq;

namespace tests.utils
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =false)]
    public class CsvDataAttribute : DataAttribute
    {
        private readonly string fileName;

        public CsvDataAttribute(string fileName)
        {
            this.fileName = fileName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var prms = testMethod.GetParameters();
            return DataSource(prms.Select(prms => prms.GetType()).ToArray());
        }

        private IEnumerable<Object[]> DataSource(Type[] parameterTypes)
        {
            using(var r = new StreamReader(this.fileName))
            {
                var header = r.ReadLine();
                while(true)
                {
                    var line = r.ReadLine();
                    if(line == null)
                    {
                        break;
                    }
                    var data = line.Split(',');
                    yield return data;
                }
            }
        }
    }
}
