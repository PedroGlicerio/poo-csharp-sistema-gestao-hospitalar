## <p align="center">Sistema de Gestão Hospitalar | Console Application em C#</p>

<p align="center"> Este projeto consiste em um <b>sistema desenvolvido em C# (.NET)</b> para gestão de atendimentos hospitalares. <br> A aplicação permite o cadastro de pacientes com diferentes tipos de atendimento, calcula automaticamente os custos com base nas regras de cada modalidade e gera um relatório detalhado ao final. </p>

---

## 📃 Filosofia do Projeto

O objetivo deste projeto é consolidar os principais conceitos de **Programação Orientada a Objetos (POO)** aplicando regras reais de negócio em um cenário hospitalar simulado. O sistema permite cadastrar múltiplos atendimentos e calcula automaticamente o valor final com base nas regras específicas de cada tipo.

A implementação prioriza:

- Organização e clareza
- Encapsulamento das regras de negócio
- Reaproveitamento de código com herança
- Uso de polimorfismo para comportamentos específicos
- Validação robusta no domínio da aplicação

---

## 🏥 Tipos de Atendimento

### 1️⃣ Consulta
- Custo base: R$ 200,00
- Se prioridade **Urgente**: acréscimo de 50% sobre o custo base
- Duração estimada: 1 hora

### 2️⃣ Exame
- Custo base: R$ 150,00 por exame
- Quantidade de exames: entre 1 e 10
- Se quantidade maior que 3: desconto de 10% sobre o custo total
- Duração estimada: quantidade × 30 minutos

### 3️⃣ Internação
- Custo base: R$ 800,00 por diária
- Número de diárias: entre 1 e 30
- Taxa de monitoramento fixo: R$ 200,00 por diária
- Se prioridade **Urgente**: acréscimo de 30% sobre o custo base antes do monitoramento
- Duração estimada: diárias × 24 horas

---

## 🚨 Prioridade e Status

**Prioridade:**
- Normal
- Urgente

**Status:**
- Agendado
- Em Atendimento
- Finalizado

---

## 🧠 Conceitos de POO Aplicados

- Abstração com classe abstrata `Atendimento`
- Herança com classes `AtendimentoConsulta`, `AtendimentoExame` e `AtendimentoInternacao`
- Polimorfismo através da sobrescrita dos métodos `CustoTotal()` e `Duracao()`
- Encapsulamento com validações nos construtores
- Interface `IInformacao` para exibição de dados específicos por tipo
- Enum com método de extensão (`ToDisplayString()`) para formatação de status
- Geração automática de código no formato `ATD-001`, `ATD-002`, etc.
- Sobrescrita de `ToString()` para geração de relatório formatado
- Separação entre camada de entrada (`Program`) e domínio (`Entities`)

---

## 📂 Estrutura do Projeto

```
GestaoHospitalar
│
├── Program.cs
│
├── Entities
│   ├── Atendimento.cs
│   ├── AtendimentoConsulta.cs
│   ├── AtendimentoExame.cs
│   └── AtendimentoInternacao.cs
│
├── Enums
│   ├── TipoAtendimento.cs
│   ├── PrioridadeAtendimento.cs
│   └── StatusAtendimento.cs
│
└── Services
    └── IInformacao.cs
```

---

## 💻 Tech Stack

- C#
- .NET 8 (Console Application)

---

## 🎈 Como Instalar e Executar

### Pré-requisitos
- .NET SDK 8.0 ou superior instalado

Download: https://dotnet.microsoft.com/download

---

### Passos para execução

```bash
# Clonar o repositório
git clone https://github.com/PedroGlicerio/poo-csharp-sistema-gestao-hospitalar.git

# Acessar o diretório do projeto
cd poo-csharp-sistema-gestao-hospitalar

# Executar a aplicação
dotnet run
```

---

## ⌨️ Entrada de Dados

O sistema solicita as informações diretamente pelo terminal, seguindo esta ordem:

- Quantidade de atendimentos a cadastrar
- Nome do paciente
- CPF do paciente (11 dígitos numéricos)
- Tipo do atendimento
  - 0 - Consulta
  - 1 - Exame
  - 2 - Internação
- Prioridade
  - 0 - Normal
  - 1 - Urgente
- Dados específicos conforme o tipo selecionado (quantidade de exames ou diárias)

### Exemplo de entrada (Internação Urgente)

```bash
Atendimento #1:
Paciente: Pedro Glicerio
CPF: 12345678901
Tipo [0 - Consulta | 1 - Exame | 2 - Internação]: 2
Prioridade [0 - Normal | 1 - Urgente]: 1
Diárias: 3
```

📌 Regras aplicadas neste exemplo:
- 3 diárias × R$ 800,00 = R$ 2.400,00 (custo base)
- Adicional urgente 30% → R$ 720,00
- Taxa de monitoramento: 3 × R$ 200,00 = R$ 600,00
- **Custo total: R$ 3.720,00**

---

## 📤 Saída do Sistema

```bash
=== RELATÓRIO DE ATENDIMENTOS ===

Código: ATD-003
Paciente: Pedro Glicerio
CPF: 123.456.789-01
Tipo: Internação | Prioridade: Urgente
Custo base: R$2400.00
Diárias: 3
Adicional urgente (30%): R$720.00
Taxa de monitoramento: R$600.00
Custo total: R$3720.00
Duração estimada: 72 hora(s)
Status: Em Atendimento
----------------------------------------

```

---

## 📌 Regras e Validações

- Nome não pode ser vazio e deve conter apenas letras
- CPF deve conter exatamente 11 dígitos numéricos
- Tipo de atendimento e prioridade devem ser opções válidas
- Quantidade de exames deve estar entre 1 e 10
- Número de diárias deve estar entre 1 e 30
- Validações aplicadas tanto na entrada quanto nos construtores das entidades

As regras críticas estão encapsuladas no domínio, garantindo integridade dos dados independentemente da camada de entrada.

---

## 📝 Aprendizados

Durante o desenvolvimento deste projeto, pude consolidar diversos conceitos de **Programação Orientada a Objetos (POO)** aplicados na prática:

- Uso de **classe abstrata** (`Atendimento`) para definir contrato comum entre os tipos de atendimento
- Aplicação de **modificadores de acesso** (`public`, `protected`, `private`) para organizar visibilidade e proteger métodos e propriedades
- Implementação de **herança e polimorfismo** para representar comportamentos e cálculos específicos de cada tipo
- Uso de **interface** (`IInformacao`) para padronizar a exibição de informações específicas por tipo
- Criação de **método de extensão** em enum para formatar a exibição do status sem alterar o domínio
- Criação de **validações robustas** no domínio da aplicação, garantindo integridade dos dados
- Uso de **LINQ** para ordenação e agregação no relatório final

---

## 📎 Considerações Finais

Este projeto foi desenvolvido como exercício prático de modelagem orientada a objetos, aplicando regras reais de negócio em um cenário hospitalar simulado. Um exercício sólido para consolidar abstração, herança, polimorfismo e encapsulamento em C#.
