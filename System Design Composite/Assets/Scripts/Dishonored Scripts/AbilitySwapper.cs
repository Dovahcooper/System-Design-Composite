using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwapper : MonoBehaviour
{
    public List<Ability> abilities;

    public int currentAbility = 0;
    public int prevAbility = 1;

    private void Awake()
    {
        Ability temp = GetComponent<Blink>();
        abilities.Add(temp);
        temp = GetComponent<LongBlink>();
        abilities.Add(temp);

        foreach(Ability a in abilities)
        {
            a.enabled = false;
        }
        abilities[currentAbility].enabled = true;
    }
}
