#region 펫의 능력치와 기능을 구현하는 추상 클래스
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

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
#region 각 능력치별 아이콘 색상 및 이미지를 구현하는 가상 함수
public class State_Update
{
    public Image image { get; set; }

    

    public int Transformation(int amount)
    {
        switch (amount)
        {
            case > 65: //수치가 높은 상태
                return 2;
            case > 35: //평균 상태
                return 1;
            default: //수치가 낮은 상태
                return 0;
        }
    }

    public virtual void Color_and_Image(int amount)
    {
        int index = Transformation(amount);

        switch (index)
        {
            case 2:
                image.color = Color.red;
                break;
            case 1:
                image.color = Color.yellow;
                break;
            case 0:
                image.color = Color.green;
                break;
        }
    }
}

public class Hunger : State_Update
{
    public Hunger()
    {
        this.image = StateManager.inst.hunger_image;
    }
}

public class Hyglene : State_Update
{
    public Hyglene(Image image)
    {
        this.image = image;
    }
}

public class Happiness : State_Update
{
    Sprite[] sprites { get; set; }

    public Happiness(Image image, Sprite[] sprites)
    {
        this.image = image;
        this.sprites = sprites;
    }

    public override void Color_and_Image(int amount)
    {
        int index = Transformation(amount);

        image.sprite = sprites[index];

        switch (index)
        {
            case 2:
                image.color = Color.red;
                break;
            case 1:
                image.color = Color.yellow;
                break;
            case 0:
                image.color = Color.green;
                break;
        }
    }
}

public class Weight : State_Update
{
    Sprite[] sprites { get; set; }

    public Weight()
    {
        this.image = StateManager.inst.weight_image;
        this.sprites = StateManager.inst.weight_sprites;
    }

    public override void Color_and_Image(int amount)
    {
        int index = Transformation(amount);

        image.sprite = sprites[index];

        switch (index)
        {
            case 2:
                image.color = Color.red;
                break;
            case 1:
                image.color = Color.yellow;
                break;
            case 0:
                image.color = Color.green;
                break;
        }
    }
}

public class Disease : State_Update
{
    public Disease(Image image)
    {
        this.image = image;
    }
}
#endregion


