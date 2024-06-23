using System.Collections.Generic;
using System.Text;
using Random = UnityEngine.Random;

public abstract class Story
{
    public string txt { get; set; }
    public List<Sub> subs { get; set; } = new List<Sub>();

    public virtual void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

public abstract class Sub
{
    public string txt { get; set; }

    public virtual void Play()
    {
        Story_Manager.inst.Start_Story();
    }

    public abstract void Next_Event();
}

#region 어느 날, 당신은 숲 속을 걷다가 빛나는 무언가를 발견했습니다.
public class Prologue : Story
{
    public Prologue()
    {
        txt = "어느 날,\n당신은 숲 속을 걷다가 빛나는 무언가를 발견했습니다. 그 물체는 반쯤 땅에 묻혀 있었고, 가까이 다가가서 보니 그것은 알처럼 보였습니다.";

        subs.Add(new Sub_Prologue());
    }
}

class Sub_Prologue : Sub
{
    public Sub_Prologue()
    {
        txt = "살펴본다.";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Prologue_1();
    }
}
#endregion

#region 알의 표면은 매끄럽고 따뜻했습니다.
public class Prologue_1 : Story
{
    public Prologue_1()
    {
        txt = "알의 표면은 매끄럽고 따뜻했습니다.\n당신은 알을 귀에 대고 듣기 시작했습니다. 약하게 들려오는 소리가 당신의 마음을 두근거리게 했습니다.";

        subs.Add(new Sub_Prologue_1_1());
        subs.Add(new Sub_Prologue_1_2());
    }

    public override void Play()
    {
        BG_Manager.inst.Get_Random_Pet();
        BG_Manager.inst.tool_pet.Play("Enter");

        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Sub_Prologue_1_1 : Sub
{
    public Sub_Prologue_1_1()
    {
        txt = "집으로 데려간다.";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Prologue_2();
    }
}

class Sub_Prologue_1_2 : Sub
{
    public Sub_Prologue_1_2()
    {
        txt = "두고간다.";
    }

    public override void Next_Event()
    {
        //story = new Prologue_2();
    }
}
#endregion

#region 알을 조심히 내려놓았습니다.
public class Prologue_2 : Story
{
    public Prologue_2()
    {
        txt = "알을 조심히 내려놓았습니다.\n곧 알이 부화하려고 한다는 사실을 직감했고 당신은 숨을 죽이며 지켜봤습니다.";

        subs.Add(new Sub_Prologue_2_1());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_bg.SetUp("Dorm 3");
        BG_Manager.inst.tool_pet.Play("Shake");

        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Sub_Prologue_2_1 : Sub
{
    public Sub_Prologue_2_1()
    {
        txt = "두근두근";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Hatch_1();
    }
}
#endregion

#region 알의 한쪽이 조심스럽게 열리기 시작했습니다.
public class Hatch_1 : Story
{
    public Hatch_1()
    {
        txt = "알의 한쪽이 조심스럽게 열리기 시작했습니다.\n알 속의 생명체는 힘겹게 머리를 내밀고, 주변을 살피며 천천히 알껍데기에서 나왔습니다. 당신은 경이로운 눈으로 그 광경을 지켜봤습니다.";

        subs.Add(new Hatch_1_1());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_pet.Play("Hatch");
        BG_Manager.inst.Get_Evolution_Pet();

        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Hatch_1_1 : Sub
{
    public Hatch_1_1()
    {
        txt = "하루를 시작한다.";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Main();
    }
}
#endregion

#region 오늘은 무엇을 할까요?
public class Main : Story
{
    public Main()
    {
        GameManager.inst.Day++;


        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(GameManager.inst.Day.ToString());
        stringBuilder.Append("일차,\n하루가 시작되었습니다.\n오늘은 무엇을 할까요?");
        txt = stringBuilder.ToString();


        subs.Add(new Main_1());
        subs.Add(new Main_2());

        //튜토 끝나고 생성되도록
        subs.Add(new Main_3());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Main_1 : Sub
{
    public Main_1()
    {
        txt = "돌보기";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Care();
    }
}

class Main_2 : Sub
{
    public Main_2()
    {
        txt = "외출하기";
    }

    public override void Next_Event()
    {
        //story = new Care();
    }
}

class Main_3 : Sub
{
    public Main_3()
    {
        txt = "이별하기";
    }

    public override void Next_Event()
    {
        //story = new Care();
    }
}
#endregion

#region 돌보기
public class Care : Story
{
    public Care()
    {
        txt = "펫은 당신과의 시간을 기대하고 있습니다.\n당신의 작은 움직임 하나하나에 귀를 기울이고 있습니다.";


        subs.Add(new Care_1());
        subs.Add(new Care_2());
        subs.Add(new Care_3());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Care_1 : Sub
{
    public Care_1()
    {
        txt = "밥주기";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Eating_1();
    }
}

class Care_2 : Sub
{
    public Care_2()
    {
        txt = "목욕하기";
    }

    public override void Next_Event()
    {
        //story = new Eating_1();
    }
}

class Care_3 : Sub
{
    public Care_3()
    {
        txt = "놀아주기";
    }

    public override void Next_Event()
    {
        //story = new Eating_1();
    }
}
#endregion

#region 허기 이벤트 - 상한 빵과 우유
public class Eating_1 : Story
{
    public Eating_1()
    {
        txt = "당신은 주방을 둘러보았습니다.\n선반을 열어보니 빵과 우유가 눈에 띄었습니다. 하지만 빵은 약간 딱딱해져 있어 신선하지 않아 보였습니다. 당신은 잠시 생각에 잠겼습니다.";


        subs.Add(new Eating_1_1());
        subs.Add(new Eating_1_2());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Eating_1_1 : Sub
{
    public Eating_1_1()
    {
        txt = "우유만 먹인다.\n(100%) <sprite=1>+";
    }

    public override void Next_Event()
    {
        //story = new Eating_1();
    }
}

class Eating_1_2 : Sub
{
    public Eating_1_2()
    {
        txt = "빵과 우유 모두 먹인다.\n(50%) <sprite=1>++";
    }

    public override void Next_Event()
    {
        int percent = Random.Range(0, 2); //50%
        switch (percent)
        {
            case 0: //성공
                Story_Manager.inst.story = new Eating_1_True();
                break;
            case 1: //실패
                Story_Manager.inst.story = new Eating_1_False();
                break;
        }
    }
}

#region 성공
public class Eating_1_True : Story //배부름++
{
    public Eating_1_True()
    {
        txt = "더 좋은 방안이 없습니다.\n당신은 펫에게 작은 조각을 나눠줬습니다. 다행이 아무 일 없이 당신은 펫과 함께 빵을 나눠먹었습니다.";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { 20, 0, 0 });

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 실패
public class Eating_1_False : Story //행복도--
{
    public Eating_1_False()
    {
        txt = "당신은 빵을 한 입 베어 물었습니다.\n점차 이상한 맛이 입안에 퍼지기 시작했습니다. \"미안해, 상한 것 같아\" 당신은 걱정스러운 눈빛으로 펫을 바라보며 중얼거렸습니다.";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { 0, 0, -20});

        Typing_Effect.inst.Start_Typing(txt);
    }
}


#endregion
#endregion


//메인으로 돌아가는 선택지
class Return_Main : Sub
{
    public Return_Main()
    {
        txt = "정리하기";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Main();
    }
}

