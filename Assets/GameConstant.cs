using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant 
{
    public static Vector2 CountEatPeople =new Vector2(.2f, .5f); //���� ����� ���� � ���� �� �-� � ����
    public static float ProcentNewPeople = .4f; //���� ��������� ����� ����� ������ ����
    public static float UpNewPeople = 50; //������� ����� ����� �� ���������� ���� �� days / 50
    public static int CountDaysFromDiamond = 40; //������� ����� ������� ���� ��� �� �������� ���� �����
    public static int CountDiamondContinue = 3; //������� ����� ������� ���� ��� �� �������� ���� �����
    public static float CountUpDiamondContinue = 2; //������� ����� ������� ���� ��� �� �������� ���� �����
    public static int CountDiamondFromResetCards = 2; //������� ����� �������� ��� �� �������� ����� ����� ��������
    public static float CountUpDiamondFromResetCards = 2; //��������� ���������� ���������� ��������
    public static int MaxCountHumanInCity = 100;
}
