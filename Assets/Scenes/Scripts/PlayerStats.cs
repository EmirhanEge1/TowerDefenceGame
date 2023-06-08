
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 700;
    public static int rounds;
    public static int Lives;
    public int startLives = 20;


    void Start ()
    {
        Money = startMoney;
        Lives = startLives;
        rounds = 0;
    }
}
