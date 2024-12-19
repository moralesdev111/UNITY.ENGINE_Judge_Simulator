using System;
using TMPro;
using UnityEngine;
public static class UtilityClass
{
      public static void SubscribeObjectsToEvent<T>(T[] objects, Action<T> subscribeAction)
      {
		  if (objects == null || subscribeAction == null) return;

		    for (int i = 0; i < objects.Length; i++)
            {
                subscribeAction(objects[i]);
            }
       }

	public static void UnsubscribeObjectFromEvent<T>(T[] objects, Action<T> unsubscribeAction)
	{
		if (objects == null || unsubscribeAction == null) return;

		for (int i = 0; i < objects.Length; i++)
		{
			unsubscribeAction(objects[i]);
		}
	}

	public static void SetText(TextMeshProUGUI textField, string text)
	{
		textField.text = text;
	}

	public static void ClearText(params TextMeshProUGUI[] text)
	{
		for(int i = 0;i < text.Length;i++)
		{
			text[i].text = "";
		}
	}
}
