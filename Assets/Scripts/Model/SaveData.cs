using UnityEngine;

namespace Model
{
    [System.Serializable]
    public class SaveData
    {
        private Color teamColor;

        public SaveData(Color teamColor)
        {
            this.teamColor = teamColor;
        }
        
        public SaveData()
        {
            this.teamColor = Color.black;
        }

        public Color TeamColor
        {
            get => teamColor;
            set => teamColor = value;
        }
    }
}