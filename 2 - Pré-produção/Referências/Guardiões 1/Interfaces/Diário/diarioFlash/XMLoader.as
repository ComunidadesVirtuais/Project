package  {
	
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.events.HTTPStatusEvent;
	import flash.events.IOErrorEvent;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	
	public class XMLoader extends EventDispatcher {
		
		private var _content:XML;
		
		public function get content():XML {
			return _content;
		}
		
		/**
		 * Método construtor.
		 */
		public function XMLoader() {
			//todo
		}
		
		/**
		 * Método que inicializa o carregamento dos dados em XML.
		 * @param url:String
		 */
		public function load(url:String):void {
			var urlLoader:URLLoader = new URLLoader();
			urlLoader.addEventListener(Event.COMPLETE, completeHandler);
			urlLoader.addEventListener(IOErrorEvent.IO_ERROR, ioErrorHandler);
			urlLoader.addEventListener(HTTPStatusEvent.HTTP_STATUS, httpStatusHandler);
			try {
				
				urlLoader.load(new URLRequest(url));
			} catch (error:Error) {
				trace("Error");
			}
		}
		
		private function ioErrorHandler(event:IOErrorEvent):void {
			trace("IOError:", event.toString());
		}
		
		private function httpStatusHandler(event:HTTPStatusEvent):void {
			trace("httpStatus:", event.status);
		}
		
		private function completeHandler(event:Event):void {
			var xml:XML = new XML(event.target.data);
			_content = xml;
			
			
			dispatchEvent(new Event("complete"));
		}
	}
}