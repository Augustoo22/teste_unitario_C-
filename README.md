# SimpleApp - Calculadora com Testes Unitários em C#

Este projeto demonstra uma aplicação simples em C# que implementa uma calculadora básica com operações aritméticas fundamentais (adição, subtração, multiplicação e divisão) e testes unitários utilizando o NUnit.

## Sumário

- [Introdução](#introdução)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Configuração do Ambiente](#configuração-do-ambiente)
- [Implementação](#implementação)
  - [Classe Calculator](#classe-calculator)
  - [Testes Unitários](#testes-unitários)
- [Execução dos Testes](#execução-dos-testes)
- [Resultados Esperados](#resultados-esperados)

## Introdução

O objetivo deste projeto é demonstrar como criar uma aplicação simples em C#, implementar testes unitários utilizando o framework NUnit e executar esses testes para garantir que o código está funcionando conforme o esperado.

## Estrutura do Projeto

```
SimpleApp/
├── SimpleApp.sln
├── SimpleApp/
│   ├── Calculator.cs
│   └── SimpleApp.csproj
└── SimpleAppTests/
    ├── CalculatorTests.cs
    └── SimpleAppTests.csproj
```

- **SimpleApp**: Diretório do projeto principal contendo a classe `Calculator`.
- **SimpleAppTests**: Diretório do projeto de testes contendo os testes unitários da classe `Calculator`.

## Configuração do Ambiente

Certifique-se de ter o .NET SDK instalado em sua máquina. Você pode verificar a instalação executando:

```bash
dotnet --version
```

Este projeto utiliza o .NET 8.0.

## Implementação

### Classe Calculator

A classe `Calculator` implementa quatro métodos básicos de operações aritméticas:

- `Somar(int a, int b)`: Retorna a soma de dois números inteiros.
- `Subtract(int a, int b)`: Retorna a diferença entre dois números inteiros.
- `Multiply(int a, int b)`: Retorna o produto de dois números inteiros.
- `Divide(int a, int b)`: Retorna o quociente de dois números inteiros. Lança uma exceção se o divisor for zero.

#### Código: `Calculator.cs`

```csharp
using System;

namespace SimpleApp
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    
        public int Subtract(int a, int b)
        {
            return a - b;
        }
    
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    
        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return (double)a / b;
        }
    }
}
```

### Testes Unitários

Os testes unitários verificam cada método da classe `Calculator`, garantindo que eles retornem os resultados esperados. Também é testado o comportamento do método `Divide` quando o divisor é zero.

#### Código: `CalculatorTests.cs`

```csharp
using NUnit.Framework;
using SimpleApp;

namespace SimpleAppTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_ShouldReturnSumOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 5;
            int b = 3;
    
            // Act
            var result = calculator.Add(a, b);
    
            // Assert
            Assert.That(result, Is.EqualTo(8), "O método Add deve retornar a soma de dois números.");
            TestContext.WriteLine($"Add Test Passed: {a} + {b} = {result}");
        }
    
        [Test]
        public void Subtract_ShouldReturnDifferenceOfTwoNumbers()
        {
            var calculator = new Calculator();
            int a = 10;
            int b = 4;
    
            var result = calculator.Subtract(a, b);
    
            Assert.That(result, Is.EqualTo(6), "O método Subtract deve retornar a diferença de dois números.");
            TestContext.WriteLine($"Subtract Test Passed: {a} - {b} = {result}");
        }
    
        [Test]
        public void Multiply_ShouldReturnProductOfTwoNumbers()
        {
            var calculator = new Calculator();
            int a = 6;
            int b = 7;
    
            var result = calculator.Multiply(a, b);
    
            Assert.That(result, Is.EqualTo(42), "O método Multiply deve retornar o produto de dois números.");
            TestContext.WriteLine($"Multiply Test Passed: {a} * {b} = {result}");
        }
    
        [Test]
        public void Divide_ShouldReturnQuotientOfTwoNumbers()
        {
            var calculator = new Calculator();
            int a = 20;
            int b = 4;
    
            var result = calculator.Divide(a, b);
    
            Assert.That(result, Is.EqualTo(5.0), "O método Divide deve retornar o quociente de dois números.");
            TestContext.WriteLine($"Divide Test Passed: {a} / {b} = {result}");
        }
    
        [Test]
        public void Divide_ByZero_ShouldThrowDivideByZeroException()
        {
            var calculator = new Calculator();
            int a = 10;
            int b = 0;
    
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(a, b), "O método Divide deve lançar uma exceção ao dividir por zero.");
            TestContext.WriteLine($"Divide By Zero Test Passed: {a} / {b} lança exceção.");
        }
    }
}
```

## Execução dos Testes

Para executar os testes unitários, siga os passos abaixo:

1. **Restaurar as Dependências**:

   No diretório raiz do projeto, execute:

   ```bash
   dotnet restore
   ```

2. **Compilar a Solução**:

   ```bash
   dotnet build
   ```

3. **Executar os Testes**:

   ```bash
   dotnet test
   ```

## Resultados Esperados

Ao executar os testes, a saída deve indicar que todos os testes passaram com sucesso:

```plaintext
Iniciando execução de teste, espere...
1 arquivos de teste no total corresponderam ao padrão especificado.

Aprovado!  – Com falha:     0, Aprovado:     5, Ignorado:     0, Total:     5, Duração: XX ms - SimpleAppTests.dll (net8.0)

Standard Output Messages:
Add Test Passed: 5 + 3 = 8
Subtract Test Passed: 10 - 4 = 6
Multiply Test Passed: 6 * 7 = 42
Divide Test Passed: 20 / 4 = 5
Divide By Zero Test Passed: 10 / 0 lança exceção.
```

Isso confirma que todos os métodos estão funcionando conforme o esperado e que o tratamento de exceção para divisão por zero está implementado corretamente.

---

**Observação**: Substitua `XX ms` pelo tempo real de execução que será exibido ao rodar os testes.

## Conclusão

Este projeto simples demonstra como implementar uma classe básica em C# e como escrever testes unitários eficazes usando o NUnit. Os testes unitários são fundamentais para garantir a qualidade e a confiabilidade do código, especialmente em projetos maiores e mais complexos.

---
