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
    private int activePageNum = 0;
    private Sprite[] pages;

    void Start()
    {
        pages = new Sprite[10] {lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry, lockedEntry};
        Display(false);
        ChangePageSprite(pages[activePageNum]);
    }

    public void Toggle(Component sender, object data)
    {
        isActive = !isActive;
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
    }
}
