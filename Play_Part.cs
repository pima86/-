using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Play_Part
{
    public abstract void Play();
}

class Pet_Select : Play_Part
{
    GameObject Agg_Select; //선택 후보를 담은 캔버스

    public Pet_Select(GameObject agg_select)
    {
        Agg_Select = agg_select;
    }

    public override void Play()
    {
        //알 주소 리스트를 생성
        Egg_Save.inst.Set_Index();

        //알 선택 UI 활성화
        Agg_Select.SetActive(true);
    }
}

class Use_Stamina : Play_Part
{
    TextMeshProUGUI Stamina_Text { get; set; }
    int Need_Stamina { get; set; }

    public Use_Stamina(TextMeshProUGUI stamina_text, int need_stamina)
    {
        Stamina_Text = stamina_text;
        Need_Stamina = need_stamina;
    }
    
    public override void Play()
    {
        Stamina_Text.text = (GameManager.Inst.Stamina -= Need_Stamina).ToString();
    }
}

public class PlayManager : MonoBehaviour
{
    #region 싱글톤
    public static PlayManager inst;
    private void Awake()
    {
        inst = this;
    }
    #endregion

    #region 상속 과정에서 컴포넌트 전달 목적 접근
    [SerializeField] GameObject Agg_Select; //선택 후보를 담은 캔버스
    [SerializeField] TextMeshProUGUI Stamina_Text;
    #endregion

    #region 설정하기
    [Header("설정하기")]
    public int Need_Stamina;
    #endregion

    public enum Turn { start, pet_Select, use_Stamina }
    public Turn turn
    {
        set
        {
            tn = value;

            Play_Part part;
            switch (value)
            {
                case Turn.pet_Select:
                    part = new Pet_Select(Agg_Select);
                    part.Play();
                    break;
                case Turn.use_Stamina:
                    part = new Use_Stamina(Stamina_Text, Need_Stamina);
                    part.Play();
                    break;
            }
        }
        get
        {
            return tn;
        }
    } Turn tn;

    private void Start()
    {
        turn = Turn.pet_Select;
    }
}
