
# Desafio Marlin - Escola de Idiomas

Desafio oferecido pelo Alexandre Rocha para a contrução de uma API para uma escola de Idiomas, somente para avaliação do código.

## Conexão do Banco de Dados
Para instalarmos o banco de dados no nosso servidor local, precisamos alterar a string de conexão da API,
que está no arquivo `Program.cs` na linha 15, localizado na pasta `desafio-marvin\DesafioMarlin\EscolaDeIdiomas.WebApi`, trocando o nome do servidor no campo (Data Source), trocando o nome de usuário no campo (user Id), e senha no campo (pwd), adicionando os dados necessários para conexão do servidor e salvando as alterações.


![StringConexao](https://user-images.githubusercontent.com/73179530/160117983-e4a42951-05d4-4b49-b85b-153c679d40a1.png)



## Instalação

Com a solução do projeto aberta, instale o banco de dados no servidor usando o comando update-database, no Console de Gerenciador de Pacotes do NuGet

```cmd
  update-database
```

Após a instalação podemos executar o arquivo `Script DML.sql`, está localizado na pasta `desafio-marvin\ModelagemBancoDeDados` , para alimentar o nosso banco de dados.
    
## Ferramentas utilizadas

- .NET 6
- Swagger
- Entity Framework Core
- Postman
- Visual Studio 2022

## Autor

- [@mateusrodsilva](https://www.github.com/mateusrodsilva)

