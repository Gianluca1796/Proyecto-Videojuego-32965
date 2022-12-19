using System.Collections;
using UnityEngine;

using TMPro;

public class Dialogue : MonoBehaviour
{
    public Transform player;
    public Transform maskPos;
    public PlayerMove playerMove;
    public AudioSource walk;
    public AudioSource siren;
    public GameObject postProcessZone;
    public GameObject diaologueZone;
    public GameObject maskInTheFloor;

    #region DIALOGUE
    private bool isInZone;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;
    #endregion


    void Update()
    {
        if (isInZone && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NexDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];

            }
        }
        

    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());

    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            isInZone = true;
            Debug.Log("anda");
            playerMove.enabled = false;
            walk.enabled = false;

        }
    }
    private void NexDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            postProcessZone.SetActive(true);
            siren.Play();
            player.position = maskPos.position;
            maskInTheFloor.SetActive(true);
            diaologueZone.SetActive(false);
        }
    }


}