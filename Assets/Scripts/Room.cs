using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    //public Enemy[] enemies;
    //public Pot[] pots;
    public GameObject virtualCamera;
    
    [Header("Trigger Location Name")]
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    [SerializeField] [Tooltip("In seconds")] float timeOnScreen = 3f;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            /*
            //Activate all enemies and pots
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], true);
            }
            */
            virtualCamera.SetActive(true);

            if (needText)
            {
                StartCoroutine(PlaceNameCo());
            }
        }
    }

    private IEnumerator PlaceNameCo()
    {
        //TODO: fix bug that occurs when switching screens too fast
        //TODO: add sound effect and fade effect
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(timeOnScreen);
        text.SetActive(false);
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            /*
            //Deactivate all enemies and pots
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], false);
            }
            */
            virtualCamera.SetActive(false);
        }
    }

    void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
