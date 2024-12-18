using UnityEngine;

public abstract class Case : ScriptableObject
{
	public int caseID;
	public string caseName;
	public string caseDetails;
	public string[] chargesDescription;
	public Person[] persons;
	public Evidence[] evidence;
}
