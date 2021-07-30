# Hermes
Hermes is an application for cameras that can be used for detecting recyclable materials. 

### Technologies used:
* ASP.NET Core 5.0
* Docker
* Jenkins

### Languages used:
* C#
* Python

### Available Scripts
#### In the project directory, you can run:
* python3 scripts/docker.run.dependencies.py
    #### This script starts the hermes-db dependency by using docker-compose.

### Migrations Scripts
#### In the project directory run:
* python3 scripts/migration.add.py --name Migration_Name

    #### This script will create a new migration.

* python3 scripts/migration.remove.py

    #### This script will remove the last migration created. If a migration was already applied to the database you have to first update it to the previous migration and then remove it.

* python3 scripts/migration.undo.py --name Migration_Name

    #### This script will update the database to the Migration_Name

* python3 scripts/migration.apply.py

    #### This script will apply the last migration created.

### Abbreviations used:
* *M*
  * **M** comes from **Model** and it is used in **Business Layer**.
* *P*
  * **P** comes form **Parameter** and it is a **Parameter Model** used in **Business Layer**.
* *E*
  * **E** comes from **Entity** and it is used in **Data Layer**.
* *T*
  * **T** comes from **Type** and it is a **Graphql type** used in **Presentation Layer**.
* *TP*
  * **TP** comes from **Type Parameter** and it is a **Graphql type parameter** used in **Presentation Layer**.
