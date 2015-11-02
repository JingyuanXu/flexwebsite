package{
	
public class User   
{   
	public function User()   
	{   
		super();   
	}   
	public function initUser(id:int=0,fname:String="",lname:String=""):void{   
		this.id=id;   
		this.fname=fname;   
		this.lname=lname;   
	}   
	public var id:int=0;   
	public var fname:String="";   
	public var lname:String="";  
}   
}