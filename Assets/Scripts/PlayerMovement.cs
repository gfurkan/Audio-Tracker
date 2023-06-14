using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovement: MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _movementSpeed = 0;

        #endregion
        
        #region Properties
        
        
        #endregion

        #region Unity Methods

        void Start()
        {
             
        }
        
        void Update()
        {
             MovePlayer();
        }

        #endregion

        #region Private Methods

        void MovePlayer()
        {
            transform.Translate(transform.forward*_movementSpeed*Time.deltaTime);
        }

        #endregion

        #region Public Methods

        

        #endregion
    }
  

}