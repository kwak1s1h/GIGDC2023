using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TListBinding : MonoBehaviour
{
    public List<int> a = new List<int>();
    public List<int> b = new List<int>();
    
    private void Start()
    {
        EqualCheck();
    }

    public void Binding(List<int> target)
    {
        List<int> temp = target.ToArray().ToList();
        temp.Add(300);
    }

    public void EqualCheck()
    {
        b = a.ToArray().ToList();
        Debug.Log(a.Equals(b));
        b.Add(10);
        Debug.Log(a.Equals(b));
    }
}
