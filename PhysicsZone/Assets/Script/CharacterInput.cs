using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    bool left = false;
    bool right = false;
    bool up = false;
	bool down = false;

    bool fire = false;
    bool special = false;
    bool jump = false;
    bool extra = false;
    bool wasJump = false;
    bool wasFire = false;
    bool wasSpecial = false;
    bool wasUp = false;
    bool wasLeft = false;
    bool wasRight = false;

    public int controllerID = 0;

    // Update is called once per frame
    void Update()
    {
		wasLeft = left;
		wasRight = right;

		wasFire = fire;
		wasSpecial = special;
		wasJump = jump;
		wasUp = up;

		up = down = left = right = fire = jump = extra = false;

		if(controllerID > 5)
		{
			//InputReader.
		}
    }
}
