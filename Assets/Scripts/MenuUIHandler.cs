using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected

        if (MainManager.Instance != null)
        {
            MainManager.Instance.TeamColor = color;
            Debug.Log(MainManager.Instance.TeamColor);
        }
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function
        //when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        if (MainManager.Instance != null)
        {
            ColorPicker.SelectColor(MainManager.Instance.TeamColor);
        }
    }

    private void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
        
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SaveColor(); 
        }
    }
    
    public void SaveColorClicked()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SaveColor();
        }
    }

    public void LoadColorClicked()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.LoadColor();
            ColorPicker.SelectColor(MainManager.Instance.TeamColor);
        }
    }
    
    
}
