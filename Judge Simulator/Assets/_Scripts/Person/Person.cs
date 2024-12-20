using UnityEngine;

[CreateAssetMenu(fileName ="Person")]
public class Person : ScriptableObject
{
	public Role role;
	public string personName;
	public string personSurname;
	public string personGender;
	public string personAge;
	public bool mentalSanity;
	public bool criminalRecord;
	public int fingerprintID;
	public string[] dialogues;
	public enum Role
	{
		defendant,
		prosecutor,
		plaintiff,
		witness,
		plaintiffLawyer,
		defendantLawyer
	}
}
