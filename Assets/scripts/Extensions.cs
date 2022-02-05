using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {

    private static System.Random rng = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while(n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];// item at random index between o and count
            // swap to items in list:
            list[k] = list[n]; // put the item in the current index into our random position K
            list[n] = value;// value holds position K item, put that at the current index position 
        }
    }
}
