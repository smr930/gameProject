using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour
{
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 0.08f;
    public float CharacterRateMultiplier = 0.02f;

	public KeyCode DialogueInput = KeyCode.Space;

    private bool _isStringBeingRevealed = false;
    private bool _isDialoguePlaying = false;
    private bool _isEndOfDialogue = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;

	// Use this for initialization
	void Start ()
	{
	    _textComponent = GetComponent<Text>();
	    _textComponent.text = "Press 'Space' to interact with dialogue!";

        HideIcons();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
	    {
	        if (!_isDialoguePlaying)
	        {
                _isDialoguePlaying = true;
                StartCoroutine(StartDialogue());
            }
	        
	    }

		StartCoroutine (ChangeScene("QA_Scene"));
	}

    private IEnumerator StartDialogue()
    {
        int dialogueLength = DialogueStrings.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed)
        {
            if (!_isStringBeingRevealed)
            {
                _isStringBeingRevealed = true;
                StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLength)
                {
                    _isEndOfDialogue = true;
                }
            }

            yield return 0;
        }

        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
            }

            yield return 0;
        }

        HideIcons();
        _isEndOfDialogue = false;
        _isDialoguePlaying = false;
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        HideIcons();

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultiplier);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
            else
            {
                break;
            }
        }

        ShowIcon();

        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
            }

            yield return 0;
        }

        HideIcons();

        _isStringBeingRevealed = false;
        _textComponent.text = "";
    }

    private void HideIcons()
    {
        ContinueIcon.SetActive(false);
        StopIcon.SetActive(false);
    }

    private void ShowIcon()
    {
        if (_isEndOfDialogue)
        {
            StopIcon.SetActive(true);
            return;
        }

        ContinueIcon.SetActive(true);
    }

	private IEnumerator ChangeScene(string str) {
		if (_isEndOfDialogue) {
			Debug.Log ("End of dialogue, changing scene");
			yield return new WaitForSeconds(10);
			SceneManager.LoadScene (str);
		}
	}
}

