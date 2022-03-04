using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("item", "position")]
	public class ES3UserType_Stuff : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Stuff() : base(typeof(Stuff)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (Stuff)obj;
			
			writer.WriteProperty("item", instance.item, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(Item)));
			writer.WriteProperty("position", instance.position, ES3Type_Vector3.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (Stuff)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "item":
						instance.item = reader.Read<Item>();
						break;
					case "position":
						instance.position = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			Item item = null;
			Vector3 vector3 = new Vector3(0.0f,0.0f,0.0f);
			var instance = new Stuff(item, vector3);
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_StuffArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StuffArray() : base(typeof(Stuff[]), ES3UserType_Stuff.Instance)
		{
			Instance = this;
		}
	}
}