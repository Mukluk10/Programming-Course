using UnityEngine;


namespace AG3961
{
    public class NPCWalkScript : CharacterScript
    {


        public override void StartMoving()
        {

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            StartMoving();
        }
    }

}

