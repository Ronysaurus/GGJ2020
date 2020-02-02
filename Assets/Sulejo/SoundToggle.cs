using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{

public GameObject ObjectToDisable;
public GameObject ObjectToDisable2;
public GameObject ObjectToDisable3;
public GameObject ObjectToDisable4;
public static bool disabled = true;
public static bool disabled2 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void Change()
	{
	if(disabled){			
		ObjectToDisable.SetActive(false);
		ObjectToDisable2.SetActive(true);
		disabled = false;
		}
	else{
		ObjectToDisable.SetActive(true);
		ObjectToDisable2.SetActive(false);
		disabled = true;
		}
	}

public void ChangeScreen()
	{
	if(disabled2){			
		ObjectToDisable3.SetActive(false);
		ObjectToDisable4.SetActive(true);
		disabled2 = false;
		}
	else{
		ObjectToDisable3.SetActive(true);
		ObjectToDisable4.SetActive(false);
		disabled2 = true;
		}
	}
}

