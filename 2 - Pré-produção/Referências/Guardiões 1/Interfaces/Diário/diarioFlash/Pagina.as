package 
{
	import flash.display.Sprite;
	import flash.xml.XMLNodeType;
	import flash.events.Event;
	import flash.events.MouseEvent;

	public class Pagina extends Sprite
	{
		private var tam:int;
		private var conteiner:Sprite;
		private var mascara:Sprite;
		private var diario:Diario;
		
		public function Pagina(xml:XML, diario:Diario)
		{
			this.diario = diario;
			construir(xml);
			//trace(tam);
		}

		private function construir(xml:XML):void
		{
			conteiner = new Sprite();
			mascara = new Sprite();
			mascara.graphics.beginFill(0x000000, .5);
			mascara.graphics.drawRect(0,40, 345, 4*86);
			mascara.graphics.endFill();
			conteiner.mask = mascara;
			addChild(mascara);
			tam = xml.Personagem.length();
			for (var i:int =0; i<xml.Personagem.length(); i++)
			{

				var p:Personagem = new Personagem(xml.Personagem[i]);
				p.y=45+(p.height+5)*i;
				conteiner.addChild(p);
				p.addEventListener(MouseEvent.CLICK, mudarDescricaoFoto);
			}//fim do for
			addChild(conteiner);
		}//fim de construir
		
        public function mudarDescricaoFoto(event:Event):void
		{
		    var descricao:String=event.currentTarget.node.Descricao;
			diario.mudar(descricao);
		}
         

		public function moverBaixo():void
		{
			trace(conteiner.y);
			trace(tam);
			if (conteiner.y<=(tam*-85) + 4*85)
			{
				trace("Nao desce mais");
			}
			else
			{
				conteiner.y -=  85;
			}
		}
		public function moverCima():void
		{

			if (conteiner.y == 0)
			{
				trace("Nao sobe mais");
			}
			else
			{
				conteiner.y +=  85;
			}
		}


	}//fim da classe

}//fim do pacote