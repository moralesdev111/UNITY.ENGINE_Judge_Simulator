using UnityEngine;

public abstract class Case : ScriptableObject
{
	public int caseID;
	public string caseName;
	public string caseDetails;

	public Person[] persons;
}
