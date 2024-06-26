using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

class BG_Manager : MonoBehaviour
{
    #region 싱글톤
    public static BG_Manager inst;
    private void Awake()
    {
        inst = this;
    }
    #endregion

    public Tool_Item tool_item;
    public Tool_state tool_state;
    public Tool_pet tool_pet;
    public Tool_bg tool_bg;

    public Pet_ControlTower pet;
    public IState istate;

    public void Get_Random_Pet()
    {
        istate = GameManager.inst.Random_Pet();

        tool_state.Active_True(true);
        StartCoroutine(tool_state.SetUp());

        tool_pet.SetUp(istate.Sprite);
    }

    public void State_SetUp(int[] ints)
    {
        pet.Food += ints[0];
        pet.Wash += ints[1];
        pet.Happy += ints[2];


        StartCoroutine(tool_state.SetUp());
    }

    public void Get_Evolution_Pet()
    {
        istate = Evolution_This();

        StartCoroutine(Coroutine_Evolution(istate));
    }

    public IState Evolution_This()
    {
        foreach (IState s in istate.Evolutions)
        {
            if (Evolution_Search.inst.evolutions[s.Name].Evolution())
                return s;
        }
        return null;
    }

    public IEnumerator Coroutine_Evolution(IState state)
    {
        yield return new WaitForSeconds(0.8f);

        tool_pet.SetUp(state.Sprite);
    }
}

#region Tool
[Serializable]
class  Tool_Item
{
    public int gold;

    public bool SetUp(int n)
    {
        if (n < 0 && gold < n * -1) return false;

        gold += n;
        return true;
    }
}

[System.Serializable]
class Tool_state
{
    public GameObject Canvas;
    public Image[] Food;
    public Image[] Wash;
    public Image[] Happy;

    float food_fill = 0;
    float wash_fill = 0;
    float happy_fill = 0;

    public void Active_True(bool bo)
    {
        Canvas.gameObject.SetActive(bo);
    }

    public IEnumerator SetUp()
    {
        float timer = Time.deltaTime * 10f;
        float range = 0.001f;

        Pet_ControlTower p = BG_Manager.inst.pet;
        food_fill = p.Food / GameManager.inst.Max_Food;
        wash_fill = p.Wash / GameManager.inst.Max_Wash;
        happy_fill = p.Happy / GameManager.inst.Max_Happy;
        
        bool Food_Need = true;
        bool Wash_Need = true;
        bool Happy_Need = true;
        do
        {
            if (Food_Need)
                Food[1].fillAmount = Mathf.Lerp(Food[1].fillAmount, food_fill, timer);

            if (Wash_Need)
                Wash[1].fillAmount = Mathf.Lerp(Wash[1].fillAmount, wash_fill, timer);

            if (Happy_Need)
                Happy[1].fillAmount = Mathf.Lerp(Happy[1].fillAmount, happy_fill, timer);

            Food_Need = Food[1].fillAmount < food_fill - range || Food[1].fillAmount > food_fill + range;
            Wash_Need = Wash[1].fillAmount < wash_fill - range || Wash[1].fillAmount > wash_fill + range;
            Happy_Need = Happy[1].fillAmount < happy_fill - range || Happy[1].fillAmount > happy_fill + range;

            if (Food_Need)
            {
                if (Food[1].fillAmount < food_fill - range) Food[1].color = Color.green;
                else if (Food[1].fillAmount > food_fill + range) Food[1].color = Color.red;
            }
            else Food[1].color = Color.white;

            if (Wash_Need)
            {
                if (Wash[1].fillAmount < wash_fill - range) Wash[1].color = Color.green;
                else if (Wash[1].fillAmount > wash_fill + range) Wash[1].color = Color.red;
            }
            else Wash[1].color = Color.white;

            if (Happy_Need)
            {
                if (Happy[1].fillAmount < happy_fill - range) Happy[1].color = Color.green;
                else if (Happy[1].fillAmount > happy_fill + range) Happy[1].color = Color.red;
            }
            else Happy[1].color = Color.white;

            yield return new WaitForSeconds(0.01f);
        }
        while (Food_Need || Wash_Need || Happy_Need);
    }
}

[System.Serializable]
class Tool_pet
{
    public Animator anim;
    public Image image;

    public void Play(string Name)
    {
        anim.Play(Name, 0, -1f);
    }

    public void SetUp(Sprite sprite)
    {
        image.sprite = sprite;
    }
}

[System.Serializable]
class Tool_bg
{
    public Sprite[] sprites;
    public Image image;

    public void SetUp(string Name)
    {
        image.sprite = Array.Find<Sprite>(sprites, x => x.name == Name);
    }
}
#endregion
