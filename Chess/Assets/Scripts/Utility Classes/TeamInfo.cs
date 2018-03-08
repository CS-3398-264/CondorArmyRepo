using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTeamInfo", menuName = "Chess/Team Info")]
public class TeamInfo : ScriptableObject {

    public Color teamColor;
    public Color defaultColor;
    public int teamNumber;

}
