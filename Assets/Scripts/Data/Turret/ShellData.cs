using UnityEngine;

namespace Snake_box
{
    [CreateAssetMenu(fileName = nameof(ShellData), menuName = "Data/Turret/" + nameof(ShellData))]
    public class ShellData : ScriptableObject
    {
        public int PlainShellSpeed = 50;
        public int PlainShellDamage = 10;
    }
}