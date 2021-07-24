using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;

namespace BlazorApp.Shared
{
	public static class EntityHelper
	{
		public static T Clone<T>(T source)
		{
			var serialized = JsonSerializer.Serialize(source, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });
			return JsonSerializer.Deserialize<T>(serialized, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });
		}

		public static void ReplaceItem<T>(this Collection<T> col, Func<T, bool> match, T newItem)
		{
			var oldItem = col.FirstOrDefault(i => match(i));
			var oldIndex = col.IndexOf(oldItem);
			col[oldIndex] = newItem;
		}

		public static void Swap<T>(this ICollection<T> collection, T oldValue, T newValue)
		{
			// In case the collection is ordered, we'll be able to preserve the order
			var collectionAsList = collection as IList<T>;
			if (collectionAsList != null)
			{
				var oldIndex = collectionAsList.IndexOf(oldValue);
				collectionAsList.RemoveAt(oldIndex);
				collectionAsList.Insert(oldIndex, newValue);
			}
			else
			{
				// No luck, so just remove then add
				collection.Remove(oldValue);
				collection.Add(newValue);
			}

		}
	}
}
