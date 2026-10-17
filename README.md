# MeuControle 💜

Aplicativo de **controle financeiro pessoal**, feito em **C# e .NET MAUI 10**, com interface em português. Projeto de portfólio.

## Funcionalidades

- Registrar receitas e despesas com descrição, categoria, data e valor
- Editar e excluir lançamentos
- Filtrar por tipo de lançamento
- Visualizar saldo total, receitas e despesas
- Salvar informações localmente com SQLite (os dados permanecem ao fechar o app)
- Validação de valores e tratamento básico de erros

## Tecnologias

.NET 10 · .NET MAUI · C# · XAML · MVVM · CommunityToolkit.Mvvm · Injeção de Dependência · SQLite

## Como executar

1. Instale **Visual Studio 2026**, com a carga de trabalho de desenvolvimento .NET MAUI e o SDK .NET 10.
2. Abra `MeuControle/MeuControle.csproj` no Visual Studio.
3. Aguarde a restauração dos pacotes NuGet.
4. Escolha **Windows Machine** ou um emulador Android e pressione **F5**.

## Estrutura

- `Models`: entidade de lançamento financeiro
- `ViewModels`: estado, comandos e validações
- `Services`: armazenamento SQLite
- `Interfaces`: contrato do serviço de dados
- `Converters`: conversor de estado de botão

## Observações

- Aplicativo local, sem contas ou sincronização na nuvem.
- Valores são armazenados em **centavos inteiros** para evitar erros de arredondamento.
- O botão **Excluir** apaga imediatamente o registro selecionado.
- Teste a compilação e execução em seu ambiente antes de apresentar o projeto como concluído.

## Autor

[Adiel Alves](https://github.com/AdielAlves) · [LinkedIn](https://www.linkedin.com/in/adiel-alves-9900121b1/)
