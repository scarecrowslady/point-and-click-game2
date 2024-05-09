using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class BookButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string bookName;

    public GameObject descText;

    // Start is called before the first frame update
    void Start()
    {      
        descText.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descText.GetComponent<TextMeshProUGUI>().text = bookName;
        descText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descText.SetActive(false);
    }
}
