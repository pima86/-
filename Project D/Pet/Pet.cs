using UnityEngine;

public class Pet : MonoBehaviour, IState
{
    #region 인터페이스
    Pet[] IState.Evolutions { get => Evolutions; }
    public Pet[] Evolutions;

    Sprite IState.Sprite { get => Sprite; }
    public Sprite Sprite;

    string IState.Name { get => Name; }
    public string Name;

    int IState.Rate { get => Rate; }
    public int Rate;

    int IState.Attack { get => 0; }
    public int Attack;

    int IState.Speed { get => 0; }
    public int Speed;

    int IState.Hp { get => 0; }
    public int Hp;
    #endregion
}
