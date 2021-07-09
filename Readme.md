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
In the project directory, you can run:
### `python3 scripts/docker.run.dependencies.py`
The script starts the hermes-db dependency by using docker-compose.

### Migrations Scripts
In the project directory run:
### `python3 scripts/add.migration.py --name Migration_Name`
The script will create a new migration.

### `python3 scripts/remove.migration.py`
The script will remove the last migration created. If migration was already applied to database you have to update first to the previous migration and then remove it.

### `python3 scripts/undo.migrations.py --name Migration_Name`
The script will update database to the Migration_Name

### `python3 scripts/apply.migration.py`
The script will apply the last migration created.
