# Target-Test

API construída com .NET CORE. Utilizando Entity Framework Core como ORM e o banco de dados relacional SQL Server.
Foi utilizado o conceito de Database First ao invés do Code First, com isso, focando na geração de script das entidades via SQL Server.

Entidades do projeto:<br/>
Cliente => Representa o cliente da Target;<br/>
Endereco => Representa o endereço do cliente, isto é, uma tabela com informações do cliente;<br/>
Plano => Representa os planos da Target.

Obs. 1: A tabela de Endereço só permite que o cliente tenha somente um endereço.<br/>
Obs. 2: A tabela Plano foi criada para atender uma possível alteração no futuro. Caso a target tenha interesse em criar novos planos com outros valores, essa tabela salvará e a tabela Cliente possui uma coluna de PlanoId para definir o plano. Evitando uma coluna plano vip em cliente para evitar futura refatoração.

![entidades](https://user-images.githubusercontent.com/28864256/162851970-0ac092fd-291f-4127-93c7-fa767b21e94d.jpg)

Para fazer requisições:<br/>
Adicionar no Header da requisição => "API-KEY" com valor de "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp". (sem as aspas)

Endpoints:
<br/>
Cliente:<br/>
POST => api/cliente/ => Criação do cliente.<br/>
POST => api/cliente/{id}/vip => Aplica VIP no Id do cliente.<br/>
GET => api/cliente/periodo/{dataInicio}/{dataFim} => Lista clientes através de um período de data início e data fim.<br/>
GET => api/cliente/renda/{valor} => Lista Clientes com valor igual ou superior.<br/>
GET => api/cliente/{id}/endereco => Apresenta o endereço do cliente.<br/>
PUT => api/cliente/1/endereco => Atualiza endereço do cliente.<br/>
GET = > api/cliente/podemvip => Lista todos os clientes que podem virar VIP<br/>

Plano:<br/>
GET => api/plano/vip => Mostra detalhes do plano VIP.

IBGE:<br/>
GET => api/ibge/estados => Lista estados do Brasil.<br/>
GET => api/ibge/municipios/{UF} => Lista municipios através da UF.<br/>
Obs: Esse endpoint IBGE está consultando a API do IBGE.
