# Decuadra-Ferrari-Meerhoff <!-- omit in toc -->

This project was created as part of Agile Software Engineering 2 (7675) course.
The main focus of the project is to put in practice DevOps concepts taught throughout the course.

## Students <!-- omit in toc -->

- Sofía Decuadra (233397)
- Agustín Ferrari (240503)
- Joaquín Meerhoff (247096)

## Table of contents <!-- omit in toc -->

- [Folder distribution](#folder-distribution)
- [Getting started](#getting-started)
  - [Frontend](#frontend)
  - [Backend](#backend)
  - [Integration tests](#integration-tests)
  - [Utilities](#utilities)
    - [Database](#database)
    - [Commitizen](#commitizen)
- [Sprint 1](#sprint-1)
- [Sprint 2](#sprint-2)
- [Sprint 3](#sprint-3)
- [Original Project](#original-project)

## Folder distribution

The three main folders are:

- Documentation:
  All aspects that aim to inform team members about the processes that wrap our practices and the development of code itself.
- Source code:
  Where our code is archived, divided in frontend and backend.
- Utilities:
  Tools and test data for our code

**General Structure:**

- [Documentation](./Documentation)
  - [Previous documentation](./Documentation/PreviousDocumentation/)
    - [Original documentation](./Documentation/PreviousDocumentation/Documentacion.pdf)
    - [Original documentation's diagrams](./Documentation/PreviousDocumentation/Diagramas%20UML/)
  - [Engineering process](./Documentation/EngineeringProcess.md)
  - [Technical debt](./Documentation/TechnicalDebt.md)
  - [BDD  Guide](./Documentation/BDDGuide.md)
  - [Metrics Analysis](./Documentation/MetricsAnalysis.md)
  - [Pipeline Guide](./Documentation/PipelineGuide.md)
  - [Sprint 1](./Documentation/Sprint1/)
    - [Planning meeting](./Documentation/Sprint1/PlanningMeeting.md)
    - [Retrospective](./Documentation/Sprint1/Retrospective.md)
    - [Report](./Documentation/Sprint1/Report.pdf)
  - [Sprint 2](./Documentation/Sprint2/)
    - [Planning meeting](./Documentation/Sprint2/PlanningMeeting.md)
    - [Retrospective](./Documentation/Sprint2/Retrospective.md)
    - [Report](./Documentation/Sprint2/Report.pdf)
  - [Sprint 3](./Documentation/Sprint3/)
    - [Planning meeting](./Documentation/Sprint3/PlanningMeeting.md)
    - [Retrospective](./Documentation/Sprint3/Retrospective.md)
    - [Report](./Documentation/Sprint3/Report.pdf)
- [Source code](./Source)
  - [Backend](./Source/MinTurBackend/)
  - [Frontend](./Source/MinTurFrontend/)
- [Utilities](./Utilities/)
  - [Database scripts](./Utilities/DatabaseScripts/)

## Getting started

---
### Frontend

**Run:**

```bash
cd ./Source/MinTurFrontend
npm install --force
npm run start
```

**Lint:**

```bash
cd ./Source/MinTurFrontend
npm install --force
npm run lint
```

### Backend

**Run:**

```bash
cd ./Source/MinTurBackend
dotnet restore
dotnet run
```

**Lint:** (After build warnings and errors are shown)

```bash
cd ./Source/MinTurBackend
dotnet bulid
```

### Integration tests

**Run:**

```bash
cd ./Source/IntegrationTests
dotnet restore
dotnet test
```
### Utilities

#### Database

Create a new database named 'NaturalUruguayDB' and import the data from [Filled script](./Utilities/DatabaseScripts/Filled/NaturalUruguayDBFilled.sql).


#### Commitizen

**Install: (Windows)**

```bash
npm install -g commitizen
npm install
```

**Install: (Mac)**

```bash
brew install commitizen
```

**Commit (After git add)**

Windows:

```bash
cz
```

Mac:

```bash
cz c
```

## Sprint 1

The first sprint consisted on repository creation, use and definition of engineering process and technical debt analysis.

### Documentation: <!-- omit in toc -->

- [Documentation](./Documentation)
  - [Engineering process](./Documentation/EngineeringProcess.md)
  - [Technical debt](./Documentation/TechnicalDebt.md)
  - [Sprint 1](./Documentation/Sprint1/)
    - [Effort](./Documentation/Sprint1/Effort.md)
    - [Planning meeting](./Documentation/Sprint1/PlanningMeeting.md)
    - [Retrospective](./Documentation/Sprint1/Retrospective.md)
    - [Report](./Documentation/Sprint1/Report.pdf)
- [.github](./.github)
  - [Pull request template](/.github/pull_request_template.md)
  - [ISSUE_TEMPLATE](./.github/ISSUE_TEMPLATE/)
    - [Issue template](/.github/ISSUE_TEMPLATE/bug_report.md)

## Sprint 2

The second sprint consisted on development following BDD, issue fixing and backend pipeline configuration using github actions and github project beta.

### Documentation: <!-- omit in toc -->

- [Documentation](./Documentation)
  - [Sprint 2](./Documentation/Sprint2/)
    - [BDD Development Guide](./Documentation/Sprint2/BDDDevelopmentGuide.md)
    - [Backend Pipeline Configuration](./Documentation/Sprint2/BackendPipelineConfiguration.md)
    - [Effort](./Documentation/Sprint2/Effort.md)
    - [Planning meeting](./Documentation/Sprint2/PlanningMeeting.md)
    - [Report](./Documentation/Sprint2/Report.pdf)
    - [Retrospective](./Documentation/Sprint2/Retrospective.md)
    - [Requirements Definition](./Documentation/Sprint2/RequirementsDefinition.md)
    - [Video Review](https://youtu.be/xDyq6rzCfdE)


## Sprint 3

The third sprint consisted on frontend development following BDD with Selenium, updating BDD guide and Pipeline guide, and continuing maintenance.

### Documentation: <!-- omit in toc -->

- [Documentation](./Documentation/)
  - [Sprint 3](./Documentation/Sprint3/)
      - [Effort](./Documentation/Sprint3/Effort.md)
      - [Planning meeting](./Documentation/Sprint3/PlanningMeeting.md)
      - [Report](./Documentation/Sprint3/Report.pdf)
      - [Retrospective](./Documentation/Sprint3/Retrospective.md)
      - [Requirements Definition](./Documentation/Sprint3/RequirementsDefinition.md)
      - [Video Review](https://www.youtube.com/watch?v=e0VnvqfJmUA)
  - [BDD Guide](./Documentation/BDDGuide.md)
  - [Pipeline Guide](./Documentation/PipelineGuide.md)
  - [Metrics Analysis](./Documentation/MetricsAnalysis.md)
  - [Updates to Engineering Process](./Documentation/EngineeringProcess.md)
  - [Updates to Technical Debt](./Documentation/TechnicalDebt.md)


---

## Original Project

The base project was created by Marco Fiorito (227548) and Matias Salles (201701) as part of App Design 2 (6243). It consists of a WebAPI implementend with C# .netcore 3.1, Entity Framework on a SQL Database and Angular frontend used to consume de WebAPI.
