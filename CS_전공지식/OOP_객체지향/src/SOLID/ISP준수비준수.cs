//No Interface Segregation Principle

//Large Interface
interface ICarBoatInterface
{
	public void drive();
	public void turnLeft();
	public void turnRight();
	public void steer();
	public void steerLeft();
	public void steerRight();
}

//Interface Segregation Principle
//two small interfaces (Car, Boat)
interface ICarInterface
{
	public void drive();
	public void turnLeft();
	public void turnRight();
}

interface IBoatInterface
{
	public void steer() 	{ /*implemenetation*/ }
	public void steerLeft() { /*implmementation*/ }
	public void steerRight(){ /*implementation*/ }
}


class Avante : ICarInterface
{
	public void drive() 	{ /*implemenetation*/ }
	public void turnLeft() 	{ /*implmementation*/ }
	public void turnRight()	{ /*implementation*/ }
}


class CarBoat :ICarInterface , IBoatInterface
{
	public void drive() 	{ /*implemenetation*/ }
	public void turnLeft() 	{ /*implmementation*/ }
	public void turnRight()	{ /*implementation*/ }
	public void steer() 	{ /*implemenetation*/ }
	public void steerLeft() { /*implmementation*/ }
	public void steerRight(){ /*implementation*/ }
}