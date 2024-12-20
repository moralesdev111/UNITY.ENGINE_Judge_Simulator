using UnityEngine;

public class PersonController : MonoBehaviour
{
    [SerializeField] private CaseManager caseManager;
    [SerializeField] private GameObject[] casePeople;
    [SerializeField] private GameObject personPrefab;
	[SerializeField] private Transform[] witnessSpawnLocations;
	[SerializeField] private Transform[] plaintiffProsecutorSpawnLocations;
	[SerializeField] private Transform[] defendantSpawnLocations;


	private void OnEnable()
    {
        caseManager.onStartCase += InstantiatePeopleAccordingToRole;
		caseManager.onEndCase += CleanPeopleCaseEnd;
	}

        private void OnDisable()
    {
		caseManager.onStartCase -= InstantiatePeopleAccordingToRole;
		caseManager.onEndCase += CleanPeopleCaseEnd;
	}

	private void InstantiatePeopleAccordingToRole(Case caseInstance)
	{
		int plaintiffCounter = 0;
		int defendantCounter = 0;
		int witnessCounter = 0;

		casePeople = new GameObject[caseInstance.persons.Length];

		for (int i = 0; i < caseInstance.persons.Length; i++)
		{
			if (caseInstance.persons[i].role == Person.Role.plaintiff ||
				caseInstance.persons[i].role == Person.Role.plaintiffLawyer ||
				caseInstance.persons[i].role == Person.Role.prosecutor)
			{
				if (plaintiffCounter < plaintiffProsecutorSpawnLocations.Length)
				{
					GameObject person = Instantiate(personPrefab, plaintiffProsecutorSpawnLocations[plaintiffCounter].position, Quaternion.identity);
					casePeople[i] = person;
					plaintiffCounter++;
				}
			}
			else if (caseInstance.persons[i].role == Person.Role.defendant ||
					 caseInstance.persons[i].role == Person.Role.defendantLawyer)
			{
				if (defendantCounter < defendantSpawnLocations.Length)
				{
					GameObject person = Instantiate(personPrefab, defendantSpawnLocations[defendantCounter].position, Quaternion.identity);
					casePeople[i] = person;
					defendantCounter++;
				}
			}
			else
			{
				if (witnessCounter < witnessSpawnLocations.Length)
				{
					GameObject person = Instantiate(personPrefab, witnessSpawnLocations[witnessCounter].position, Quaternion.identity);
					casePeople[i] = person;
					witnessCounter++;
				}
			}
		}
	}

	private void CleanPeopleCaseEnd()
	{
		for (int i = 0; i < casePeople.Length; i++)
		{
			if (casePeople[i] != null)
			{
				Destroy(casePeople[i]);
			}
		}
		casePeople = null;
	}
}
