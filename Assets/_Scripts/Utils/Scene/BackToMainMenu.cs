using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    public void LoadMainMenu() {
        Loader.Load(Loader.Scenes.MainMenu);
    }
}
