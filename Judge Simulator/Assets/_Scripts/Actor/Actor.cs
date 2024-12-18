using System;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
	//generalized event
	public event Action<Actor> onActorClick;

	//invoke when player clicks on collider
	public virtual void OnMouseDown()
	{
		onActorClick?.Invoke(this);
	}
}