using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Evidence")]
public class Evidence : ScriptableObject
{
	public enum EvidenceType
	{
		Textual, Imagery, Video, Audio
	}

	public EvidenceType evidenceType;
	public string evidenceTitle;
	public Sprite evidence;
}