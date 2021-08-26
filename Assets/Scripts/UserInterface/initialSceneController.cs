using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initialSceneController : MonoBehaviour
{
    [SerializeField] GameObject credits, menu;

    public void openCredits() {
        print("babu");
        credits.SetActive(true);
        menu.SetActive(false);
    }

    public void openMenu() {
        print("babo");
        menu.SetActive(true);
        credits.SetActive(false);
    }
}
