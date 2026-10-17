# 💜 MeuControle — Controle Financeiro Pessoal

**Aplicativo multiplataforma desenvolvido com C#, .NET MAUI 10, XAML, MVVM e SQLite.**

O **MeuControle** é um aplicativo de controle financeiro pessoal que permite organizar receitas e despesas de maneira simples, prática e intuitiva.

Desenvolvido como projeto de portfólio, seu objetivo é demonstrar a aplicação de conceitos utilizados no desenvolvimento de software, como arquitetura MVVM, Injeção de Dependência, persistência de dados e construção de interfaces multiplataforma.

## 📱 Capturas de tela

*Em breve: capturas reais das versões Windows e Android.*

## 🚀 Funcionalidades

- Cadastro de receitas e despesas com descrição, categoria, data e valor.
- Edição e exclusão de lançamentos financeiros.
- Filtros por tipo de movimentação.
- Cálculo automático do saldo disponível.
- Resumo de receitas e despesas.
- Persistência local utilizando SQLite.
- Validação de valores e tratamento básico de erros.
- Interface em português com tema escuro.

## 🛠️ Tecnologias utilizadas

| Tecnologia | Aplicação |
|---|---|
| C# | Linguagem de programação |
| .NET 10 | Plataforma de desenvolvimento |
| .NET MAUI | Desenvolvimento multiplataforma |
| XAML | Construção da interface |
| MVVM | Separação entre interface e lógica de apresentação |
| CommunityToolkit.Mvvm | Propriedades observáveis e comandos |
| Injeção de Dependência | Gerenciamento das dependências |
| SQLite | Armazenamento local de dados |

## 🏗️ Arquitetura do projeto

O aplicativo foi organizado utilizando o padrão **MVVM (Model-View-ViewModel)**, com separação de responsabilidades para facilitar a manutenção e evolução do código.

### Organização

- **Models:** representação dos lançamentos financeiros.
- **ViewModels:** lógica de apresentação, comandos, validações e atualização da interface.
- **Services:** operações de persistência utilizando SQLite.
- **Interfaces:** contratos utilizados para abstração dos serviços.
- **Converters:** conversão de valores utilizados nos bindings.
- **Views/XAML:** construção visual das telas.

A Injeção de Dependência é utilizada para registrar e disponibilizar os serviços e componentes necessários ao funcionamento do aplicativo.

## 💾 Persistência de dados

O MeuControle utiliza SQLite para armazenar as movimentações financeiras localmente.

Os valores monetários são armazenados em centavos inteiros, reduzindo problemas de precisão em operações financeiras.

Os registros permanecem disponíveis mesmo após o encerramento do aplicativo, sem necessidade de conexão com a internet.

## 🧪 Testes realizados

O aplicativo foi executado no Windows e teve suas principais funcionalidades testadas em um dispositivo Android.

**Testes funcionais realizados com sucesso no Android:**

- Inicialização sem erros ou travamentos.
- Cadastro de receitas e despesas.
- Atualização automática do saldo.
- Edição e exclusão de lançamentos.
- Funcionamento dos filtros.
- Persistência dos dados após fechar e reabrir o aplicativo.

Exemplo de validação financeira:

| Operação | Valor |
|---|---:|
| Receita cadastrada | R$ 1.500,00 |
| Despesa cadastrada | R$ 350,00 |
| Saldo calculado | R$ 1.150,00 |

*Os testes descritos são manuais e não substituem testes automatizados.*

## 💻 Como executar o projeto

### Pré-requisitos

- Visual Studio 2026 com suporte ao .NET MAUI.
- SDK .NET 10.
- Ambiente Windows configurado ou dispositivo/emulador Android.
- Pacotes NuGet restaurados.

### Execução

1. Clone o repositório:

   `git clone https://github.com/AdielAlves/MeuControle.git`

2. Abra `MeuControle/MeuControle.csproj` no Visual Studio.
3. Aguarde a restauração dos pacotes NuGet.
4. Selecione Windows Machine ou um dispositivo Android.
5. Pressione **F5** para compilar e executar.

## 📌 Limitações atuais

- O aplicativo funciona com armazenamento local.
- Não possui autenticação de usuários.
- Não oferece sincronização em nuvem.
- A exclusão de lançamentos é imediata.

## 🎯 Objetivo do projeto

Este projeto faz parte do meu portfólio de desenvolvimento de software, com foco na construção de aplicações utilizando **C# e .NET MAUI**.

Seu desenvolvimento permitiu colocar em prática conceitos de organização de código, arquitetura MVVM, persistência de dados, Injeção de Dependência e desenvolvimento multiplataforma.

## 👨‍💻 Autor

**Adiel Alves**

Desenvolvedor em formação, com foco em C# e .NET MAUI.

[GitHub](https://github.com/AdielAlves) · [LinkedIn](https://www.linkedin.com/in/adiel-alves-9900121b1/)
