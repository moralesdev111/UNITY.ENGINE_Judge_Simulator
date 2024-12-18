using UnityEngine;

[CreateAssetMenu(fileName ="Person")]
public class Person : ScriptableObject
{
	public Role role;
	public string personName;
	public string personGender;
	public string personAge;
	public string[] dialogues;
	public enum Role
	{
		defendant,
		plaintiff,
		witness
	}
}
