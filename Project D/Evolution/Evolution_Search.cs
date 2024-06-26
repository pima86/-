using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution_Search : MonoBehaviour
{
    #region 싱글톤
    public static Evolution_Search inst;
    private void Awake()
    {
        Loading();

        inst = this;
    }
    #endregion

    public Dictionary<string, Evolution_Abs> evolutions = new Dictionary<string, Evolution_Abs>();

    void Loading()
    {
        evolutions.Add("슬라임", new Now());
        evolutions.Add("레드 슬라임", new D_Day(5));
    }
}

public interface Evolution_Abs
{
    bool Evolution();
}

public class Now : Evolution_Abs
{
    public bool Evolution()
    {
        return true;
    }
}

public class D_Day : Evolution_Abs
{
    int day = 0;
    public D_Day(int n)
    {
        day = n;
    }

    public bool Evolution()
    {
        if (day <= GameManager.inst.Day) return true;
        else return false;
    }
}
