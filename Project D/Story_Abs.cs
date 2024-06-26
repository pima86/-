using System.Collections.Generic;
using System.Text;
using Random = UnityEngine.Random;

public abstract class Story
{
    public int temp {get;set;} 
    public string txt { get; set; }
    public List<Sub> subs { get; set; } = new List<Sub>();

    public virtual void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

public abstract class Sub
{
    public int temp {get; set;}
    public string txt { get; set; }

    public virtual void Play()
    {
        Story_Manager.inst.Start_Story();
    }

    public abstract void Next_Event();
}

//튜토리얼
#region 어느 날, 당신은 숲 속을 걷다가 빛나는 무언가를 발견했습니다.
public class Prologue : Story
{
    public Prologue()
    {
        txt = "어느 날,\n당신은 숲 속을 걷다가 빛나는 무언가를 발견했습니다. 그 물체는 반쯤 땅에 묻혀 있었고, 가까이 다가가서 보니 그것은 알처럼 보였습니다.";

        subs.Add(new Sub_Prologue());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_bg.SetUp("Mountain 2");

        Typing_Effect.inst.Start_Typing(txt);
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

#region 메인
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
        BG_Manager.inst.tool_bg.SetUp("Dorm 3");

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
        Story_Manager.inst.story = new Out();
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
        Story_Manager.inst.story = new Leave_1();
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
        Story_Manager.inst.story = new Washing_1();
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
        Story_Manager.inst.story = new Playing_1();
    }
}
#endregion
#region 외출하기
public class Out : Story
{
    public Out()
    {
        txt = "오늘의 날씨는 매우 맑습니다.\n당신의 작은 움직임 하나하나에 귀를 기울이고 있습니다.";


        subs.Add(new Out_1());
        subs.Add(new Out_2());
        subs.Add(new Out_3());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_bg.SetUp("Building 6");

        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Out_1 : Sub
{
    public Out_1()
    {
        txt = "숲으로 가기";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Fighting_1();
    }
}

class Out_2 : Sub
{
    public Out_2()
    {
        txt = "바다로 가기";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Meeting_1();
    }
}

class Out_3 : Sub
{
    public Out_3()
    {
        txt = "시내로 가기";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Buying_1();
    }
}
#endregion
#region 이별하기
public class Leave_1 : Story
{
    public Leave_1()
    {
        txt = "펫과의 인연을 여기까지 하시겠습니까?";

        subs.Add(new Leave_1_1());
        subs.Add(new Leave_1_2());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Leave_1_1 : Sub
{
    public Leave_1_1()
    {
        txt = "네";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Leave_1_end();
    }
}

class Leave_1_2 : Sub
{
    public Leave_1_2()
    {
        txt = "아니요.";
    }

    public override void Next_Event()
    {
        GameManager.inst.Day--;

        Story_Manager.inst.story = new Main();
    }
}

#region 초기화
public class Leave_1_end : Story
{
    public Leave_1_end()
    {
        txt = "펫은 원래 있던 위치로 돌아갔습니다.";

        subs.Add(new Reset());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_pet.Play("Pet_Out");

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#endregion

//돌보기
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
        txt = "빵과 우유 모두 먹인다.\n(60%) <sprite=1>+++";
    }

    public override void Next_Event()
    {
        int percent = Random.Range(0, 10);
        if(percent < 6) Story_Manager.inst.story = new Eating_1_True();
        else Story_Manager.inst.story = new Eating_1_False();
    }
}

class Eating_1_2 : Sub
{
    public Eating_1_2()
    {
        txt = "우유만 먹인다.\n(100%) <sprite=1>+";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Eating_1_end();
    }
}

#region 성공
public class Eating_1_True : Story //배부름++
{
    public Eating_1_True()
    {
        txt = "더 좋은 방안이 없습니다.\n당신은 펫에게 작은 조각을 나눠줬습니다. 다행히 아무 일 없이 당신은 펫과 함께 빵을 나눠먹었습니다.\n\n포만감++";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { 30, 0, 0 });

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 실패
public class Eating_1_False : Story //행복도--
{
    public Eating_1_False()
    {
        txt = "당신은 빵을 한 입 베어 물었습니다.\n점차 이상한 맛이 입안에 퍼지기 시작했습니다. \"미안해, 상한 것 같아\" 당신은 걱정스러운 눈빛으로 펫을 바라보며 중얼거렸습니다.\n\n행복--";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { 0, 0, -20});

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 우유만 먹기
public class Eating_1_end : Story
{
    public Eating_1_end()
    {
        txt = "상한 음식을 먹일 수는 없습니다.\n당신은 우유를 그릇에 따라 펫에게 건네줬습니다. 펫은 기쁘게 우유를 먹기 시작했습니다.\n\n포만감+";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { 10, 0, 0 });

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#endregion

#region 목욕 이벤트 - 물장난치기
public class Washing_1 : Story
{
    public Washing_1()
    {
        txt = "당신은 펫과 함께 목욕을 하기로 했습니다.\n펫은 점점 활기를 띠며 물장난을 치기 시작했습니다. 아이는 당신과 소중한 시간을 보내고 싶어하는 것 같습니다.";


        subs.Add(new Washing_1_1());
        subs.Add(new Washing_1_2());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Washing_1_1 : Sub
{
    public Washing_1_1()
    {
        txt = "아이와 즐거운 시간을 보낸다.\n<sprite=1>-- <sprite=6>+ <sprite=3>++";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Washing_1_1_end();
    }
}

class Washing_1_2 : Sub
{
    public Washing_1_2()
    {
        txt = "진정시키고 구석구석 씻긴다.\n<sprite=6>+++";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Washing_1_2_end();
    }
}

#region 아이와 즐거운 시간을 보낸다.
public class Washing_1_1_end : Story
{
    public Washing_1_1_end()
    {
        txt = "당신은 손으로 물을 뿌렸습니다.\n펫은 더욱 신나서 물속을 헤엄치며 물방울을 사방으로 튕겼습니다. 아이의 물장난에 당신은 웃음을 터뜨리며 즐거운 시간을 보냈습니다.\n\n포만감-- 청결+ 행복++";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { -20, 10, 20 });

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 진정시키고 구석구석 씻긴다.
public class Washing_1_2_end : Story
{
    public Washing_1_2_end()
    {
        txt = "당신은 아이를 진정시켰습니다.\n조금은 시무룩해보였지만 아이의 건강을 위해서는 어쩔 수 없습니다.\n\n청결+++";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { 0, 30, 0 });

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#endregion

#region 행복 이벤트 - 그림
public class Playing_1 : Story
{
    public Playing_1()
    {
        txt = "펫은 열심히 그림을 그리고 있습니다.\n표정은 진지했지만, 다 그린 그림은 엉성한 선과 색깔이 뒤섞여 무슨 그림인지 알 수 없었습니다. 펫은 활짝 웃으며 당신에게 그림을 선물했습니다.";

        subs.Add(new Playing_1_1());
        subs.Add(new Playing_1_2());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Playing_1_1 : Sub
{
    public Playing_1_1()
    {
        txt = "\"나를 그린거니?\"\n(30%) <sprite=3>+++";
    }

    public override void Next_Event()
    {
        int percent = Random.Range(0, 10); //30%

        if(percent < 3) Story_Manager.inst.story = new Playing_1_True();
        else Story_Manager.inst.story = new Playing_1_False();
    }
}

class Playing_1_2 : Sub
{
    public Playing_1_2()
    {
        txt = "대화 주제를 바꿔 어물쩡 넘긴다.\n(100%) <sprite=3>+";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Playing_1_end();
    }
}

#region 성공
public class Playing_1_True : Story
{
    public Playing_1_True()
    {
        txt = "당신은 최대한 생각을 짜내보려 했습니다.\n다행히 아이가 원하는 대답이었는지 밝게 미소를 띄워주더니 다시 그림을 그리기 시작했습니다. 선물받은 그림은 당신에게 가장 소중한 물건이 되었습니다.\n\n행복+++";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { 0, 0, 30 });

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 실패
public class Playing_1_False : Story
{
    public Playing_1_False()
    {
        txt = "당신은 최대한 생각을 짜내보려 했습니다.\n하지만 아이가 원했던 답변은 아니였는지 서운한 목소리를 냈습니다.";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 어물쩡 넘기기
public class Playing_1_end : Story
{
    public Playing_1_end()
    {
        txt = "당신은 재치 있게 대화를 돌리기로 했습니다.\n\"그림 정말 멋지구나! 그런데 오늘 점심 뭐 먹을까? 뭐 먹고 싶어?\"\n\n행복+";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { 0, 0, 10 });

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#endregion

//외출하기
#region 전투 이벤트 - 작은 짐승
public class Fighting_1 : Story
{
    public Fighting_1()
    {
        txt = "울창한 나무들 사이로 걸어가고 있습니다.\n작은 짐승 무리가 눈앞에 나타났습니다. 그들은 긴장된 자세로 당신과 펫을 주시하고 있었습니다.";

        subs.Add(new Fighting_1_1());
        subs.Add(new Fighting_1_2());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_bg.SetUp("Mountain 3");

        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Fighting_1_1 : Sub
{
    public Fighting_1_1()
    {
        temp = BG_Manager.inst.pet.Food / 10;

        StringBuilder sb = new StringBuilder();
        sb.Append("공격한다.\n(<sprite=1>");
        sb.Append((temp * 10).ToString());
        sb.Append("%)");

        txt = sb.ToString();
    }

    public override void Next_Event()
    {
        int percent = Random.Range(0, 10); //30%

        if (percent < temp) Story_Manager.inst.story = new Fighting_True(10);
        else Story_Manager.inst.story = new Fighting_False();
    }
}

class Fighting_1_2 : Sub
{
    public Fighting_1_2()
    {
        txt = "도망친다.\n(50%)";
    }

    public override void Next_Event()
    {
        int percent = Random.Range(0, 2);
        if(percent == 0) Story_Manager.inst.story = new Fighting_1_end();
        else Story_Manager.inst.story = new Fighting_False();

    }
}
#endregion

#region 만남 이벤트 - 해안가 구울의 등장
public class Meeting_1 : Story
{
    public Meeting_1()
    {
        txt = "펫과 함께 걷던 중,\n당신은 먼 바다 쪽에서 떠밀려온 한 사람을 발견했습니다. 그는 파도에 실려 해변으로 떠밀려 온 듯했습니다. 당신은 잠시 멈춰 서서 어떻게 해야 할지 고민했습니다.";

        subs.Add(new Meeting_1_1());
        subs.Add(new Meeting_1_2());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_bg.SetUp("Lake 1");

        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Meeting_1_1 : Sub
{
    public Meeting_1_1()
    {
        txt = "당연히 도움을 준다.";
    }

    public override void Next_Event()
    {
        int percent = Random.Range(0, 10); //30%

        if (percent < 4) Story_Manager.inst.story = new Meeting_1_True();
        else Story_Manager.inst.story = new Meeting_1_False();
    }
}

class Meeting_1_2 : Sub
{
    public Meeting_1_2()
    {
        txt = "접근은 위험하기에 못 본 척한다.";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Meeting_1_end();
    }
}

#region 성공
public class Meeting_1_True : Story
{
    public Meeting_1_True()
    {
        temp = Random.Range(30, 51);
        StringBuilder sb = new StringBuilder();
        sb.Append("당신은 그냥 두고 갈 수 없었습니다.\n다행히도 그는 미약하게나마 숨을 쉬고 있었습니다. 조금씩 의식을 되착기 시작했고, \"감사합니다...\"라고 힘겹게 말을 꺼냈습니다. 병원에서 치료받은 그는 감사의 표시로 소정의 골드를 건넸습니다.\n\n골드+");
        sb.Append(temp.ToString());

        txt = sb.ToString();

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_item.SetUp(temp);
        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 실패
public class Meeting_1_False : Story
{
    public Meeting_1_False()
    {
        txt = "당신의 손길이 그에게 닿았습니다.\n그러자 그의 몸이 갑자기 격렬하게 떨리기 시작했습니다. 눈을 뜬 그의 눈동자는 창백하고 공허했습니다. 곧 그가 구울이라는 사실을 깨달았습니다. 그의 입에서 낮은 신음 소리가 흘러나왔고, 곧 당신을 향해 손을 뻗어왔습니다.";

        subs.Add(new Meeting_1_False_1());
        subs.Add(new Meeting_1_False_2());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Meeting_1_False_1 : Sub
{
    public Meeting_1_False_1()
    {
        temp = BG_Manager.inst.pet.Food / 30;

        StringBuilder sb = new StringBuilder();
        sb.Append("공격한다.\n(<sprite=1>");
        sb.Append((temp * 10).ToString());
        sb.Append("%)");

        txt = sb.ToString();
    }

    public override void Next_Event()
    {
        int percent = Random.Range(0, 10);

        if (percent < temp) Story_Manager.inst.story = new Fighting_True(100);
        else Story_Manager.inst.story = new Fighting_False();
    }
}

class Meeting_1_False_2 : Sub
{
    public Meeting_1_False_2()
    {
        txt = "도망친다.\n(50%)";
    }

    public override void Next_Event()
    {
        int percent = Random.Range(0, 2);
        if (percent == 0) Story_Manager.inst.story = new Meeting_1_end();
        else Story_Manager.inst.story = new Fighting_False();

    }
}
#endregion
#region 못본척한다.
public class Meeting_1_end : Story
{
    public Meeting_1_end()
    {
        txt = "이 곳은 구울의 출현지입니다.\n위험에 펫을 노출시킬 수 없었기에 당신은 못 본 척했습니다. 옳은 선택이였기를.\n";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#endregion

#region 구매 이벤트 - 잡상인
public class Buying_1 : Story
{
    public Buying_1()
    {
        txt = "펫과 함께 시장에 나갔습니다.\n시장은 사람들로 북적였고, 활기찬 소리로 가득 차 있었습니다. \"또 왔군요.\" 잡상인은 오늘도 귀찮은 표정으로 당신을 맞이했습니다.";

        List<Sub> temps = new List<Sub>
        {
            new Buying_1_1(),
            new Buying_1_2(),
            new Buying_1_3()
        };

        for (int i = 0; i < 2; i++)
        {
            int r = Random.Range(0, temps.Count);

            subs.Add(temps[r]); 
            temps.RemoveAt(r);
        }
        subs.Add(new Buying_1_end());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}

#region 판매 물품들
class Buying_1_1 : Sub
{
    public Buying_1_1()
    {
        txt = "도시락 (최대 <sprite=1>+50)\n골드-100";
    }

    public override void Next_Event()
    {
        if (!BG_Manager.inst.tool_item.SetUp(-100))
        {
            Story_Manager.inst.story = new Buying_1_False();
        }
        else
        {
            GameManager.inst.Max_Food += 50;
            BG_Manager.inst.pet.food += 50;

            Story_Manager.inst.story = new Buying_1_True();
        }
    }
}

class Buying_1_2 : Sub
{
    public Buying_1_2()
    {
        txt = "목욕 수건 (최대 <sprite=6>+50)\n골드-100";
    }

    public override void Next_Event()
    {
        if (!BG_Manager.inst.tool_item.SetUp(-100))
        {
            Story_Manager.inst.story = new Buying_1_False();
        }
        else
        {
            GameManager.inst.Max_Wash += 50;
            BG_Manager.inst.pet.wash += 50;

            Story_Manager.inst.story = new Buying_1_True();
        }
    }
}

class Buying_1_3 : Sub
{
    public Buying_1_3()
    {
        txt = "색연필 (최대 <sprite=3>+50)\n골드-100";
    }

    public override void Next_Event()
    {
        if (!BG_Manager.inst.tool_item.SetUp(-100))
        {
            Story_Manager.inst.story = new Buying_1_False();
        }
        else
        {
            GameManager.inst.Max_Happy += 50;
            BG_Manager.inst.pet.happy += 50;

            Story_Manager.inst.story = new Buying_1_True();
        }
    }
}
#endregion

class Buying_1_end : Sub
{
    public Buying_1_end()
    {
        txt = "아무것도 구매하지 않는다.";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Buying_1_False();
    }
}

#region 구매하기
public class Buying_1_True : Story
{
    public Buying_1_True()
    {
        txt = "구매했습니다.";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        GameManager.inst.Amount++;

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 구매하지 않기
public class Buying_1_False : Story
{
    public Buying_1_False()
    {
        txt = "당신은 아무것도 구매하지 못했습니다.";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#endregion

#region 성공
public class Fighting_True : Story
{
    public Fighting_True(int num)
    {
        temp = Random.Range(num, num+20);
        StringBuilder sb = new StringBuilder();
        sb.Append("펫은 날카로운 소리를 냈습니다.\n검을 뽑아 든 당신을 시작으로 이 곳은 소란스럽고 긴장된 전투 소리로 가득 찼습니다. 마침내 마지막 적이 쓰러지며 당신과 펫은 전투에서 승리했습니다.\n\n포만감--- 골드+");
        sb.Append(temp.ToString());

        txt = sb.ToString();

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        GameManager.inst.Kill++;

        BG_Manager.inst.State_SetUp(new int[3] { -30, 0, 0 });
        BG_Manager.inst.tool_item.SetUp(temp);

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 실패
public class Fighting_False : Story
{
    public Fighting_False()
    {
        txt = "하지만 상대가 너무 강했습니다.\n당신의 검은 무거워지고, 펫은 움직임이 느려지기 시작했습니다. 결국, 상대가 당신의 방어를 뚫고 공격해왔습니다. 어쩔 수 없이 펫을 안고 도망쳤습니다.\n\n포만감--- 청결---";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        BG_Manager.inst.State_SetUp(new int[3] { -30, -30, 0 });

        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 도망치기
public class Fighting_1_end : Story
{
    public Fighting_1_end()
    {
        txt = "당신은 펫을 진정시켰습니다.\n천천히 후퇴했고 펫도 당신의 뒤를 따르며 조심스럽게 움직였습니다. 짐승들은 여전히 긴장한 채로 있었지만, 당신의 후퇴를 지켜보며 더 이상 공격적인 태세를 보이지 않았습니다.\n";

        subs.Add(new Return_Main());
    }

    public override void Play()
    {
        Typing_Effect.inst.Start_Typing(txt);
    }
}
#endregion
#region 돌아가기
class Return_Main : Sub
{
    public Return_Main()
    {
        txt = "다음 날로 가기";
    }

    public override void Next_Event()
    {
        if(BG_Manager.inst.Evolution_This() != null) Story_Manager.inst.story = new Night_1();
        else Story_Manager.inst.story = new Main();
    }
}

class Reset : Sub
{
    public Reset()
    {
        txt = "첫 날로 돌아가기";
    }

    public override void Next_Event()
    {
        GameManager.inst.Reset();
        Story_Manager.inst.story = new Prologue();
    }
}
#endregion
#region 진화
public class Night_1 : Story
{
    public Night_1()
    {
        txt = "펫이 갑자기 이상한 움직임을 보였습니다.\n그의 모습이 서서히 바뀌기 시작했습니다. 이것은 분명 진화하는 과정이었습니다. 몇 분이 지나자 빛이 서서히 사라졌고, 새로운 모습이 완전히 드러났습니다.";

        subs.Add(new Night_1_1());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_pet.Play("Hatch");
        BG_Manager.inst.Get_Evolution_Pet();

        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Night_1_1 : Sub
{
    public Night_1_1()
    {
        txt = "다음 날로 가기";
    }

    public override void Next_Event()
    {
        Story_Manager.inst.story = new Main();
    }
}
#endregion
