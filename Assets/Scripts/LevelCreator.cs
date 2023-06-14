using Audio.Test;
using UnityEditor;
using UnityEngine;

namespace Level.Creator
{
    public class LevelCreator: MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _beatPoint;
        [SerializeField] private Vector2 _beatPointHorizontalClamps;
        private GameObject _level;
        
        #endregion
        
        #region Properties
        
        
        #endregion

        #region Unity Methods
        
        private void OnEnable()
        {
            AudioSourceTester.onBeated += CreateBeatPoint;
            AudioSourceTester.onAudioFinished += OnSongFinished;
        }

        private void OnDisable()
        {
            AudioSourceTester.onBeated -= CreateBeatPoint;
            AudioSourceTester.onAudioFinished -= OnSongFinished;
        }

        private void Start()
        {
            _level = new GameObject("New Level");
        }

        #endregion

        #region Private Methods

      
        #endregion

        #region Public Methods

        private void CreateBeatPoint()
        {
            Vector3 spawnPos = new Vector3(Random.Range(_beatPointHorizontalClamps.x, _beatPointHorizontalClamps.y),
                transform.position.y, transform.position.z);
            Instantiate(_beatPoint, spawnPos, Quaternion.identity,_level.transform);
        }

        public void OnSongFinished()
        {
            string localPath = "Assets/Levels/" + _level.name +  ".prefab";
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            PrefabUtility.SaveAsPrefabAssetAndConnect(_level, localPath, InteractionMode.UserAction);
            Destroy(_level);
        }

        #endregion
    }
  

}