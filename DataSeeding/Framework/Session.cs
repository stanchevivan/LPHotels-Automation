using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fourth.TH.Automation.RestDriver;
using RestSharp.Extensions;
using TechTalk.SpecFlow;

namespace DataSeeding.Framework
{
    public static class Session
    {
        private const string ResponseSetName = "response";

        public static void Set(object data, string key)
        {
            try
            {
                ScenarioContext.Current.Add(key, data);
            }
            catch (ArgumentException e)
            {
                throw new SessionException(key, e);
            }
        }

        public static void Set(object data, string key, bool overwrite)
        {
            if (overwrite)
            {
                ScenarioContext.Current.Remove(key);
            }

            Set(data, key);
        }

        public static T Get<T>(string key)
        {
            try
            {
                return ScenarioContext.Current.Get<T>(key);
            }
            catch (KeyNotFoundException e)
            {
                throw new SessionException(key, e);
            }
        }

        public static IResponse GetResponse(string name = ResponseSetName)
        {
            return Get<IResponse>(name);
        }

        public static void SetResponse(object data, string name)
        {
            if (ScenarioContext.Current.ContainsKey(name))
            {
                ScenarioContext.Current.Remove(name);
            }

            Set(data, name);
        }

        public static void SetResponse(object data)
        {
            SetResponse(data, ResponseSetName);
        }

        public static IEnumerable<object> GetAll(TypeInfo type)
        {
            var dict = ScenarioContext.Current.Where(x => x.Value != null && x.Value.GetType() == type);
            var list = dict.Select(x => x.Value.ChangeType(type)).ToList();
            return list;
        }

        public static IEnumerable<object> GetAll()
        {
            var dict = ScenarioContext.Current.Where(x => x.Value != null);
            var list = dict.Select(x => x.Value).ToList();
            return list;
        }
    }
}
