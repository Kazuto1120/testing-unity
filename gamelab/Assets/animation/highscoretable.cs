using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highscoretable : MonoBehaviour
{
    private Transform entrycontainer;
    private Transform entryTemplate;
    private void Awake()
    {
        entrycontainer = transform.Find("container");
        entryTemplate = transform.Find("entry");

        entryTemplate.gameObject.SetActive(false);
        float templateHeight = 20f;
        for(int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entrycontainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
}
