using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DeactivateButtonIfInputNotInteger : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button button;
    
    private void Start()
    {
        button.interactable = false;
    }
    
    public void CheckInput()
    {
        button.interactable = int.TryParse(inputField.text, out var result);
    }
    
}
