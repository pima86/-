using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Story story { get; set; }

    public virtual void Play()
    {
        Story_Manager.inst.Start_Story(story);
    }
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
        story = new Prologue_1();
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
        BG_Manager.inst.tool_pet.Play("Enter");

        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Sub_Prologue_1_1 : Sub
{
    public Sub_Prologue_1_1()
    {
        txt = "집으로 데려간다.";
        story = new Prologue_2();
    }
}

class Sub_Prologue_1_2 : Sub
{
    public Sub_Prologue_1_2()
    {
        txt = "두고간다.";
        //story = new Prologue_1();
    }
}
#endregion

#region 알의 표면은 매끄럽고 따뜻했습니다.
public class Prologue_2 : Story
{
    public Prologue_2()
    {
        txt = "알의 표면은 매끄럽고 따뜻했습니다.\n알의 표면에는 미세한 균열이 있었고, 그 안에서 무언가가 꿈틀거리는 것이 보였습니다. 당신은 알을 귀에 대고 듣기 시작했습니다. 약하게 들려오는 소리가 당신의 마음을 두근거리게 했습니다.";

        subs.Add(new Sub_Prologue_2_1());
    }

    public override void Play()
    {
        BG_Manager.inst.tool_bg.SetUp("Dorm 3");

        Typing_Effect.inst.Start_Typing(txt);
    }
}

class Sub_Prologue_2_1 : Sub
{
    public Sub_Prologue_2_1()
    {
        txt = "집으로 데려간다.";
        //story = new Prologue_1();
    }
}
#endregion
