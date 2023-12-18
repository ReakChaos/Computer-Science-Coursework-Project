using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button raceButton = GetComponent<Button>();
        if (raceButton)
        {
            raceButton.onClick.AddListener(ButtonClicked);
        }
    }

    void ButtonClicked()
    {
        Debug.Log("Clicekd button: " + gameObject.name);
    }
}
