package 
{
	import flash.display.MovieClip;
	import flash.display.Sprite;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.xml.XMLDocument;
	import flash.xml.XMLNode;
	import flash.xml.XMLNodeType;
	import flash.text.*;
    import flash.events.MouseEvent;
	

	public class Diario extends MovieClip
	{
        private var p:Pagina;
		private var personagem:Personagem;
		public function Diario()
		{
            
		    var xml:XMLoader = new XMLoader();
            xml.load("personagens.xml");
		    xml.addEventListener(Event.COMPLETE, ler);
		    baixo_btn.addEventListener(MouseEvent.CLICK, abaixar);
		    cima_btn.addEventListener(MouseEvent.CLICK, levantar); 
			
		}
		  
		   public function mudar(descricao:String){
			   descricao_txt.text=descricao;
		   }
		   
		   
		   public function abaixar(event:Event):void{
 			   p.moverBaixo();
		   }
		   public function levantar(event:Event):void{
 			   p.moverCima();
		   }
		   public function ler (event:Event):void{
			    //trace(event.target.content.Personagem.length());
				criarPagina(event.target.content);
				
			
		   }
		   public function criarPagina(xml:XML){
			    p= new Pagina(xml, this);
				p.x = 522;  

			    addChild(p);
			   
		   }
			   
		   
		 
	}//fim da classe

}//fim do package