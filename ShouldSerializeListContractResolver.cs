using System;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pyrus.ApiClient.JsonConverters
{
	internal class ShouldSerializeListContractResolver : DefaultContractResolver
	{
		public static readonly ShouldSerializeListContractResolver Instance = new ShouldSerializeListContractResolver();

		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			var property = base.CreateProperty(member, memberSerialization);
			var isDefaultValueIgnored = ((property.DefaultValueHandling ?? DefaultValueHandling.Ignore) & DefaultValueHandling.Ignore) != 0;
			if (isDefaultValueIgnored && !typeof(string).IsAssignableFrom(property.PropertyType) && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
			{
				bool NewShouldSerialize(object obj)
				{
					return !(property.ValueProvider.GetValue(obj) is ICollection collection) || collection.Count != 0;
				}

				var oldShouldSerialize = property.ShouldSerialize;
				property.ShouldSerialize = oldShouldSerialize != null
					? o => oldShouldSerialize(o) && NewShouldSerialize(o)
					: (Predicate<object>) NewShouldSerialize;
			}

			return property;
		}
	}
}
