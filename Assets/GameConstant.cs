using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant 
{
    public static Vector2 CountEatPeople =new Vector2(.2f, .5f); //Люди будут есть и пить по х-у в день
    public static float ProcentNewPeople = .4f; //шанс появления новых людей каждый день
    public static float UpNewPeople = 50; //процент роста людей от количества дней на days / 50
    public static int CountDaysFromDiamond = 40; //Сколько нужно прожить дней что бы получить один алмаз
    public static int CountDiamondContinue = 3; //Сколько нужно прожить дней что бы получить один алмаз
    public static float CountUpDiamondContinue = 2; //Сколько нужно прожить дней что бы получить один алмаз
    public static int CountDiamondFromResetCards = 2; //Сколько нужно лампочек что бы получить новый набор карточек
    public static float CountUpDiamondFromResetCards = 2; //Множиетль увеличения количества лампочек
    public static int MaxCountHumanInCity = 100;
}
