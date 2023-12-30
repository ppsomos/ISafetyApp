using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Poster")]
public class PosterData : ScriptableObject
{
    public GameRoom[] Room;
    [System.Serializable]
    public class GameRoom
    {
        public string RoomName;
        public RoomLanguage[] PosterLanguage;
    }
    [System.Serializable]
    public class RoomLanguage
    {
        public string RoomLanguageName;
        public RoomPoster[] Poster;
    }
    [System.Serializable]
    public class RoomPoster
    {
        public string PosterName;
        public Sprite Poster_Sprite;
    }
}
