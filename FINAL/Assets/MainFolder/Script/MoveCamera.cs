using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public NewPlayerMovement NPM;
    public Transform playerSocket;
    public Transform glidingSocket;

    void Update() {
        if(NPM.IsGliding())
        {
            transform.position = glidingSocket.transform.position;
        }
        else
        {
            transform.position = playerSocket.transform.position;
        }


        //if (NPM.IsGliding())
        //{
        //    if (transform.parent != glidingSocket)
        //        transform.SetParent(glidingSocket);
        //}
        //else
        //{
        //    if (transform.parent != playerSocket)
        //        transform.SetParent(playerSocket);
        //}
    }
}
