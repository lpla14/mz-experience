#pragma strict

function Start(){
	Time.timeScale = 0;
	Screen.lockCursor = false;
}

function DidPause () {
    Debug.Log("Locking cursor");

   
}


function DidUnPaused () {
    Debug.Log("Unlocking cursor");
	Time.timeScale = 0;
   
}

private var wasLocked = false;

function Update () {
    
    if (Input.GetKeyDown ("escape"))
        Screen.lockCursor = false;

    
    if (!Screen.lockCursor && wasLocked) {
        wasLocked = false;
        DidUnPaused();
    }
    
    else if (Screen.lockCursor && !wasLocked) {
        wasLocked = true;
        DidPause ();
    }
}

function OnGUI(){
	if(Screen.lockCursor == false){
		if(GUI.Button(Rect(Screen.width -150, 10, 150, 30), "Resume" )){
			Screen.lockCursor = true;
			Time.timeScale = 1;
		}	
	}
}