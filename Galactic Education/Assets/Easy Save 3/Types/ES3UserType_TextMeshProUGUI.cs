using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("text")]
	public class ES3UserType_TextMeshProUGUI : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TextMeshProUGUI() : base(typeof(TMPro.TextMeshProUGUI)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TMPro.TextMeshProUGUI)obj;
			
			writer.WriteProperty("text", instance.text, ES3Type_string.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TMPro.TextMeshProUGUI)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "text":
						instance.text = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TextMeshProUGUIArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TextMeshProUGUIArray() : base(typeof(TMPro.TextMeshProUGUI[]), ES3UserType_TextMeshProUGUI.Instance)
		{
			Instance = this;
		}
	}
}