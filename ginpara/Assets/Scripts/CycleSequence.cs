using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ginpara
{
/// <summary>
/// 循環シーケンス
/// </summary>
/// <typeparam name="T"></typeparam>
public class CycleSequence<T> : IEnumerable<T>
{
    protected List<T> _reel;

    public CycleSequence(List<T> reel) { _reel = reel; }

    public IEnumerator<T> GetEnumerator()
    {
        while (true)
        {
            foreach (T rl in _reel)
            {
                yield return rl;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

}
