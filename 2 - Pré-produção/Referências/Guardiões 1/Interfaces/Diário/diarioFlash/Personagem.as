package 
{

	import flash.display.Sprite;
	import flash.xml.*;
    import flash.events.MouseEvent;
	import flash.events.Event;
    
	public class Personagem extends Sprite
	{

		public var node:XML;
		public var descricao:String;
		public var caminhoImagem: String;
		public var miniatura:Sprite;
		public var foto:Sprite;
		
		public function Personagem(node:XML)
		{
			this.node = node;
			nome_txt.text = node.Nome;
			descricao = node.Descricao;
			//miniatura = node.Imagem.miniatura;
			//foto = node.Imagem.foto;
			

		}//fim do consrutor
		
		public function GetDescricao()
		{
			return descricao;
		}
		
		
		/*public function mudarDescricaoFoto(event:Event):void
		{
			descricao = event.currentTarget.node.Descricao;
		}*/

	}//fim da classe


}//fim do pacote