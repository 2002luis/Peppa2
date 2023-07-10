using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    public AbilityFrame[] abilities = new AbilityFrame[4];
    public Texture selectedBorder, unselectedBorder;

    public void setEnabled(bool state)
    {
        for(int i = 0; i < 4; i++) this.setEnabled(state, i);
    }

    public void setEnabled(bool state, int num)
    {
        abilities[num].changeState(state);
    }

    public void select(int num)
    {
        for (int i = 0; i < 4; i++) abilities[i].changeFrameImg(unselectedBorder);
        abilities[num].changeFrameImg(selectedBorder);
    }
}
