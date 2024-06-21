using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

#region 펫의 능력치와 기능을 구현하는 추상 클래스
public abstract class Pet_state
{
    //몬스터의 성장 단계를 나타내는 열거형
    public enum types { egg, baby };

    public void SetUp(string Name, types Type)
    {
        this.Name = Name;
        this.Type = Type;
    }

    public string Name { get; set; }
    public types Type { get; set; }

    //상태
    public int hunger = 0; //배고픔 수치
    public int hyglene = 100; //청결 수치
    public int happiness = 100; //행복도
    public int weight = 50; //비만도
    public int disease = 0; //질병
}

public class Egg : Pet_state //알
{

}

public class Baby : Pet_state //유년기
{

}
#endregion
#region 각 능력치별 아이콘 색상 및 이미지를 구현하는 인터페이스
interface IState
{
    int SetUp(int amount);
}

class Hunger : IState
{
    public int SetUp(int amount)
    {
        switch (amount)
        {
            case > 65: //배고픔
                return 0;
            case > 35: //중간
                return 1;
            default: //배부름
                return 2;
        }
    }
}
class Hyglene : IState
{
    public int SetUp(int amount)
    {
        switch (amount)
        {
            case > 65: //청결한
                return 2;
            case > 35: //중간
                return 1;
            default: //더러움
                return 0;
        }
    }
}
class Happiness : IState
{
    public int SetUp(int amount)
    {
        switch (amount)
        {
            case > 65: //행복
                return 2;
            case > 35: //중간
                return 1;
            default: //불행
                return 0;
        }
    }
}
class Weight : IState
{
    public int SetUp(int amount)
    {
        switch (amount)
        {
            //살찜
            case 100: //최대치 체중
                return 4;
            case > 65: //과체중
                return 3;

            //마름
            case 0: //최소치 체중
                return 0;
            case <= 35: //저체중
                return 1;

            //평균
            default:
                return 2;
        }
    }
}
class Disease : IState
{
    public int SetUp(int amount)
    {
        switch (amount)
        {
            case > 65: //아픔
                return 0;
            case > 35: //조금 아픔
                return 1;
            default: //안아픔
                return 2;
        }
    }
}
#endregion


