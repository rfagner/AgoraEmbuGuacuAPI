

# AgoraEmbuGuacuAPI

Plataforma web que oferecerá uma maneira centralizada para a prefeitura, órgãos governamentais locais e a população se comunicarem e compartilharem informações.

## Índice

- [Início Rápido](#início-rápido)
- [Recursos](#recursos)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Início Rápido

Bem-vindo à documentação da API AgoraEmbuGuacuAPI. Esta API permite  gerenciar denúncias na cidade de Embu-Guaçu. Abaixo, você encontrará informações detalhadas sobre como usar a API, incluindo autenticação e exemplos de chamadas de API.


## Autenticação
A API utiliza autenticação baseada em tokens JWT (JSON Web Tokens) para proteger seus endpoints. Para acessar os recursos da API, siga as etapas de autenticação abaixo:

## Registro e Autenticação
Registro de Usuário
Para registrar uma nova conta, envie uma solicitação POST para o endpoint /api/auth/register.

Exemplo de registro:

```
POST /api/auth/register
Content-Type: application/json

{
  "username": "seu_usuario",
  "email": "seu_email@example.com",
  "password": "sua_senha_secreta"
}
```
Autenticação

Para fazer login e obter um token JWT válido, envie uma solicitação POST para o endpoint /api/auth/login.

Exemplo de login:

```
POST /api/auth/login
Content-Type: application/json

{
  "email": "seu_email@example.com",
  "password": "sua_senha_secreta"
}
```
Após o login bem-sucedido, o servidor retornará um token JWT que você deve incluir nas solicitações para os endpoints protegidos.

## Uso do Token JWT
Ao acessar endpoints protegidos, inclua o token JWT no cabeçalho Authorization. O token JWT deve ser precedido pela palavra "Bearer".

Exemplo de chamada a um endpoint protegido:

```
GET /api/denuncias
Authorization: Bearer seu_token_jwt_aqui
```

## Exemplos de Chamadas de API
Aqui estão alguns exemplos de chamadas de API comuns:

- Criar uma Nova Denúncia
Para criar uma nova denúncia, faça uma solicitação POST para o endpoint /api/denuncias. Certifique-se de estar autenticado.

Exemplo de chamada para criar uma nova denúncia:

```
POST /api/denuncias
Authorization: Bearer seu_token_jwt_aqui
Content-Type: application/json

{
  "titulo": "Denúncia de poluição sonora",
  "descricao": "Relatando uma situação de poluição sonora na Rua XYZ.",
  "localizacao": "Rua XYZ, Bairro ABC",
  "tipo": "Poluição Sonora"
}
```

- Obter uma Lista de Denúncias
Para obter uma lista de denúncias, faça uma solicitação GET para o endpoint /api/denuncias.

Exemplo de chamada para obter uma lista de denúncias:

```
GET /api/denuncias
```

- Atualizar uma Denúncia Existente
Para atualizar uma denúncia existente, faça uma solicitação PUT para o endpoint /api/denuncias/{id}, onde {id} é o ID da denúncia que você deseja atualizar. Certifique-se de estar autenticado.

Exemplo de chamada para atualizar uma denúncia:

```
PUT /api/denuncias/1
Authorization: Bearer seu_token_jwt_aqui
Content-Type: application/json

{
  "descricao": "Situação de poluição sonora foi resolvida."
}
```

- Excluir uma Denúncia
Para excluir uma denúncia, faça uma solicitação DELETE para o endpoint /api/denuncias/{id}, onde {id} é o ID da denúncia que você deseja excluir. Certifique-se de estar autenticado.

Exemplo de chamada para excluir uma denúncia:

```
DELETE /api/denuncias/1
Authorization: Bearer seu_token_jwt_aqui
```

## Erros e Manipulação de Exceções
A API retorna respostas com códigos de status HTTP apropriados para indicar o resultado de uma solicitação. Em caso de erros ou exceções, a resposta conterá detalhes sobre o erro no corpo JSON. Certifique-se de verificar o código de status da resposta.

### Recursos

1. Registro de Usuário: Os usuários podem se registrar na plataforma fornecendo um nome de usuário, endereço de e-mail e senha. Isso permite que eles acessem recursos protegidos da API.

2. Autenticação: A API utiliza autenticação baseada em tokens JWT (JSON Web Tokens) para proteger seus endpoints. Os usuários autenticados recebem um token JWT válido para acessar recursos protegidos.

3. Gerenciamento de Denúncias: Os usuários autenticados podem criar denúncias, fornecendo informações como título, descrição, localização e tipo de denúncia.

4. Listagem de Denúncias: A API fornece endpoints para listar denúncias registradas. Os usuários podem consultar todas as denúncias ou filtrá-las com base em critérios específicos.

5. Atualização de Denúncias: Os criadores de denúncias podem atualizar informações sobre suas denúncias, como descrição e status.

6. Exclusão de Denúncias: Os criadores de denúncias têm a opção de excluir suas denúncias.

7. Documentação da API: A API é acompanhada de uma documentação detalhada que descreve todos os endpoints, métodos, parâmetros e exemplos de uso.

8. Validação de Dados: A API realiza validação de dados para garantir que as informações fornecidas pelos usuários estejam corretas e seguras.

9. Segurança: A autenticação baseada em tokens e a proteção dos endpoints garantem a segurança das informações e dos recursos da API.

10. Tratamento de Erros: A API lida com erros e exceções de maneira adequada, fornecendo respostas com códigos de status HTTP apropriados e detalhes sobre os erros.

11. Swagger: A API inclui a configuração do Swagger para facilitar o teste e a exploração dos endpoints por meio de uma interface gráfica.

12. Persistência de Dados: Os dados das denúncias e usuários são persistidos em um banco de dados, garantindo que as informações sejam armazenadas de forma segura.

## Pré-requisitos

- [.NET 6 ou superior](https://dotnet.microsoft.com/download/dotnet)

## Instalação

1. Clone o repositório:

```
git clone https://github.com/rfagner/AgoraEmbuGuacuAPI.git
```

2. Navegue até o diretório do projeto:

```
cd AgoraEmbuGuacuAPI
```

3. Restaure as dependências:

```
dotnet restore
```

4. Execute a aplicação:

```
dotnet run
```

## Configuração

Para configurar a AgoraEmbuGuacuAPI, você precisará seguir algumas etapas específicas. Aqui está um guia passo a passo para configurar a API:

### 1. Requisitos Prévios

Certifique-se de que você tenha os seguintes requisitos prévios instalados em seu sistema:

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (versão 5.0 ou superior)
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/) (opcional, mas recomendado)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) ou outro banco de dados compatível

### 2. Clonar o Repositório

Clone o repositório da AgoraEmbuGuacuAPI para o seu ambiente de desenvolvimento:

```bash
git clone https://github.com/rfagner/AgoraEmbuGuacuAPI.git
```

### 3. Configurar o Banco de Dados

Você precisa configurar o banco de dados para a API. Abra o arquivo `appsettings.json` na raiz do projeto e atualize a seção `ConnectionStrings` com os detalhes do seu banco de dados MySQL:

```json
"ConnectionStrings": {
    "ConexaoPadrao": "sua-string-de-conexao-do-mysql"
}
```

### 4. Configurar Variáveis de Ambiente

A API pode usar variáveis de ambiente para armazenar informações sensíveis, como a chave secreta JWT. Crie um arquivo chamado `.env` na raiz do projeto e adicione as variáveis de ambiente necessárias, como:

```env
JWT_SECRET_KEY=sua-chave-secreta-jwt
```

### 5. Instalar as Dependências

Abra um terminal na raiz do projeto e execute o seguinte comando para restaurar todas as dependências do projeto:

```bash
dotnet restore
```

### 6. Aplicar as Migrações do Banco de Dados

Execute as migrações do banco de dados para criar as tabelas necessárias. No terminal, execute os seguintes comandos:

```bash
dotnet ef migrations add InitialMigration
dotnet ef database update
```

### 7. Executar a API

Agora, você pode iniciar a API. Use o seguinte comando:

```bash
dotnet run
```

A API estará acessível em `http://localhost:5000` (ou `https://localhost:5001` com HTTPS) por padrão.

### 8. Testar a API

Você pode usar ferramentas como [Swagger](https://swagger.io/) para testar os endpoints da API. Basta acessar `http://localhost:5000/swagger` no seu navegador para explorar a documentação da API e testar os endpoints.

### 9. Configurações Adicionais

Você pode ajustar outras configurações no arquivo `appsettings.json`, como configurações de autenticação, configurações de banco de dados e muito mais, conforme necessário.

Lembre-se de que este é um guia básico de configuração. Dependendo das necessidades específicas do seu projeto, você pode precisar fazer configurações adicionais.

Certifique-se de manter suas variáveis de ambiente seguras e não compartilhá-las publicamente. É uma prática recomendada usar um arquivo `.env` para armazenar essas informações sensíveis e adicioná-lo ao seu arquivo `.gitignore` para evitar que ele seja incluído em seu controle de versão.

## Contribuição

Nós encorajamos contribuições para a AgoraEmbuGuacuAPI. Para contribuir, siga estas etapas:

1. Faça um fork do repositório.
2. Crie uma nova branch com sua contribuição: `git checkout -b minha-contribuicao`
3. Faça suas alterações e faça commit: `git commit -m "Adiciona nova funcionalidade"`
4. Envie suas alterações: `git push origin minha-contribuicao`
5. Abra uma solicitação de pull para a branch principal do repositório original.

## Licença

Este projeto é licenciado sob a Licença MIT - consulte o arquivo [LICENSE.md](LICENSE.md) para obter detalhes.

## Autor

- [Renildo Fagner - Desenvolvedor Back-end](https://www.linkedin.com/in/rfagner/)
- [Raphael Rodrigues - Desenvolvedor Front End](https://www.linkedin.com/in/raphael-rodrigues-85ab69168/)
- [Júlia Vasconcelos - UX/UI Designer](https://www.linkedin.com/in/juvscncls/)
- [Michelle Azevedo - Desenvolvedor Front-end](https://www.linkedin.com/in/rfagner/)
- [Tiago Nascimento - Desenvolvedor Back-end](https://www.linkedin.com/in/tiago-nascimento-hilario/)


## Agradecimentos

- [Sthevan Bello Alves](https://www.linkedin.com/in/sthevan/)

## Status do Projeto

[Em Beta]

---


