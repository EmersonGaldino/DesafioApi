Construção:

 Para a construção do aplicativo, foi usado o Entity Framework conectado a um banco de dados na plataforma Azure.
 Foi criado um Ado.Net Entity Data Model, que conectado ao banco de dados SQL, criou automaticamente as classes de modelo de acordo com as tabelas do SQL, e o 
DBContext para o aplicativo, responsavel pela conexão com o banco de dados.
 Foi usado data anottation para definir quais propriedades são obrigatórias ([Required]).
 Caso seja gerado pelo Entity Framewok a anotação "[key]", a mesma deve ser removida. Ao não ser removida, é gerado um erro na tentativa
de edição de itens no banco de dados.

  Na classe Patrimonios, o Setter da clase foi definido como Private para o atributo "PatrimonioNumTombo",  sendo que só é 
  atribuido um valor aleatório na criação da classe, para motivos de demonstração.
  No modelo atual, não é possivel modificar o valor posteriormente. 

 Na criação da tabela de Marca , a coluna MarcaNome foi definida como Unique, não aceitando valores repetidos inseridos. Na tentativa de inserção
de um valor que já exista na tabela, ocorrerá um erro.
 
 A estrutura das tabelas utilizadas ficaram com os seguintes atributos


 Marca: 
	MarcaId (CHAVE PRIMARIA)
 	MarcaNome (NOT NULL)
 
 Patrimonio:
	PatrimonioId (CHAVE PRIMARIA)
	PatrimonioNome (NOT NULL)
  	MarcaId (CHAVE ESTRANGEIRA) 
	PatrimonioDescricao
	PatriomonioTombo (embora aceite nulo pelo banco de dados, é atribuido um valor automaticamente pela API)


 Controller: 
 Os controllers foram criados automaticamente com a ajuda do Entity Framework, sendo necessário somente a adição da opção de listagem de patrimonios por marca.

 Para a rota :
	GET marcas/{id}/patrimônios
 foi incluido no controller MarcasController o atributo "[Route("api/Marcas/{marcaId}/Patrimonios")]" , responsavel pelo encaminhamento da rota para o controller
que realiza a listagem dos patrimonios referente a marca selecionada.
 Para o funcionamento correto do roteamento, foi incluido no arquivo RouteConfig.cs (App_start/RouteConfig.cs) o seguinte comando : "routes.MapMvcAttributeRoutes();" .

 
É necessário a configuração correta da Connection string para o seu atual banco de dados, para o devido funcionamento. A query para criação das tabelas
utilizadas na API estão em um arquivo com o nome "Geração das tabelas" na pasta raiz do aplicativo.


 ---------------------------------------------------------------------------------------------------------------------------------------------------------------
 Utilização:
 O envio de dados para a API deve ser realizado no formato Json, assim como a saida das requisições é no formato Json

 Campos da classe Marca: 
 {
        
	"MarcaId": 1,
  
        "MarcaNome": "exemplo"
 
 }



 Ações do controller Marca:
 	Get:--------------------------------------------------------------------------	
		GetMarcas: Retorna lista de marcas 
			http://"endereço da api"/api/marcas

 		GetPatrimonios: retorna todos os patrimonios de uma marca
			http://"endereço da api"/api/marcas/"Id Da Marca"/patrimonios

 		GetMarca : retorna uma marca pelo ID
			http://"endereço da api"/api/marcas/"Id Da Marca"

	Put:--------------------------------------------------------------------------
		PutMarca - Edita os dados de uma marca pelo ID
			http://"endereço da api"/api/marcas/"Id Da Marca"

	Post:--------------------------------------------------------------------------
		PostMarca : Cria uma nova Marca no banco de dados
			http://"endereço da api"/api/marcas

	Delete:--------------------------------------------------------------------------
		DeleteMarca : Delta uma marca do banco de dados
			http://"endereço da api"/api/marcas/"Id Da Marca"




 Campos da classe Patrimonio:
    {

        "PatrimonioId": 1,

        "MarcaId": 1,

        "PatrimonioNome": "exemplo",

        "PatrimonioDescricao": "exemplo",

        "PatrimonioNumTombo": 1  (não editavel)
    }


 Ações do controller Patrimonio
 	Get:--------------------------------------------------------------------------	
		GetMarcas: Retorna lista de marcas 
			http://"endereço da api"/api/patrimonios

  		GetMarca : retorna uma marca pelo ID
			http://"endereço da api"/api/patrimonios/"Id Do Patrimonio"

	Put:--------------------------------------------------------------------------
		PutMarca - Edita os dados de uma marca pelo ID
			http://"endereço da api"/api/patrimonios/"Id Do Patrimonio"

	Post:--------------------------------------------------------------------------
		PostMarca : Cria uma nova Marca no banco de dados
			http://"endereço da api"/api/patrimonios

	Delete:--------------------------------------------------------------------------
		DeleteMarca : Delta uma marca do banco de dados
			http://"endereço da api"/api/patrimonios/"Id Do Patrimonio"

