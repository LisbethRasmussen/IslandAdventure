#pragma strict
#pragma implicit
#pragma downcast

class slowPlayerDown extends MonoBehaviour{

	static private var Speed : float = 6.0;
	
	var StartSpeed : boolean = true;
	var FasterSpeed : boolean = false;
	var SlowerSpeed : boolean = false;

	function Start () {

	}

	function Update () {
	 	if(StartSpeed == true){
	 		Speed = 6.0f;
	 	}
      	if(FasterSpeed == true){
	 		Speed += 1.0f;
	 	} 
	 	if(SlowerSpeed == true){
	 		Speed -= 1.0f;
	 	} 
	}

	static function GetSpeed() : float{
		return Speed;
	}
}