using UnityEngine;

[CreateAssetMenu(fileName = "Evidence")]
public class Evidence : ScriptableObject
{
	public enum EvidenceType
	{
		Textual, Imagery, Video, Audio
	}

	public EvidenceType evidenceType;
	public string evidenceTitle;
	public string filePath;
}