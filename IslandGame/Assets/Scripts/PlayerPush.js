var power : float = 50000.0;

function OnTriggerEnter (player : Collider) {

	if (player.tag=="Player")
		player.GetComponent(ImpactReceiver).AddImpact(Vector3(power,power,0));

}