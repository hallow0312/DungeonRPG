using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineCache : MonoBehaviour
{
    class Compare : IEqualityComparer<float> //중첩 클래스
    {
        public bool Equals(float x, float y)
        {
            return x == y;
        }

        public int GetHashCode(float obj)
        {
            return obj.GetHashCode();
        }
    }
    private static readonly Dictionary<float, WaitForSeconds> dictionary =
        new Dictionary<float, WaitForSeconds>(new Compare());
    //readonly 런타임 시점에 상수화 
    //const가 속도는 빠르나 수정이 힘듬 
    //readonly는 const 보다 느리나 수정가능 
    public static WaitForSeconds waitForSeconds(float seconds)
    {
        WaitForSeconds wfs = null;
        if (!dictionary.TryGetValue(seconds, out wfs))
        {
            dictionary.Add(seconds, wfs = new WaitForSeconds(seconds));
        }
        return wfs;
    }
}
