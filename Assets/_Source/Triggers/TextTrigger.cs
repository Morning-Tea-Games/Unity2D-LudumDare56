using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public TMP_Text _text;
    public string[] textOptions;

    void Start()
    {
        _text.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _text.gameObject.SetActive(true);
            _text.text = textOptions[Random.Range(0, textOptions.Length)];
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _text.gameObject.SetActive(false);
    }
}
