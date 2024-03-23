using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class CreditBuilder : MonoBehaviour
{
    [SerializeField]
    private VisualElement rootElement;
    [SerializeField]
    private UIDocument rootDocument;
    [SerializeField]
    private BackgroundGenerator backgroundGenerator;
    private void OnEnable()
    {
        rootElement = rootDocument.rootVisualElement;
        VisualElement background = new VisualElement();
        background.style.height = Length.Percent(100);
        background.style.width = Length.Percent(100);
        background.style.position = Position.Absolute;
        background.style.backgroundColor = new StyleColor(backgroundGenerator.BackgroundColour);
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

[CustomEditor(typeof(CreditBuilder))]
[CanEditMultipleObjects]
public class BackgroundGeneratorEditor : Editor
{
    SerializedProperty backgroundGenerator;
    SerializedProperty _fillTypeProperty;
    SerializedProperty _backgroundColorProperty;
    SerializedProperty _backgroundImageProperty;
    private void OnEnable()
    {
        backgroundGenerator = serializedObject.FindProperty("backgroundGenerator");
        _fillTypeProperty = backgroundGenerator.FindPropertyRelative("_fillType");
        _backgroundColorProperty = backgroundGenerator.FindPropertyRelative("_backgroundColour");
        _backgroundImageProperty = backgroundGenerator.FindPropertyRelative("_backgroundImage");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_fillTypeProperty);
        BackgroundFillType selectedFillType = (BackgroundFillType)_fillTypeProperty.intValue;
        if (selectedFillType == BackgroundFillType.Colour)
        {
            EditorGUILayout.PropertyField(_backgroundColorProperty);
        }
        else if (selectedFillType == BackgroundFillType.Image)
        {
            EditorGUILayout.PropertyField(_backgroundImageProperty);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
