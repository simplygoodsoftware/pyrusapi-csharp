using System;
using System.Linq;

namespace PyrusApiClient.Extensions
{
	public static class Extensions
	{
		public static T GetAttribute<T>(this object member)
		{
			object[] attributes = null;
			var type = member as Type;
			if (type != null)
			{
				attributes = type.GetCustomAttributes(typeof(T), false);
			}
			else
			{
				var memberInfo = member.GetType().GetMember(member.ToString());

				if (memberInfo.Any())
				{
					attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
				}
			}

			if (attributes != null && attributes.Any())
			{
				return (T)attributes[0];
			}

			return default(T);
		}

		public static T GetPropertyAttribute<T>(this object member, string propertyName)
		{
			var type = member as Type;
			var attributes = type != null
				? type.GetProperty(propertyName)?.GetCustomAttributes(typeof(T), false)
				: member.GetType().GetProperty(propertyName)?.GetCustomAttributes(typeof(T), false);

			if (attributes != null && attributes.Any())
			{
				return (T)attributes[0];
			}

			return default(T);
		}
	}
}
