
public interface IPlayerModelView : IModelView
{
    PlayerController PlayerController { get; set; }

    float rotationAngleSpeed { get; set; }

    float DampingForce { get; set; }

    float ForwardForce { get; set; }

    float FireTimer { get; set; }

    float MaxSpeed { get; set; }

}
	
