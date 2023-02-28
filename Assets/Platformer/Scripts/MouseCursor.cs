using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseCursor : MonoBehaviour
{

    public GameObject guiController;
    public AudioManager audioManager;

    private void Start()
    {
        audioManager.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10f)) {
               ClickedGameObject(hit.transform.gameObject);
            }
        }
    }
    private void ClickedGameObject(GameObject Object)
    {
        Debug.Log("Hit something!" + Object.name);

        if (Object.tag == "Question") hitCoinBlock();
        audioManager.Play("BreakBlock");
        Destroy(Object);
    }

    private void hitCoinBlock()
    {
       audioManager.Play("Coin");
       guiController.GetComponent<GUIController>().UpdateCoinText();
    }

    
}
