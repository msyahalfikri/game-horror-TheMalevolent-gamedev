using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalController : MonoBehaviour
{
    [Header("General")]
    public GameObject activePage;
    public GameObject pageNum;
    public GameObject controlHint;
    public GameObject pickupText;
    public GameObject overlay;

    [Header("Page Assets")]
    public Sprite lockedEntry;
    public Sprite prologue;
    public Sprite collectible1;
    public Sprite collectible2;
    public Sprite collectible3;
    public Sprite collectible4;
    public Sprite collectible5;
    public Sprite collectible6;
    public Sprite collectible7;
    public Sprite collectible8;
    public Sprite epilogue;

    private bool isActive = false;

    public bool allItemsCollected = false;
    private int activePageNum = 0;
    public Sprite[] pages;
    private Stack<int> collectiblePages;
    private bool textActive = false;
    public float textTime = 1000;
    private float textTimer;
    private float DECAY = 200;

    [Header("Events")]
    public GameEvent onJournalStateChanged;

    void Start()
    {
        pages = new Sprite[10] { prologue, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry };
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
        collectiblePages = Shuffle(numbers);
        Display(false);
        ChangePageSprite(pages[activePageNum]);
        pickupText.SetActive(false);
        DisplayPickupText(null, "Collect Clues to Complete Your Journal!");
    }

    void Update()
    {
        if (textActive)
        {
            textTimer -= Time.deltaTime * DECAY;
            float THRESHOLD = 0.4f * textTime;
            if (textTimer < THRESHOLD)
            {
                byte opacity = (byte)(255 * (textTimer / THRESHOLD));
                pickupText.GetComponent<TextMeshProUGUI>().faceColor = new Color32(255, 255, 255, opacity);
            }
            if (textTimer < 0)
            {
                textActive = false;
                pickupText.SetActive(false);
            }
        }
    }

    public void Toggle(Component sender, object data)
    {
        isActive = (bool)data;
        Display(isActive);
    }

    public void Next(Component sender, object data)
    {
        if (isActive)
        {
            activePageNum++;
            if (activePageNum > 9) activePageNum = 9;
            ChangePageSprite(pages[activePageNum]);
        }
    }

    public void Prev(Component sender, object data)
    {
        if (isActive)
        {
            activePageNum--;
            if (activePageNum < 0) activePageNum = 0;
            ChangePageSprite(pages[activePageNum]);
        }
    }

    public void ChangePageSprite(Sprite sprite)
    {
        activePage.GetComponent<Image>().sprite = sprite;
        pageNum.GetComponent<TextMeshProUGUI>().text = string.Format("Page {0} of 10", activePageNum + 1);
    }

    public void Display(bool active)
    {
        activePage.SetActive(active);
        pageNum.SetActive(active);
        controlHint.SetActive(active);
        onJournalStateChanged.Raise(active);
        overlay.SetActive(active);
    }

    public void AddPage(Component sender, object data)
    {
        int page = collectiblePages.Pop();
        switch (page)
        {
            case 1:
                pages[1] = collectible1;
                break;
            case 2:
                pages[2] = collectible2;
                break;
            case 3:
                pages[3] = collectible3;
                break;
            case 4:
                pages[4] = collectible4;
                break;
            case 5:
                pages[5] = collectible5;
                break;
            case 6:
                pages[6] = collectible6;
                break;
            case 7:
                pages[7] = collectible7;
                break;
            case 8:
                pages[8] = collectible8;
                break;
        }
        activePageNum = 0;
        if (collectiblePages.Count == 0)
        {
            allItemsCollected = true;
            pages[9] = epilogue;
            DisplayPickupText(null, "All Journal Entry Collected, Time to Escape!");

        }
        else
        {
            DisplayPickupText(null, "Journal Entry " + (page + 1) + " Added");
        }
    }

    private static Stack<T> Shuffle<T>(IEnumerable<T> values)
    {
        var rand = new System.Random();

        var list = new List<T>(values);
        var stack = new Stack<T>();

        while (list.Count > 0)
        {
            // Get the next item at random.
            var index = rand.Next(0, list.Count);
            var item = list[index];

            // Remove the item from the list and push it to the top of the deck.
            list.RemoveAt(index);
            stack.Push(item);
        }

        return stack;
    }

    public void DisplayPickupText(Component component, object data)
    {
        string text = (string)data;
        pickupText.SetActive(true);
        pickupText.GetComponent<TextMeshProUGUI>().text = text;
        textTimer = textTime;
        textActive = true;
    }
}
