# Alura Adopet Console

Este é um projeto de console para gerenciar pets utilizando uma API HTTP.O projeto é desenvolvido em C# e utiliza .NET 7.

## Estrutura do Projeto

O projeto contém as seguintes classes principais:

- `HttpClientPet`: Classe responsável por fazer requisições HTTP para a API de pets.
- `Pet`: Modelo que representa um pet.
- `Cliente`: Modelo que representa um cliente.
- `TipoPet`: Enumeração que define os tipos de pets.

## Funcionalidades

### HttpClientPet

- `CreatePetAsync(Pet pet)`: Método para criar um novo pet.
- `ListPetsAsync()`: Método para listar todos os pets.

### Pet

- `Id`: Identificador único do pet.
- `Nome`: Nome do pet.
- `Tipo`: Tipo do pet(Gato, Cachorro, etc.).
- `Proprietario`: Proprietário do pet.

### Cliente

- `Id`: Identificador único do cliente.
- `Nome`: Nome do cliente.
- `CPF`: CPF do cliente.
- `Email`: Email do cliente.

### TipoPet

Enumeração que define os tipos de pets disponíveis:
- `Gato`
- `Cachorro`
- `Reptil`
- `PorcoDaIndia`

## Requisitos

- .NET 7
- Visual Studio 2022

## Como Executar

1. Clone o repositório:

```sh
git clone https://github.com/seu-usuario/CSharp-boas-praticas.git
```
2. Abra o projeto no Visual Studio 2022.

3. Compile e execute o projeto.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.



