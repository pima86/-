using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Story_Manager : MonoBehaviour
{
    #region 싱글톤
    public static Story_Manager inst;
    private void Awake()
    {
        inst = this;
    }
    #endregion

    public Story story;
    private void Start()
    {
        story = new Prologue();
        Start_Story();
    }

    public void Start_Story()
    {
        for (int i = 0; i < 3; i++)
        {
            this.subs[i].main_obj.SetActive(false);
            this.subs[i].tmp.text = "";
            this.subs[i].sub = null;
        }
        story.Play();
    }

    public Sub_obj[] subs = new Sub_obj[3];
    public void Sub_Setting()
    {
        List<Sub> subs = story.subs;

        for (int i = 0; i < subs.Count; i++)
        {
            this.subs[i].main_obj.SetActive(true);
            this.subs[i].tmp.text = subs[i].txt;
            this.subs[i].sub = subs[i];
        }
    }

    #region 이벤트 트리거
    public void OnClick_Select_Sub(int n)
    {
        subs[n].sub.Next_Event();
        Start_Story();
    }

    [SerializeField] GameObject Story;
    [SerializeField] GameObject State;
    public void OnClick_Story_State()
    {
        bool bo = Story.activeSelf;
        Story.SetActive(!bo);
        State.SetActive(bo);
    }
    #endregion
}

[System.Serializable]
public class Sub_obj
{
    public GameObject main_obj;
    public TextMeshProUGUI tmp;
    public Sub sub;
}
