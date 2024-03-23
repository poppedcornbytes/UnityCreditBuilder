using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreditBuilder : MonoBehaviour
{
    [SerializeField]
    private VisualElement rootElement;
    [SerializeField]
    private UIDocument rootDocument;
    private void OnEnable()
    {
        rootElement = rootDocument.rootVisualElement;
        VisualElement background = new VisualElement();
        background.style.height = Length.Percent(100);
        background.style.width = Length.Percent(100);
        background.style.position = Position.Absolute;
        background.style.backgroundColor = new StyleColor(Color.blue);
        rootElement.Add(background);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
