package
{
	import flash.events.Event; 
	import User;
	public class UserEvent extends Event
	{
		public static const USEREDITE:String="useredit";   
		public var user:User;   
		public function UserEvent(type:String,user:User)   
		{   
			this.user=user;   
			super(type);   
		}   
		
		override public function clone():Event
		{   
			var e:UserEvent=new UserEvent(USEREDITE,user);   
			return e;   
		}   

	}
}
