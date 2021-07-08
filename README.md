# Projeto ATS

Tanto o frontend, quanto o backend foram desenvolvidos no VS Code.
Instruções para executar o projeto:

#### Passo comum:
Clonar o projeto

#### Observações/pré-requisitos:
* Possuir Node instalado - versão utilizada: 14.16.1;
* Possuir Angular instalado - versão utilizada: 12.1.1;
* Possuir SDK .NET Core instalado - versão utilizada: 3.1.410;
* Possuir Banco de Dados MySQL instalado (usuário/senha utilizado: root/root) - versão utilizada: 8.0.25.0.

<br>

### Frontend
Via linha de comando, entrar na pasta "Frontend", executar o comando para instalar as dependências do projeto:\
_npm i_

Após instalar as dependências, executar o start:\
_ng s_

<br>

### Backend
Via linha de comando, entrar na pasta "API", executar o comando para restaurar/instalar as dependências do projeto:\
_dotnet restore_

Executar o comando para compilar o projeto e dependências:\
_dotnet build_

Executar o comando para executar o projeto:\
_dotnet run --project API.Application_

<br>

<hr>

Ao final, o projeto deverá estar disponível na URL:\
http://localhost:4200
