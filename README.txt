Constru��o:

 Para a constru��o do aplicativo, foi usado o Entity Framework conectado a um banco de dados na plataforma Azure.
 Foi criado um Ado.Net Entity Data Model, que conectado ao banco de dados SQL, criou automaticamente as classes de modelo de acordo com as tabelas do SQL, e o 
DBContext para o aplicativo, responsavel pela conex�o com o banco de dados.
 Foi usado data anottation para definir quais propriedades s�o obrigat�rias ([Required]).
 Caso seja gerado pelo Entity Framewok a anota��o "[key]", a mesma deve ser removida. Ao n�o ser removida, � gerado um erro na tentativa
de edi��o de itens no banco de dados.

  Na classe Patrimonios, o Setter da clase foi definido como Private para o atributo "PatrimonioNumTombo",  sendo que s� � 
  atribuido um valor aleat�rio na cria��o da classe, para motivos de demonstra��o.
  No modelo atual, n�o � possivel modificar o valor posteriormente. 

 Na cria��o da tabela de Marca , a coluna MarcaNome foi definida como Unique, n�o aceitando valores repetidos inseridos. Na tentativa de inser��o
de um valor que j� exista na tabela, ocorrer� um erro.
 
 A estrutura das tabelas utilizadas ficaram com os seguintes atributos


 Marca: 
	MarcaId (CHAVE PRIMARIA)
 	MarcaNome (NOT NULL)
 
 Patrimonio:
	PatrimonioId (CHAVE PRIMARIA)
	PatrimonioNome (NOT NULL)
  	MarcaId (CHAVE ESTRANGEIRA) 
	PatrimonioDescricao
	PatriomonioTombo (embora aceite nulo pelo banco de dados, � atribuido um valor automaticamente pela API)


 Controller: 
 Os controllers foram criados automaticamente com a ajuda do Entity Framework, sendo necess�rio somente a adi��o da op��o de listagem de patrimonios por marca.

 Para a rota :
	GET marcas/{id}/patrim�nios
 foi incluido no controller MarcasController o atributo "[Route("api/Marcas/{marcaId}/Patrimonios")]" , responsavel pelo encaminhamento da rota para o controller
que realiza a listagem dos patrimonios referente a marca selecionada.
 Para o funcionamento correto do roteamento, foi incluido no arquivo RouteConfig.cs (App_start/RouteConfig.cs) o seguinte comando : "routes.MapMvcAttributeRoutes();" .

 
� necess�rio a configura��o correta da Connection string para o seu atual banco de dados, para o devido funcionamento. A query para cria��o das tabelas
utilizadas na API est�o em um arquivo com o nome "Gera��o das tabelas" na pasta raiz do aplicativo.


 ---------------------------------------------------------------------------------------------------------------------------------------------------------------
 Utiliza��o:
 O envio de dados para a API deve ser realizado no formato Json, assim como a saida das requisi��es � no formato Json

 Campos da classe Marca: 
 {
        
	"MarcaId": 1,
  
        "MarcaNome": "exemplo"
 
 }



 A��es do controller Marca:
 	Get:--------------------------------------------------------------------------	
		GetMarcas: Retorna lista de marcas 
			http://"endere�o da api"/api/marcas

 		GetPatrimonios: retorna todos os patrimonios de uma marca
			http://"endere�o da api"/api/marcas/"Id Da Marca"/patrimonios

 		GetMarca : retorna uma marca pelo ID
			http://"endere�o da api"/api/marcas/"Id Da Marca"

	Put:--------------------------------------------------------------------------
		PutMarca - Edita os dados de uma marca pelo ID
			http://"endere�o da api"/api/marcas/"Id Da Marca"

	Post:--------------------------------------------------------------------------
		PostMarca : Cria uma nova Marca no banco de dados
			http://"endere�o da api"/api/marcas

	Delete:--------------------------------------------------------------------------
		DeleteMarca : Delta uma marca do banco de dados
			http://"endere�o da api"/api/marcas/"Id Da Marca"




 Campos da classe Patrimonio:
    {

        "PatrimonioId": 1,

        "MarcaId": 1,

        "PatrimonioNome": "exemplo",

        "PatrimonioDescricao": "exemplo",

        "PatrimonioNumTombo": 1  (n�o editavel)
    }


 A��es do controller Patrimonio
 	Get:--------------------------------------------------------------------------	
		GetMarcas: Retorna lista de marcas 
			http://"endere�o da api"/api/patrimonios

  		GetMarca : retorna uma marca pelo ID
			http://"endere�o da api"/api/patrimonios/"Id Do Patrimonio"

	Put:--------------------------------------------------------------------------
		PutMarca - Edita os dados de uma marca pelo ID
			http://"endere�o da api"/api/patrimonios/"Id Do Patrimonio"

	Post:--------------------------------------------------------------------------
		PostMarca : Cria uma nova Marca no banco de dados
			http://"endere�o da api"/api/patrimonios

	Delete:--------------------------------------------------------------------------
		DeleteMarca : Delta uma marca do banco de dados
			http://"endere�o da api"/api/patrimonios/"Id Do Patrimonio"

