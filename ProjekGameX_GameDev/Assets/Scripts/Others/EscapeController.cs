using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeController : MonoBehaviour
{
    public JournalController journalController;
    public EscapeColliderController escapeColliderController;
    public LevelLoaderScript levelLoaderScript;
    public GameObject escapeCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (journalController.allItemsCollected)
        {
            escapeCollider.SetActive(true);
        }
    }

    public void trytoEscape()
    {
        if (escapeColliderController.isColliding)
        {
            levelLoaderScript.LoadEnding();
        }
    }
}
