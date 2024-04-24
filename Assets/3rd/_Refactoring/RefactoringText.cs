using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RefactoringText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI indicateText;

    // Start is called before the first frame update
    void Start()
    {
        indicateText.text = "Please Press Button";
    }

    public void OnPressButton()
    {
        indicateText.text = "Pressed!!";
    }
}
