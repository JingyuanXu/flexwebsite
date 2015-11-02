package cpzs
{
	import mx.collections.ArrayCollection;
	
	

	public class ViewModelLocator
	{
	

		private static var instance:ViewModelLocator;
		public function ViewModelLocator(encoder:SingletonEnforcer)
		
		public static function getIntance():ViewModelLocator
		{
			if(instance==null)
			{
				instance=new ViewModelLocator(new SingletonEnforcer);
				
			}
			return instance;
			
		}
		public var arrAddrList:ArrayCollection=new ArrayCollection();
		
		
	}
	
}
class SingletonEnforcer{
}