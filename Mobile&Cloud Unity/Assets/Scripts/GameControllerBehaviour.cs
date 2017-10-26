using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerBehaviour : MonoBehaviour
{
    public GameObject inventario = null;
    public Image[] slots = null;
    public Sprite[] itemSprites = null;

    private bool isInventarioOnCooldown = false;
    private float inventarioCooldown = 0.0f;

	void Start ()
    {
        InitializeComponents();
	}
	
	void Update ()
    {
        GetInputs();
        ManageStuff();
	}

    private void InitializeComponents()
    {
        inventario.SetActive(false);
        isInventarioOnCooldown = false;
    }

    private void GetInputs()
    {
        if (Input.GetAxisRaw("Abrir Inventário") != 0.0f && !isInventarioOnCooldown && !inventario.activeInHierarchy)
        {
            inventario.SetActive(true);
            isInventarioOnCooldown = true;
        }
        else if (Input.GetAxisRaw("Abrir Inventário") != 0.0f && !isInventarioOnCooldown && inventario.activeInHierarchy)
        {
            inventario.SetActive(false);
            isInventarioOnCooldown = true;
        }
    }

    private void ManageStuff()
    {
        if(isInventarioOnCooldown)
        {
            inventarioCooldown += Time.deltaTime;

            if(inventarioCooldown >= 0.5f)
            {
                isInventarioOnCooldown = false;
            }
        }


    }
}
