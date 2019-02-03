# EncurtadorUrl
Repositório Criado para teste de Vaga de Emprego

Endereço GIT: https://github.com/andrewmaia/EncurtadorUrl.git

Como utilizar?
Rodar a API pelo Visual Studio Code (Pressionar F5)
A API deve rodar com o endereço https://localhost:5001/
Todas os endpoints estão com o padrão de endereço api/controller

Foi utilizado um banco de dados MySql. Não é necessário se preocupar com ele pois o mesmo está na LocaWeb e aplicação já está apontando para ele. De qualquer forma um arquivo com o script de criação do banco e das tabelas está junto a solução: DataBaseCreation.sql 

Para os endpoins que não é possível rodar via brownser (Post e Delete) há um arquivo postman na solução com as requisições prontas: EncurtadorUrl.postman_collection.json. Baixar software Postman para esse tipo de teste e importar o arquivo.

Abaixo todos os endereços para teste dos endpoints (Na ordem do PDF do teste):

Redireciona para a URL:
https://localhost:5001/api/urls/9
(A URL 9 já existe no banco)

Cria nova URL:
https://localhost:5001/api/users/3/urls  
(Utilizar Postman. Requisição: "Postar nova URL") 
(O usuário 3 já existe no banco) 

Estatísticas do Sistema:
https://localhost:5001/api/stats

Estatísticas de Urls de um usuário:
https://localhost:5001/api/users/3/stats (O usuário 3 já existe no banco) 

Estatísticas de uma Url:
https://localhost:5001/api/stats/9 
(A URL 9 já existe no banco)

Exclui uma URL :
https://localhost:5001/api/urls/:id 
(Utilizar Postman. Requisição: "Excluir URL")
(Substituir :id por um id de uma URL existente) 

Cria novo Usuario:
https://localhost:5001/api/users
(Utilizar Postman. Requisição: "Postar novo Usuario")

Exclui um Usuário:
https://localhost:5001/api/users/:id   
(Utilizar Postman. Requisição: "Excluir Usuario")
(Substituir :id por um id de um usuario existente) 


Arquitetura

O endpoints acessam os controllers  (Pasta Controllers) que por sua vez por injeção de depêndencia acessam o serviço responsável por executar a atividade em questão. Não estou usando nennhum framework de injeção de dependência, a injeção é feita manualmente no arquivo Startup.cs.


Os serviços (Pasta Services) são responsáveis por implementar todas as regras do sistema. Apenas os serviços acessam o bando dados através do EntityFrameWork (Pacote Pomelo.EntityFrameworkCore.MySql).


O EntityFrameWork está configurado no modo lazy para evitar carregamentos desnecessários de dados (Microsoft.EntityFrameworkCore.Proxies).

Foi utilizado o AutoMapper para mapear campos dos Models para DTO's e impedir a exposição de alguns dados sensíveis que um Model utilizado pelo sistema possa ter. 
