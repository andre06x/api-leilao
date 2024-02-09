API Leilão
A API de Leilão resolve problemas relacionados ao gerenciamento de lances e ofertas em leilões.

Principais Funcionalidades
Gerenciamento de Autenticação:

Utiliza a biblioteca WebPush para facilitar o registro e controle de tokens, simplificando a gestão de dispositivos para os quais as notificações push serão enviadas.
Persistência de Dados:

Integra o Entity Framework com SQLite para garantir uma persistência robusta e escalável dos dados relacionados aos leilões, itens e ofertas.
Controle de Rotas da API:

Contém controladores para manipulação de leilões, itens e ofertas, oferecendo endpoints para criação, listagem e gerenciamento desses recursos.
Autenticação JWT:

Implementa autenticação JWT (JSON Web Tokens) para garantir a segurança das operações, exigindo tokens válidos para acessar determinados recursos da API.
Configuração Flexível:

Permite uma configuração flexível por meio do uso de variáveis de ambiente, especialmente para a configuração da string de conexão do banco de dados SQLite.
Como Utilizar
Configuração do Banco de Dados:

Certifique-se de configurar a string de conexão do banco de dados SQLite conforme necessário. Você pode alterar a localização do banco de dados modificando a string de conexão na classe de configuração do DbContext.
Autenticação e Autorização:

Para acessar os endpoints protegidos da API, é necessário incluir um token JWT no cabeçalho da solicitação HTTP. Esse token pode ser obtido através do endpoint de autenticação, que geralmente é /auth/login.
Endpoints Disponíveis:

A API oferece endpoints para operações básicas de CRUD (Criar, Ler, Atualizar, Excluir) relacionadas a leilões, itens e ofertas. Consulte a documentação da API ou os arquivos de código-fonte para obter uma lista completa de endpoints e suas funcionalidades.
Swagger/OpenAPI:

A API está configurada para integrar o Swagger/OpenAPI, permitindo uma fácil exploração e teste dos endpoints disponíveis. Para acessar a documentação Swagger, basta iniciar a aplicação e navegar para a URL correspondente, geralmente /swagger ou /swagger/index.html.
