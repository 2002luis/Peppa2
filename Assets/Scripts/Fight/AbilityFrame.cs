using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityFrame : MonoBehaviour
{
    public RawImage frameImg, abilityImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeAbilityImg(Texture text)
    {
        abilityImg.texture = text;
    }

    public void changeFrameImg(Texture text)
    {
        frameImg.texture = text;
    }

    public void changeState(bool state)
    {
        frameImg.enabled = state;
        abilityImg.enabled = state;
    }
}
