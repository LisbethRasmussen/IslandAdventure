
var mass = 3.0; // defines the character mass
var impact = Vector3.zero; // momentum
private var character: CharacterController;

function Start(){
	character = GetComponent(CharacterController);
}
// call this function to add an impact force:
function AddImpact(force: Vector3){
	if (force.y < 0) force.y = -force.y; // reflect down force on the ground
		impact += force / mass;
}

function Update(){
// apply the impact force:
	if (impact.magnitude > 0.2) character.Move(impact * Time.deltaTime);
		impact = Vector3.Lerp(impact, Vector3.zero, 5*Time.deltaTime); // consumes the impact energy each cycle:
}